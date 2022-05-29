import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {NewsCategoryDTO} from '../DTOs/NewsCategoryDTO';
import {NewsItemDTO} from '../DTOs/NewsItemDTO';
import {MainDomain} from '../DTOs/Constants';

@Injectable({
    providedIn: 'root'
})
export class NewsService {

    private allCategories: BehaviorSubject<NewsCategoryDTO[]> = new BehaviorSubject<NewsCategoryDTO[]>(null);

    constructor(
        private http: HttpClient
    ) {
    }

    getCategories(): Observable<NewsCategoryDTO[]> {
        return this.allCategories;
    }

    setCategories(categories: NewsCategoryDTO[]): void {
        this.allCategories.next(categories);
    }

    getAllNewsCategories(): Observable<{ categories: NewsCategoryDTO[] }> {
        const url = MainDomain + '/api/News/news-categories';
        return this.http.get<{ categories: NewsCategoryDTO[] }>(url);
    }

    getAllNewsByCategory(categoryId: number): Observable<{ news: NewsItemDTO[] }> {
        return this.http.get<{ news: NewsItemDTO[] }>(MainDomain + '/api/News/news-by-category/' + categoryId);
    }

    getNewsById(newsId: number): Observable<{ news: NewsItemDTO }> {
        return this.http.get<{ news: NewsItemDTO }>(MainDomain + '/api/News/news-detail/' + newsId);
    }

    getLatestNewses(): Observable<{ newses: NewsItemDTO[] }> {
        return this.http.get<{ news: NewsItemDTO[] }>(MainDomain + '/api/News/latest-newses');
    }
}
