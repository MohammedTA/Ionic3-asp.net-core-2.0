import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { RequestHelpPage } from './requesthelp';

@NgModule({
  declarations: [
    RequestHelpPage
  ],
  imports: [
    IonicPageModule.forChild(RequestHelpPage),
    TranslateModule.forChild()
  ],
  exports: [
    RequestHelpPage
  ]
})
export class RequestHelpPageModule { }
