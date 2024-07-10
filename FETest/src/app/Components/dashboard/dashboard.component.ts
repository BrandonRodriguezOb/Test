import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  listProducts: any[] = [];
  form: FormGroup;
  id: number | undefined;

  constructor(private fb: FormBuilder,  private _ProductService: ProductService ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      desc: ['', [Validators.required]],
      price: ['', [Validators.required]],
    })
   }

   ngOnInit(): void {
    this.getProducts();
    console.log("algo");
  }

   getProducts() {
    this._ProductService.getProducts().subscribe(data => {
      console.log(data);
      this.listProducts = data;
    }, error => {
      console.log(error);
    })
  }

   SaveProduct() {

    const Product: any = {
      Id: 0,
      Name: this.form.get('name')?.value,
      Description: this.form.get('desc')?.value,
      Price: this.form.get('price')?.value     
    }   

    console.log(Product);

    if(this.id == undefined) {
      // Agregamos una nueva Product
        this._ProductService.saveProducts(Product).subscribe(data => {
          console.log('The Product was registered Successfully!', 'Success');
          this.getProducts();
          this.form.reset();
        }, error => {
          console.log('Opss.. Error','Error')
          console.log(error);
        })
    }else {

      Product.id = this.id;
      // Editamos tarjeta
      this._ProductService.updateProducts(this.id,Product).subscribe(data => {
        this.form.reset();
        this.id = undefined;
        this.getProducts();
      }, error => {
        console.log(error);
      })

    }

   
  }


  deleteProduct(id: number) {
    this._ProductService.deleteProducts(id).subscribe(data => {     
      this.getProducts();
    }, error => {
      console.log(error);
    })

  }

  editProduct(product: any) {
    this.id = product.id;

    this.form.patchValue({
      name: product.name,
      desc: product.description,
      price: product.price
    })
  }


}
