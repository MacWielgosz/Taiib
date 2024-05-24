import { Component, OnInit } from '@angular/core';
import { ProductDTO } from '../model/ProductDTO.interface';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductRequestDTO } from '../model/ProductRequestDTO.interface';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.css'
})
export class ProductAddComponent {
  productForm: FormGroup;
  constructor(
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
    saveProduct(): void {
    if (this.productForm.valid) {
      const addedProduct = this.productForm.value as ProductRequestDTO;
      this.productService.addProduct(addedProduct).subscribe({
        next: () => {
          console.log('Produkt dodany pomyślnie');
          this.router.navigate(['/products']); // Przekierowanie do listy produktów
        },
        error: (err) => {
          console.error('Błąd podczas dodawania produktu', err);
        }
      });
    }
  }
}
