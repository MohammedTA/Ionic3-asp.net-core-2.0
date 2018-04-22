import { Component } from '@angular/core';
import { IonicPage, NavController, AlertController } from 'ionic-angular';
import { Volunteer } from '../../models/volunteer';
import { Api } from '../../providers/api/api';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

@IonicPage()
@Component({
  selector: 'page-volunteer',
  templateUrl: 'volunteer.html',
})
export class VolunteerPage {
  myDate: any = new Date();
  volunteer: Volunteer = new Volunteer();
  days: any[] = [];
  fields: any[] = [];
  myList: any;
  private todo2: FormGroup;
  constructor(public navCtrl: NavController,
    private api: Api,
    private alertController: AlertController,
    private loadingCtrl: LoadingController,
    private formBuilder: FormBuilder) {

    this.todo2 = this.formBuilder.group({
      Name: ['', Validators.required],
      idNumber: ['', Validators.required],
      Jawwal: ['', Validators.required],
      Email: ['', Validators.required],
      nationality: ['', Validators.required],
      address: ['', Validators.required],
      certifcates: ['', Validators.required],
      skills: ['', Validators.required],
      days: ['', Validators.required],
      time: ['', Validators.required],
      Houres: ['', Validators.required],
      notes: ['', Validators.required],
      fields: ['', Validators.required],
    });

    this.days = [
      { id: 1, name: "السبت", checked: false },
      { id: 2, name: "الأحد", checked: false },
      { id: 3, name: "الاثنين", checked: false },
      { id: 4, name: "الثلاثاء", checked: false },
      { id: 5, name: "الأربعاء", checked: false },
      { id: 6, name: "الخميس", checked: false },
      { id: 7, name: "الجمعة", checked: false },
    ]
    this.getFields();
  }

  public getFields() {
    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });
    loader.present();
    this.api.get("Volunteerfields").subscribe(
      data => {
        loader.dismissAll();
        this.myList = data;
        for (let a of this.myList) {
          this.fields.push({
            id: a.voluntid,
            name: a.voluntname,
            checked: false
          });
        }
      },
      error => {
        loader.dismissAll();
        console.log(error)
      },
      () => console.log("done")
    );

  }

  requildFields() {
    return !this.volunteer.Name || !this.volunteer.Nid || !this.volunteer.Mobile ||
      !this.volunteer.Email || !this.volunteer.Address
      || !this.volunteer.Certifcates || !this.volunteer.Skils ||
      !this.volunteer.Time || !this.volunteer.Houres ||
      !this.volunteer.Natinality
  }

  requiredAlert() {
    let alert = this.alertController.create({
      title: ' حقول مطلوبة',
      subTitle: 'يجب ادخال جميع الحقول',
      buttons: ['موافق']
    });
    alert.present();
  }

  TelMobileValidate(type = null) {
    if (this.volunteer.Mobile &&
      this.volunteer.Mobile.length == 10 &&
      this.volunteer.Mobile.charAt(0) == "0" &&
      this.volunteer.Mobile.charAt(1) == "5") {
      return false;
    }
    else {
      this.faildAlert("يرجى ادخال رقم الجوال بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام مبدوءا ب 05")
      return true;
    }
  }

  IdNumberValidate() {
    if (this.volunteer.Nid &&
      this.volunteer.Nid.length == 10) {
      return false;
    }
    else {
      this.faildAlert("يرجى ادخال رقم الهوية بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام")
      return true;
    }
  }

  faildAlert(message) {
    let alert = this.alertController.create({
      title: 'فشلت العملية',
      subTitle: message,
      buttons: ['موافق']
    });
    alert.present();
  }

  successAlert() {
    let alert = this.alertController.create({
      title: 'نجاح العملية',
      subTitle: 'تم استلام طلبكم بنجاح',
      buttons: ['موافق']
    });
    alert.present();
  }

  select(id, isChecked, type) {
    if (type === 1) {
      this.days.find(t => t.id == id).checked = isChecked
    }
    else {
      this.fields.find(t => t.id == id).checked = isChecked
    }
  }
  validateEmail() {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (re.test(this.volunteer.Email)) {
      return false;
    } else {
      this.faildAlert("يرجى ادخال البريد الالكتروني بالشكل الصحيح")
      return true;
    }
  }


  public saveData() {
    this.volunteer.Fields = this.fields.filter(t => t.checked == true).map(t => t.name);
    this.volunteer.Days = this.days.filter(t => t.checked == true).map(t => t.name);

    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });

    if (this.requildFields() || !this.volunteer.Days.length || !this.volunteer.Fields.length) {
      this.requiredAlert()
      return;
    }

    if (this.TelMobileValidate()) {
      return;
    }

    if (this.validateEmail()) {
      return;
    }

    if (this.IdNumberValidate()) {
      return;
    }

    loader.present();
    this.api.post("Volunteer", (this.volunteer)).subscribe(
      data => {
        loader.dismissAll();
        console.log(data)
        this.successAlert()
      },
      error => {
        loader.dismissAll();
        this.faildAlert(error.error);
        console.log(error)
      },
      () => console.log("done")
    );
  }
}
