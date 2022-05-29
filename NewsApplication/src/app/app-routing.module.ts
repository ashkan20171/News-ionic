import {NgModule} from '@angular/core';
import {PreloadAllModules, RouterModule, Routes} from '@angular/router';

const routes: Routes = [
    {
        path: 'home',
        loadChildren: () => import('./pages/home/home.module').then(m => m.HomePageModule)
    },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'news-detail/:newsId',
        loadChildren: () => import('./pages/news/news-detail/news-detail.module').then(m => m.NewsDetailPageModule)
    },
    {
        path: 'news-by-category/:categoryId',
        loadChildren: () => import('./pages/news/news-by-category/news-by-category.module').then(m => m.NewsByCategoryPageModule)
    },
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes, {preloadingStrategy: PreloadAllModules})
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
