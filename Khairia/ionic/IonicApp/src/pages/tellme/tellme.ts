import { Component } from '@angular/core';
import { IonicPage, NavController, ModalController, LoadingController, AlertController } from 'ionic-angular';
import { Api } from '../../providers/providers';
import { Needy } from '../../models/needy';
import { Zone } from '../../models/zone';
import { Zones } from '../../providers/providers';

@IonicPage()
@Component({
  selector: 'page-tellme',
  templateUrl: 'tellme.html',
})
export class TellmePage {
  needy:Needy = new Needy();
  zonesItems: Zone[];
  constructor(public navCtrl: NavController,
    public modalCtrl: ModalController,
    public zones: Zones,
    private loadingCtrl: LoadingController,
    private alertController: AlertController,
    private api: Api) {
      this.zonesItems = this.zones.query();
  }

  TelMobileValidate(type = null) {
    if ((this.needy.Phone &&
      this.needy.Phone.length == 10 &&
      this.needy.Phone.charAt(0) == "0" &&
      this.needy.Phone.charAt(1) == "5") && 
      (this.needy.Senderphone &&
        this.needy.Senderphone.length == 10 &&
        this.needy.Senderphone.charAt(0) == "0" &&
        this.needy.Senderphone.charAt(1) == "5"))  {
      return false;
    }
    else {
      this.faildAlert("يرجى ادخال رقم الجوال بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام مبدوءا ب 05")
      return true;
    }
}

  requildFields() {
    return !this.needy.Pername || !this.needy.Phone || !this.needy.Squer ||
      !this.needy.Sendername || !this.needy.Senderphone
  }

  requiredAlert() {
    let alert = this.alertController.create({
      title: ' حقول مطلوبة',
      subTitle: 'يجب ادخال جميع الحقول',
      buttons: ['موافق']
    });
    alert.present();
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
  
  public saveData() {
    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });

    if (this.requildFields()) {
      this.requiredAlert()
      return;
    }

    if(this.TelMobileValidate()){
      return;
    }

    loader.present();

    this.api.post("Needy", this.needy).subscribe(
      data => {
        loader.dismissAll();
        console.log(data);
        this.successAlert();
      },
      error => {
        loader.dismissAll();
        console.log(error)
        this.faildAlert(error.error);
      },
      () => console.log("done")
    );
  }
}
