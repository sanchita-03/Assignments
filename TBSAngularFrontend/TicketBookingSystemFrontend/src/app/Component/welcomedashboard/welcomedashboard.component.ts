import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-welcomedashboard',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './welcomedashboard.component.html',
  styleUrl: './welcomedashboard.component.css'
})
export class WelcomedashboardComponent {
  constructor(private router: Router,public userservice:UserService) {}

  navigateToAddBooking() {
    this.router.navigate(['/addbooking']);
  }
}

