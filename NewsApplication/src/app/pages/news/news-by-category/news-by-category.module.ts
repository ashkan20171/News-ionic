import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { NewsByCategoryPageRoutingModule } from './news-by-category-routing.module';

import { NewsByCategoryPage } from './news-by-category.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    NewsByCategoryPageRoutingModule
  ],
  declarations: [NewsByCategoryPage]
})
export class NewsByCategoryPageModule {}
