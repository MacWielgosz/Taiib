import { Component, OnInit } from '@angular/core';
import { ProductDTO } from '../model/ProductDTO.interface';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-detail-product',
  templateUrl: './detail-product.component.html',
  styleUrl: './detail-product.component.css'
})
export class DetailProductComponent implements OnInit {
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
  
  product: ProductDTO | null = null; 
  constructor(
    private route: ActivatedRoute,
    private router: Router, // Dodano router
    private productService: ProductService
  ) {}

  ngOnInit() {
    const productIdParam = this.route.snapshot.paramMap.get('productId');
    if (productIdParam !== null) {
      const productId = +productIdParam;
      this.productService.getProductById(productId).subscribe(product => {
        this.product = product;
      });
    }
  }
  

}
