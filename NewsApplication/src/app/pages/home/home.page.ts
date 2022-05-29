import {Component, OnInit} from '@angular/core';
import {NewsService} from '../../services/news.service';

@Component({
    selector: 'app-home',
    templateUrl: 'home.page.html',
    styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {

    constructor() {
    }

    ngOnInit(): void {
    }
}
