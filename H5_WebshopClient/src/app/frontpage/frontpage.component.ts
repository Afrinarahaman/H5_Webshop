import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../_models/product';

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.css']
})
export class FrontpageComponent implements OnInit {

  product: Product = { id: 0, title: "", price: 0, description: "", image: "", stock: 0, categoryId: 0 }
  products: Product[] = [];
  productId: number = 0;
  searchKey: string = "";
  searchProducts: Product[] = [];
  productService: any;
  constructor( private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe((x: Product[]) =>{ 
      this.products = x;
      this.searchProducts=this.products;
     
      console.log(x);
      
      this.route.params.subscribe(params => {
        this.productService.getProductById(params['productId']).subscribe((x: Product) => this.product = x);
      
    });

  })
  
  }

}
