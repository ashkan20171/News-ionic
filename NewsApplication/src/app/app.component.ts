import {Component, Inject} from '@angular/core';

import {Platform} from '@ionic/angular';
import {SplashScreen} from '@ionic-native/splash-screen/ngx';
import {StatusBar} from '@ionic-native/status-bar/ngx';
import {DOCUMENT} from '@angular/common';
import {NewsService} from './services/news.service';

@Component({
    selector: 'app-root',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.scss']
})
export class AppComponent {
    constructor(
        private platform: Platform,
        private splashScreen: SplashScreen,
        private statusBar: StatusBar,
        @Inject(DOCUMENT) private document: Document,
        private newsService: NewsService
    ) {
        this.initializeApp();
        this.document.documentElement.dir = 'rtl';
    }

    initializeApp() {
        this.platform.ready().then(() => {
            this.statusBar.styleDefault();
            this.splashScreen.hide();
            this.newsService.getAllNewsCategories().subscribe(res => {
                this.newsService.setCategories(res.categories);
            });
        });
    }
}
