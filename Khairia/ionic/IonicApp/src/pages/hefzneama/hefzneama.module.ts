import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { HefzneamaPage } from './hefzneama';

@NgModule({
  declarations: [
    HefzneamaPage
  ],
  imports: [
    IonicPageModule.forChild(HefzneamaPage),
    TranslateModule.forChild()
  ],
  exports: [
    HefzneamaPage
  ]
})
export class HefzneamaPageModule { }
