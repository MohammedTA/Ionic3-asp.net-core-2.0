import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { FurniturePage } from './furniture';

@NgModule({
  declarations: [
    FurniturePage
  ],
  imports: [
    IonicPageModule.forChild(FurniturePage),
    TranslateModule.forChild()
  ],
  exports: [
    FurniturePage
  ]
})
export class FurniturePageModule { }
