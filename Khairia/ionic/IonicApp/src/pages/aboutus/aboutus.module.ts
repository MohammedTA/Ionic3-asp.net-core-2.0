import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { AboutUsPage } from './aboutus';

@NgModule({
  declarations: [
    AboutUsPage
  ],
  imports: [
    IonicPageModule.forChild(AboutUsPage),
    TranslateModule.forChild()
  ],
  exports: [
    AboutUsPage
  ]
})
export class AboutUsPageModule { }
