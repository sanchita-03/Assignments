import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-welcomedashboard',
  standalone: true,
  imports: [],
  templateUrl: './welcomedashboard.component.html',
  styleUrl: './welcomedashboard.component.css'
})
export class WelcomedashboardComponent {
  constructor(private router: Router) {}

  navigateToAddBooking() {
    this.router.navigate(['/addbooking']);
  }
}

