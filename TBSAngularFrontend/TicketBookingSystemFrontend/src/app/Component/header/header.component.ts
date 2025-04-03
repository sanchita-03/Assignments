import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],  // ✅ Added RouterModule
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent  {
  // isLoggedIn: boolean = false;
  username: string | null = '';

  constructor(private router: Router,public userservice:UserService) {}



  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
