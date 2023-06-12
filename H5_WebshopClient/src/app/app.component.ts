import { Component } from '@angular/core';

import { Router } from '@angular/router';
import { CategoryService } from './_services/category.service';
import { Category } from './_models/category';
import { CartService } from './_services/cart.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 

  title = 'Webshop_H5-Client';
  categories: Category[]=[];
  category:Category = {id: 0, categoryName :""};
  public totalItem : number =this.cartService.getBasket().length;
  constructor(
    private router: Router,
 
    private categoryService: CategoryService,
    private cartService: CartService
   
  ) { }
  ngOnInit(): void{

    this.categoryService.getCategoriesWithoutProducts().subscribe(x => this.categories = x);
    console.log('value received ', );
    

  }

}
