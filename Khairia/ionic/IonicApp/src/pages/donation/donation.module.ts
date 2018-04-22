import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { DonationPage } from './donation';

@NgModule({
  declarations: [
    DonationPage
  ],
  imports: [
    IonicPageModule.forChild(DonationPage),
    TranslateModule.forChild()
  ],
  exports: [
    DonationPage
  ]
})
export class DonationPageModule { }
