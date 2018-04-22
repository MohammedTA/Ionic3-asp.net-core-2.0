import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { ServicesPage } from './services';

@NgModule({
  declarations: [
    ServicesPage
  ],
  imports: [
    IonicPageModule.forChild(ServicesPage),
    TranslateModule.forChild()
  ],
  exports: [
    ServicesPage
  ]
})
export class ServicesPageModule { }
