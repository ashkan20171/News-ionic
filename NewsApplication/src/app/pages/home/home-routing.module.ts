import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomePage} from './home.page';

const routes: Routes = [
    {
        path: 'tabs',
        component: HomePage,
        children: [
            {
                path: 'categories',
                loadChildren: () => import('./categories/categories.module').then(m => m.CategoriesPageModule)
            },
            {
                path: 'latest-news',
                loadChildren: () => import('./latest-news/latest-news.module').then(m => m.LatestNewsPageModule)
            }
        ]
    },
    {
        path: '',
        redirectTo: 'tabs/categories'
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomePageRoutingModule {
}
