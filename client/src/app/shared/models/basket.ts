import * as cuid from 'cuid';

export interface BasketItem {
  quantity: number;
  id: number;
  productName: string;
  price: number;
  imageUrl: string;

  description: string;
}

export interface Basket {
  id: string;
  items: BasketItem[];
}

export class Basket implements Basket {
  id = cuid();
  items: BasketItem[] = [];
}

export interface BasketTotals {
  subtotal: number;
  total: number;
}
