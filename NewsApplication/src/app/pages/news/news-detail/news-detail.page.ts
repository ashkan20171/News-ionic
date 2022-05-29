import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {NewsService} from '../../../services/news.service';
import {NewsItemDTO} from '../../../DTOs/NewsItemDTO';

@Component({
    selector: 'app-news-detail',
    templateUrl: './news-detail.page.html',
    styleUrls: ['./news-detail.page.scss'],
})
export class NewsDetailPage implements OnInit {

    news: NewsItemDTO = null;

    constructor(
        private activatedRoute: ActivatedRoute,
        private newsService: NewsService
    ) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => {
            const newsId = parseInt(params.newsId, 0);
            this.newsService.getNewsById(newsId).subscribe(res => {
                this.news = res.news;
            });
        });
    }

}
