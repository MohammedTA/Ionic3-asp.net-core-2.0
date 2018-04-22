import { Component } from '@angular/core';
import { IonicPage, NavController, ViewController, MenuController } from 'ionic-angular';


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
    public menu: MenuController) {
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
}
