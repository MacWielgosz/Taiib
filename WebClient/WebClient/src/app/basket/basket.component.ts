import { Component } from '@angular/core';
import { BasketService } from '../basket.service';
import { Router } from '@angular/router';
import { BasketPositionDTO } from '../model/BasketPositionDTO.interface';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent {
makeOrder() :void {
    this.service.makeOrder().subscribe(() => {
      this.router.navigate(['/orders']); // Przekierowanie do listy produktów
    });
  }
  displayedColumns: string[] = ['id','productID', 'amount',  'userID', 'delete'];
  public data: BasketPositionDTO[] = [];

  constructor(private service: BasketService, private router: Router) {
    this.getOrders();
  }

  private getOrders(): void {
    this.service.getBasketsByUserId((window as any).globalUserId).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  deletePosition(id: number): void {
    this.service.deleteBasketPosition(id).subscribe({
      next: () => {
        console.log('Pozycja koszyka usunięta pomyślnie');
        this.getOrders();
      },
      error: (err) => console.error('Błąd podczas usuwania pozycji koszyka', err)
    });
  }

  updatePosition(position: BasketPositionDTO): void {
    this.service.updateBasketPosition(position.id,position.amount).subscribe({
      next: () => {
        console.log('Ilość produktu w koszyku zaktualizowana pomyślnie');
      },
      error: (err) => console.error('Błąd podczas aktualizacji ilości produktu w koszyku', err)
    });
  }
}
