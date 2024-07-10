import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private myAppUrl = 'http://localhost:5276/';
  private myApiUrl = 'api/Products/'

  constructor(private http: HttpClient) { }

  getProducts(): Observable<any> {
    return this.http.get(this.myAppUrl + this.myApiUrl);
  }

  deleteProducts(id: number): Observable<any> {
    return this.http.delete(this.myAppUrl + this.myApiUrl + id)
  }

  saveProducts(product: any): Observable<any> {
    return this.http.post(this.myAppUrl + this.myApiUrl, product);
  }

  updateProducts(id: number, product: any): Observable<any> {
    return this.http.put(this.myAppUrl + this.myApiUrl + id, product);
  }
}
