import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookingService } from '../../services/booking.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';  // ✅ Import SweetAlert

@Component({
  selector: 'app-cancel-booking',
  imports: [FormsModule, CommonModule],
  standalone: true,
  templateUrl: './cancelbooking.component.html',
  styleUrl: './cancelbooking.component.css'
})
export class CancelBookingComponent implements OnInit {
  bookingId!: number; // ✅ Holds the booking ID from URL
  isLoading = false;  // ✅ Loading state

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private bookingService: BookingService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.bookingId = Number(id); // ✅ Get ID from URL
    } else {
      console.error("Booking ID is missing in the URL");
    }
  }

  cancelBooking(): void {
    if (!this.bookingId) {
      Swal.fire({
        icon: 'warning',
        title: 'Invalid Booking ID',
        text: 'Please enter a valid booking ID!',
      });
      return;
    }

    Swal.fire({
      title: 'Are you sure?',
      text: "Do you really want to cancel this booking?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      cancelButtonColor: '#3085d6',
      confirmButtonText: 'Yes, Cancel it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.isLoading = true; // ✅ Start loading
        this.bookingService.cancelBooking(this.bookingId).subscribe({
          next: () => {
            Swal.fire({
              icon: 'success',
              title: 'Booking Cancelled',
              text: 'Your booking has been cancelled successfully!',
            }).then(() => {
              this.router.navigate(['/getallbookings']); // ✅ Redirect after confirmation
            });
          },
          error: (err) => {
            console.error("Failed to cancel booking:", err);
            Swal.fire({
              icon: 'error',
              title: 'Failed to Cancel',
              text: 'An error occurred. Please try again later.',
            });
          },
          complete: () => {
            this.isLoading = false; // ✅ Stop loading
          }
        });
      }
    });
  }
}
