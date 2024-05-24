import { Component, OnInit } from '@angular/core';
import { ProductDTO } from '../model/ProductDTO.interface';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductRequestDTO } from '../model/ProductRequestDTO.interface';
@Component({
  selector: 'app-detail-product',
  templateUrl: './detail-product.component.html',
  styleUrl: './detail-product.component.css'
})
export class DetailProductComponent implements OnInit {
  
  
  product: ProductDTO | null = null;
  productForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router, // Dodano router
    private productService: ProductService,
    private fb: FormBuilder
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      price: [0, Validators.required],
      image: ['', Validators.required]
      })
  };

  ngOnInit() {
    const productIdParam = this.route.snapshot.paramMap.get('productId');
    if (productIdParam !== null) {
      const productId = +productIdParam;
      this.productService.getProductById(productId).subscribe(product => {
        this.product = product;
        this.productForm.patchValue(product, { emitEvent: false });
      });
    }
    
  }

  saveProduct(): void {
    if (this.product && this.productForm.valid) {
      const updatedProduct = this.productForm.value as ProductRequestDTO;
      this.productService.updateProduct(this.product.id, updatedProduct).subscribe({
        next: () => {
          console.log('Produkt zaktualizowany pomyślnie');
          if (this.product) {
            this.product.image = updatedProduct.image;
            this.product.name = updatedProduct.name;
            this.product.price = updatedProduct.price;
          }
        },
        error: (err) => {
          console.error('Błąd podczas aktualizacji produktu', err);
        }
      });
    }
  }

  toggleActivation() {
    if (this.product) {
      this.productService.activateProduct(this.product.id).subscribe(() => {
        if (this.product) { // ponowne sprawdzenie, aby upewnić się, że this.product jest dostępny
          this.product.isActive = !this.product.isActive;
        }
      });
    }
  }

  deleteProduct() {
    if (this.product) {
      this.productService.deleteProduct(this.product.id).subscribe(() => {
        this.router.navigate(['/products']); // Przekierowanie do listy produktów
      });
    }
  }
}
