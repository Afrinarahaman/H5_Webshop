import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { CartItem } from '../_models/cartItem';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private basketName = "WebShopProjectBasket";
  public basket: CartItem[] = [];
  public search = new BehaviorSubject<string>("");

  constructor(private router: Router) { }

  getBasket(): CartItem[] {
    this.basket = JSON.parse(localStorage.getItem(this.basketName) || "[]");
    return this.basket;
  }
  saveBasket(): void {
    localStorage.setItem(this.basketName, JSON.stringify(this.basket));
  }
  addToBasket(item: CartItem): void {
    this.getBasket();

    let productFound = false;
 

    if (!productFound) {
      this.basket.push(item);
    }
    this.saveBasket();
  }
  getTotalPrice(): number {       //This calculates total price of all of the cartitems 
    this.getBasket();
    var grandTotal = 0;
    for (let i = 0; i < this.basket.length; i++) {
      grandTotal += this.basket[i].quantity * this.basket[i].productPrice;
    }
    this.saveBasket();
    return grandTotal;
  }
  

  async addOrder(): Promise<any> {
   
  }
  clearBasket(): CartItem[] {
    this.getBasket();
    this.basket = [];
    this.saveBasket();
    return this.basket;
  }
  removeItemFromBasket(productId: number): void {
    this.getBasket();
    for (let i = 0; i < this.basket.length; i += 1) {
      if (this.basket[i].productId === productId) {

        this.basket.splice(i, 1);


      }
    }
    // this.basket.map((a:any, index:any)=>{
    //   if(productId===a.id){
    //     console.log(a.id);
    //     this.basket.splice(index,1)
    //   }
    // })
    this.saveBasket();

  }

}
