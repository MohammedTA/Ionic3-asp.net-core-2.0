import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { VolunteerPage } from './volunteer';

@NgModule({
  declarations: [
    VolunteerPage
  ],
  imports: [
    IonicPageModule.forChild(VolunteerPage),
    TranslateModule.forChild()
  ],
  exports: [
    VolunteerPage
  ]
})
export class VolunteerPageModule { }
