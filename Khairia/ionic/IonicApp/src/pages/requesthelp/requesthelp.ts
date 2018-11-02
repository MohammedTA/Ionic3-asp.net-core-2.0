import { Component } from '@angular/core';
import { IonicPage, NavController, ModalController, AlertController } from 'ionic-angular';
import { Zone } from '../../models/zone';
import { Zones } from '../../providers/providers';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { Api } from '../../providers/api/api';
import { Help } from '../../models/help';

@IonicPage()
@Component({
  selector: 'page-requesthelp',
  templateUrl: 'requesthelp.html',
})
export class RequestHelpPage {
  zonesItems: Zone[];
  help: Help = new Help();
  minDate: string;
  constructor(public navCtrl: NavController,
    public zones: Zones,
    public modalCtrl: ModalController,
    private loadingCtrl: LoadingController,
    private alertController: AlertController,
    private api: Api) {
    this.zonesItems = this.zones.query();

    this.help.Corp = 0;
    this.help.Registerme = 0;
    this.help.Money = 0;
    this.help.Food = 0;
    this.getMinDate()
  }

  select(isChecked, type){
   this.help[type] = isChecked ? 1 : 0;
  }

  faildAlert(message) {
    let alert = this.alertController.create({
      title: 'فشلت العملية',
      subTitle: message,
      buttons: ['موافق']
    });
    alert.present();
  }

  getMinDate(){
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth()+1; //January is 0!
    var formatmm = mm < 10 ? `0${mm}` : `${mm}`
    var yyyy = today.getFullYear();
    this.minDate = `${yyyy}-${formatmm}-${dd}`;
    console.log(`${yyyy}-${formatmm}-${dd}`);
  }

  TelMobileValidate(type) {
      if (this.help.Mobile &&
        this.help.Mobile.length == 10 &&
        this.help.Mobile.charAt(0) == "0" &&
        this.help.Mobile.charAt(1) == "5") {
        return false;
      }
      else {
        this.faildAlert("يرجى ادخال رقم الجوال بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام مبدوءا ب 05")
        return true;
      }
  }

  validateEmail() {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if(re.test(this.help.Email)){
      return false;
    } else{
      this.faildAlert("يرجى ادخال البريد الالكتروني بالشكل الصحيح")
      return true;
    }
  }

  successAlert() {
    let alert = this.alertController.create({
      title: 'نجاح العملية',
      subTitle: 'تم استلام طلبكم بنجاح',
      buttons: ['موافق']
    });
    alert.present();
  }

  requildFields() {
    return (!this.help.Registerme && !this.help.Corp && !this.help.Money &&
      !this.help.Food) || !this.help.NId
      || !this.help.Name || !this.help.Address ||
      !this.help.IdExpire || !this.help.Place ||
      !this.help.Mobile || !this.help.FamilyNumber ||
      !this.help.IncomeType || !this.help.Income || !this.help.Email ||
      !this.help.LivType
  }

  requiredAlert() {
    let alert = this.alertController.create({
      title: ' حقول مطلوبة',
      subTitle: 'يجب ادخال جميع الحقول',
      buttons: ['موافق']
    });
    alert.present();
  }

  public saveData() {

    console.log(this.help);
    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });

    if (this.requildFields() || (this.help.LivType === "ايجار" && !this.help.Rent)) {
      this.requiredAlert()
      return;
    }

    if (this.TelMobileValidate("Mobile")) {
      return;
    }

    if(this.validateEmail()){
      return;
    }

    loader.present();
    this.api.post("Help", this.help).subscribe(
      data => {
        loader.dismissAll();
        console.log(data);
        this.successAlert();
      },
      error => {
        loader.dismissAll();
        console.log(error);
        this.faildAlert(error.error);
      },
      () => console.log("done")
    );
  }
}
