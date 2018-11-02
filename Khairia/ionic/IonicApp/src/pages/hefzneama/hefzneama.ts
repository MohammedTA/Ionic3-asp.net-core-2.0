import { Component,
  //  ElementRef,
    // ViewChild 
  } from "@angular/core";
import { IonicPage,
   NavController,
    LoadingController,
     AlertController
      // Platform 
    } from "ionic-angular";
import { Api } from "../../providers/api/api"
import { Food } from "../../models/food";
// import { Geolocation } from 'ionic-native';
// import { Hour } from '../../models/hour';
// import { Hours } from '../../providers/providers';
// import {
//   GoogleMaps,
//   GoogleMap,
//   GoogleMapsEvent,
//   GoogleMapOptions,
//   CameraPosition,
//   MarkerOptions,
//   Marker,
//   LatLng
// } from '@ionic-native/google-maps';
// import * as Leaflet from 'leaflet';


// declare var google;

@IonicPage()
@Component({
  selector: "page-hefzneama",
  templateUrl: "hefzneama.html",
  providers: [Api
    //  Geolocation
    ]
})
export class HefzneamaPage {
  myDate: any = new Date();
  week: any = [];
  food: Food = new Food();
  loader: any;
  lat: number;
  lng: number;
  HourList: any;
  minDate:string;
  //@ViewChild('map') mapElement: ElementRef;
  // map: any;

  constructor(public navCtrl: NavController,
    public api: Api,
    // public geolocation: Geolocation,
    public loadingCtrl: LoadingController,
    public alertController: AlertController
    // private googleMaps: GoogleMaps,
    // private platform: Platform,
  ) {
    this.food.Lat = "";
    this.food.Long = "";
    this.getDurations()
    this.getMinDate()
    // platform.ready().then(() => {
    //   //this.loadMap();
    // });
  }


  // loadMap() {
  //   let loader = this.loadingCtrl.create({
  //     content: "انتظر قليلا"
  //   });
  //   loader.present();
  //   let optionsGPS = { timeout: 40000, enableHighAccuracy: true };
  //   Geolocation.getCurrentPosition(optionsGPS).then((position) => {
  //     loader.dismissAll();
  //     this.lat = position.coords.latitude;
  //     this.lng = position.coords.longitude;
  //     let mapOptions: GoogleMapOptions = {
  //       camera: {
  //         target: {
  //           lat: this.lat,
  //           lng: this.lng
  //         },
  //         zoom: 11,
  //         tilt: 30
  //       },
  //       mapType: google.maps.MapTypeId.ROADMAP
  //     };

  //     this.map = this.googleMaps.create(this.mapElement.nativeElement, mapOptions);

  //     this.map.one(GoogleMapsEvent.MAP_READY).then(() => {
  //       this.map.addMarker({
  //         title: 'حرك المؤشر للمكان الذي تريده',
  //         icon: 'red',
  //         animation: 'DROP',
  //         draggable:true,
  //         position: {
  //           lat: this.lat,
  //           lng: this.lng
  //         }
  //       })
  //       .then(marker => {
  //           marker.on(GoogleMapsEvent.MARKER_DRAG_END)
  //           .subscribe(() => {
  //             this.food.Lat = marker.getPosition().lat().toString();
  //             this.food.Long = marker.getPosition().lng().toString();
  //           });
  //       });
  //     });
  //   },
  //     (err) => {
  //       loader.dismissAll();
  //       let alert = this.alertController.create({
  //         title: "الموقع الحالي",
  //         subTitle: "يرجى تشغيل خدمة الموقع بهاتفك",
  //         buttons: ["موافق"]
  //       });
  //       alert.present();
  //       console.log(err);
  //       this.lat = 24.7241453;
  //       this.lng = 46.2606922;
  //       let mapOptions: GoogleMapOptions = {
  //         camera: {
  //           target: {
  //             lat: this.lat,
  //             lng: this.lng
  //           },
  //           zoom: 11,
  //           tilt: 30
  //         },
  //         mapType: google.maps.MapTypeId.ROADMAP
  //       };
  //       this.map = this.googleMaps.create(this.mapElement.nativeElement, mapOptions);
  //     });
  // }
  getDurations(){
    let loader = this.loadingCtrl.create({
      content: "يرجى الانتظار .. "
    });
    loader.present();
    this.api.get("AssetOrderDuration").subscribe(
      data => {
        loader.dismissAll();
        this.HourList = data;
      },
      error => {
        console.log(error)
        loader.dismissAll();
      }
    );
  }
  
  TelMobileValidate(type) {
    if (type === "Mobile") {
      if (this.food.Mobile &&
        this.food.Mobile.length == 10 &&
        this.food.Mobile.charAt(0) == "0" &&
        this.food.Mobile.charAt(1) == "5") {
        return false;
      }
      else {
        this.faildAlert("يرجى ادخال رقم الجوال بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام مبدوءا ب 05")
        return true;
      }
    } else {
      if (this.food.Phone &&
        this.food.Phone.length == 10 &&
        this.food.Phone.charAt(0) == "0" &&
        this.food.Phone.charAt(1) == "1") {
        return false;
      }
      else {
        this.faildAlert("يرجى ادخال رقم الهاتف بالشكل الصحيح <br>  يجب أن يتكون من 10 أرقام مبدوءا ب 01");
        return true;
      }
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

  requiredAlert() {
    let alert = this.alertController.create({
      title: ' حقول مطلوبة',
      subTitle: 'يجب ادخال جميع الحقول',
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

  faildAlert(message) {
    let alert = this.alertController.create({
      title: 'فشلت العملية',
      subTitle: message,
      buttons: ['موافق']
    });
    alert.present();
  }

  setDuCode(){
    var durationDoce = this.HourList.find(x => x.duration == this.food.Hour).code;
    this.food.Code = durationDoce;
  }

  requildFields() {
    return !this.food.Day || !this.food.Hour || !this.food.Address || !this.food.Name || !this.food.Mobile
      || !this.food.Phone || !this.food.Hallname || !this.food.Asset

  }

  public saveData() {
    console.log(this.food);
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
    this.api.post("AssetsOrder", (this.food)).subscribe(
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
