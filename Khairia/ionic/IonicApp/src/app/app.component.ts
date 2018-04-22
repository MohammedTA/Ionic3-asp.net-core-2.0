import { Component, ViewChild } from '@angular/core';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { TranslateService } from '@ngx-translate/core';
import { Config, Nav, Platform } from 'ionic-angular';

import { FirstRunPage } from '../pages/pages';
import { Settings } from '../providers/providers';

@Component({
  templateUrl: 'app.component.html'
})
export class MyApp {
  rootPage = FirstRunPage;

  @ViewChild(Nav) nav: Nav;

  pages: any[] = [
    { title: 'حفظ النعمة', component: 'HefzneamaPage', icon: 'assets/img/side-menu-icons/1.png' },
    { title: 'جلب الاثاث', component: 'FurniturePage', icon: 'assets/img/side-menu-icons/2.png' },
    { title: 'التطوع', component: 'VolunteerPage', icon: 'assets/img/side-menu-icons/3.png' },
    { title: 'خدمات المستخدمين', component: 'ServicesPage', icon: 'assets/img/side-menu-icons/4.png' },
    { title: 'المساعدات للمحتاجين الجدد', component: 'RequestHelpPage', icon: 'assets/img/side-menu-icons/5.png' },
    { title: 'دلني على محتاج', component: 'TellmePage', icon: 'assets/img/side-menu-icons/6.png' },
    { title: 'تبرع', component: 'DonationPage', icon: 'assets/img/side-menu-icons/7.png' },
    { title: 'من نحن', component: 'AboutUsPage', icon: 'assets/img/side-menu-icons/8.png' }
  ]


  constructor(private translate: TranslateService,
    platform: Platform, settings: Settings,
    private config: Config,
     private statusBar: StatusBar,
      private splashScreen: SplashScreen) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
    this.initTranslate();
  }

  initTranslate() {
    // Set the default language for translation strings, and the current language.
    this.translate.setDefaultLang('en');
    const browserLang = this.translate.getBrowserLang();

    if (browserLang) {
      if (browserLang === 'zh') {
        const browserCultureLang = this.translate.getBrowserCultureLang();

        if (browserCultureLang.match(/-CN|CHS|Hans/i)) {
          this.translate.use('zh-cmn-Hans');
        } else if (browserCultureLang.match(/-TW|CHT|Hant/i)) {
          this.translate.use('zh-cmn-Hant');
        }
      } else {
        this.translate.use(this.translate.getBrowserLang());
      }
    } else {
      this.translate.use('en'); // Set your language here
    }

    this.translate.get(['BACK_BUTTON_TEXT']).subscribe(values => {
      this.config.set('ios', 'backButtonText', values.BACK_BUTTON_TEXT);
    });
  }

  openPage(page) {
    this.nav.push(page.component)
  }
}
