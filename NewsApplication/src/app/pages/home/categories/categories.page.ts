import {Component, OnInit} from '@angular/core';
import {NewsService} from '../../../services/news.service';
import {NewsCategoryDTO} from '../../../DTOs/NewsCategoryDTO';
import {Router} from '@angular/router';

@Component({
    selector: 'app-categories',
    templateUrl: './categories.page.html',
    styleUrls: ['./categories.page.scss'],
})
export class CategoriesPage implements OnInit {
    categories: NewsCategoryDTO[] = [];


    constructor(
        private newsService: NewsService,
        private router: Router
    ) {
    }

    ngOnInit(): void {
        this.newsService.getAllNewsCategories().subscribe(res => {
            this.categories = res.categories;
            this.newsService.setCategories(res.categories);
        });
    }

    showNews(categoryId: number) {
        this.router.navigate(['/news-by-category', categoryId]);
    }

}
