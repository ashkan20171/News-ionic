import {Component, OnInit} from '@angular/core';
import {NewsService} from '../../../services/news.service';
import {NewsItemDTO} from '../../../DTOs/NewsItemDTO';

@Component({
    selector: 'app-latest-news',
    templateUrl: './latest-news.page.html',
    styleUrls: ['./latest-news.page.scss'],
})
export class LatestNewsPage implements OnInit {
    latestNewses: NewsItemDTO[] = [];

    constructor(
        private newsService: NewsService
    ) {
    }

    ngOnInit() {
        this.newsService.getLatestNewses().subscribe(res => {
            this.latestNewses = res.newses;
        });
    }

}
