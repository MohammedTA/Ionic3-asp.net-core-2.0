import { Component } from '@angular/core';
import { IonicPage, NavController, ViewController, MenuController } from 'ionic-angular';
import { SocialSharing } from '@ionic-native/social-sharing';


export interface Slide {
  image: string;
}

@IonicPage()
@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  slides: Slide[];
  
  constructor(public navCtrl: NavController,
    public viewCtrl: ViewController,
    public menu: MenuController,
    private socialSharing: SocialSharing) {
    this.slides = [
      {
        image: 'assets/img/slider/3.jpg',
      },
      {
        image: 'assets/img/slider/1.jpg',
      },
      {
        image: 'assets/img/slider/2.jpg',
      }
    ];
  }
  openMenu() {
    this.menu.open();
  }

  regularShare(){
    var msg = "https://play.google.com/store?hl=en";
    this.socialSharing.share(msg, null, null, null);
  }

  // compilemsg(index):string{
  //   var msg = this.quotes[index].content + "-" + this.quotes[index].title ;
  //   return msg.concat(" \n Sent from my Awesome App !");
  // }
}
