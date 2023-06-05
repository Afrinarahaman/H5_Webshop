import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { CategoryProductsComponent } from './category-products/category-products.component';

const routes: Routes = [
  { path: '', component: FrontpageComponent },
  { path: 'category-products/:id', component: CategoryProductsComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
