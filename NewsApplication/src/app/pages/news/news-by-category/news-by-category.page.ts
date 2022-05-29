import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {NewsService} from '../../../services/news.service';
import {NewsCategoryDTO} from '../../../DTOs/NewsCategoryDTO';
import {NewsItemDTO} from '../../../DTOs/NewsItemDTO';

@Component({
    selector: 'app-news-by-category',
    templateUrl: './news-by-category.page.html',
    styleUrls: ['./news-by-category.page.scss'],
})
export class NewsByCategoryPage implements OnInit {
    selectedCategory: NewsCategoryDTO = null;
    news: NewsItemDTO[] = [];

    constructor(
        private activatedRoute: ActivatedRoute,
        private newsService: NewsService
    ) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => {
            const categoryId = parseInt(params.categoryId, 0);
            this.newsService.getAllNewsByCategory(categoryId).subscribe(res => {
                this.news = res.news;
                console.log(this.news);
            });

            this.newsService.getCategories().subscribe(categories => {
                if (categories !== null && categories.length > 0) {
                    this.selectedCategory = categories.filter(s => s.id === categoryId)[0];
                }
            });
        });
    }

}
