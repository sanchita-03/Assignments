import { Component } from '@angular/core';
import { AuthResponse, Login } from '../../model/login';
import { UserService } from '../../services/user.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2'; // Import SweetAlert2

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginModel: Login = new Login('', '');
  errorMsg = '';

  constructor(private userService: UserService) {}

  loginUser(loginForm: NgForm) {
    this.loginModel = loginForm.value;
    console.log(this.loginModel);

    this.userService.login(this.loginModel).subscribe({
      next: (response: AuthResponse) => {
        console.log('Login success', response);
        localStorage.setItem('token', response.token);

        // 🎉 Success Alert
        Swal.fire({
          icon: 'success',
          title: 'Login Successful',
          text: 'Welcome to the Ticket Booking System!',
          showConfirmButton: false,
          timer: 2000
        });

        loginForm.reset();
      },
      error: (error) => {
        console.error('Login failed', error);
        this.errorMsg = "Invalid Email or Password";

        // ❌ Error Alert
        Swal.fire({
          icon: 'error',
          title: 'Login Failed',
          text: 'Invalid Email or Password. Please try again!',
        });
      }
    });
  }
}
