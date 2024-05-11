import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/models/order';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent  implements OnInit {
  orders: Order[]=[];

  constructor(private http:HttpClient,public orderService:OrderService){}

  ngOnInit(): void {
    this.getOrders()
  }

  getOrders() {

    this.orderService.getOrders().subscribe({
      
      next: (response:Order[]) => {
        this.orders = response
        console.log(this.orders)
      }
      //next: orders => console.log(orders)
    })
    
  }


}
