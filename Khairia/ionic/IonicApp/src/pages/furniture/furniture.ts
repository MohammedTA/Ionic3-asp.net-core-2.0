import { Component } from '@angular/core';
import { IonicPage } from 'ionic-angular';
import { Furniture } from '../../models/furniture';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { Api } from "../../providers/api/api"
import { Zone } from '../../models/zone';

import { Zones } from '../../providers/providers';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { AssetItem } from '../../models/assetitem';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';



@IonicPage()
@Component({
  selector: 'page-furniture',
  templateUrl: 'furniture.html',
  providers: [Api]
})
export class FurniturePage {
  myDate: any = new Date();
  furniture: Furniture = new Furniture();
  furnitureItems: any;
  Items: AssetItem[];
  types: any[];
  zonesItems: Zone[];
  categories: any;
  items: any;
  furnitureTypes: any;
  private todo: FormGroup;
  selectedCatId: number;
  HourList: any;
  minDate: any;

  assettype: FormGroup;
  Note: FormGroup;
  item: FormGroup;
  number: FormGroup;
  cat: FormGroup;
  day: FormGroup;
  hour: FormGroup;
  Address: FormGroup;
  square: FormGroup;
  Name: FormGroup;
  Jawwal: FormGroup;
  Phone: FormGroup;



  constructor(private loadingCtrl: LoadingController,
    private api: Api,
    public zones: Zones,
    private alertController: AlertController,
    private formBuilder: FormBuilder) {
    this.getMinDate()
    this.todo = this.formBuilder.group({
      assettype: ['', Validators.required],
      Note: ['', Validators.required],
      item: ['', Validators.required],
      number: ['', Validators.required],
      cat: ['', Validators.required],
      day: ['', Validators.required],
      hour: ['', Validators.required],
      Address: ['', Validators.required],
      square: ['', Validators.required],
      Name: ['', Validators.required],
      Jawwal: ['', Validators.required],
      Phone: ['', Validators.required],
      AssetNumber: ['', Validators.required]

    });

    this.zonesItems = this.zones.query();

    this.getCategoies();
    this.getfurnitureTypes();
    this.getDurations();

  }

  public getTypes() {
    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });
    loader.present();
    this.api.get("AssetTypes").subscribe(
      data => {
        loader.dismissAll();
        console.log(data)
      },
      error => {
        loader.dismissAll();
        console.log(error)
      },
      () => console.log("done")
    );

  }

  requildFields() {
    return !this.furniture.AssetType ||
      !this.furniture.Notes ||
      !this.furniture.Items.length ||
      !this.furniture.Day ||
      !this.furniture.Hour ||
      !this.furniture.Address ||
      !this.furniture.Square ||
      !this.furniture.Name ||
      !this.furniture.Mobile ||
      !this.furniture.Phone
  }

  requiredAlert() {
    let alert = this.alertController.create({
      title: ' حقول مطلوبة',
      subTitle: 'يجب ادخال جميع الحقول',
      buttons: ['موافق']
    });
    alert.present();
  }

  TelMobileValidate(type) {
    if (type === "Mobile") {
      if (this.furniture.Mobile &&
        this.furniture.Mobile.length == 10 &&
        this.furniture.Mobile.charAt(0) == "0" &&
        this.furniture.Mobile.charAt(1) == "5") {
        return false;
      }
      else {
        this.faildAlert("يرجى ادخال رقم الجوال بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام مبدوءا ب 05")
        return true;
      }
    } else {
      if (this.furniture.Phone &&
        this.furniture.Phone.length == 10 &&
        this.furniture.Phone.charAt(0) == "0" &&
        this.furniture.Phone.charAt(1) == "1") {
        return false;
      }
      else {
        this.faildAlert("يرجى ادخال رقم الهاتف بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام مبدوءا ب 01");
        return true;
      }
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

  getMinDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var formatmm = mm < 10 ? `0${mm}` : `${mm}`
    var yyyy = today.getFullYear();
    this.minDate = `${yyyy}-${formatmm}-${dd}`;
  }

  getCategoies() {
    this.api.get("Categories").subscribe(
      data => {
        this.categories = data;
      },
      error => {
        console.log(error)
      }
    );
  }
  setDuCode() {
    var durationDoce = this.HourList.find(x => x.durname == this.furniture.Hour).durcode;
    this.furniture.DuCode = durationDoce;
  }

  getfurnitureTypes() {
    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });
    loader.present();
    this.api.get("AssetTypes").subscribe(
      data => {
        loader.dismissAll();
        this.furnitureTypes = data;
      },
      error => {
        console.log(error)
        loader.dismissAll();
      }
    );
  }
  getDurations() {
    this.api.get("AssetDuration").subscribe(
      data => {
        this.HourList = data;
      },
      error => {
        console.log(error)
      }
    );
  }

  getItems(cat) {
    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });
    loader.present();
    this.api.get(`Items?categoryId=${this.selectedCatId}`).subscribe(
      data => {
        loader.dismissAll();
        this.items = data;
      },
      error => {
        console.log(error)
        loader.dismissAll();
      }
    );
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

    if (this.TelMobileValidate("Mobile")) {
      return;
    }
    if (this.TelMobileValidate("Tel")) {
      return;
    }

    loader.present();
    this.api.post("Assets", this.furniture).subscribe(
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
