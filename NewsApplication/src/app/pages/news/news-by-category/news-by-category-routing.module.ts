import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NewsByCategoryPage } from './news-by-category.page';

const routes: Routes = [
  {
    path: '',
    component: NewsByCategoryPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NewsByCategoryPageRoutingModule {}
