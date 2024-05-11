import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = 'https://localhost:7100/api/';

  constructor(private http:HttpClient) { }

  getOrders(){
    return this.http.get<Order[]>(this.baseUrl + 'order/');
  }
}
