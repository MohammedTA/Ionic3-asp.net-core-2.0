import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { TellmePage } from './tellme';

@NgModule({
  declarations: [
    TellmePage
  ],
  imports: [
    IonicPageModule.forChild(TellmePage),
    TranslateModule.forChild()
  ],
  exports: [
    TellmePage
  ]
})
export class TellmePageModule { }
