import { Component } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { Booking } from '../../model/booking';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-updatebooking',
  standalone: true,
  imports:[FormsModule,CommonModule],
  templateUrl: './updatebooking.component.html',
  styleUrl: './updatebooking.component.css'
})
export class UpdatebookingComponent {
  booking: Booking | null = null;
  bookingId: number | null = null;
  seatNumberInput: string = "";

  constructor(private bookingService: BookingService, private router: Router) {}

  // ✅ Fetch Booking Details
  fetchBooking(): void {
    if (!this.bookingId) {
      Swal.fire('Error!', 'Please enter a valid Booking ID.', 'error');
      return;
    }

    this.bookingService.getBookingById(this.bookingId).subscribe({
      next: (res) => {
        if (res) {
          this.booking = res;
          this.seatNumberInput = res.seatNumber ? res.seatNumber.join(", ") : "";
        } else {
          Swal.fire('Not Found!', 'Booking ID not found.', 'error');
        }
      },
      error: (err) => {
        console.error('Fetch Booking Error:', err);
        Swal.fire('Error!', 'Failed to fetch booking details.', 'error');
      }
    });
  }

  updateBooking(): void {
  if (!this.booking) {
    Swal.fire('Error!', 'No booking found to update.', 'error');
    return;
  }

  // ✅ Preserve existing values if no new input is given
  const updatedBooking: Booking = {
    ...this.booking, // 🔹 Retains existing properties
    userId: this.booking.userId || undefined,  // Keep original value if not updated
    eventId: this.booking.eventId || undefined,  // Keep original value if not updated
    seatNumber: this.seatNumberInput.split(",")
      .map(num => parseInt(num.trim(), 10))
      .filter(num => !isNaN(num))
  };

  this.bookingService.updateBooking(updatedBooking).subscribe({
    next: () => {
      Swal.fire({
        title: 'Updated!',
        text: 'Booking details updated successfully.',
        icon: 'success',
        confirmButtonText: 'OK'
      }).then(() => {
        this.router.navigate(['/getallbookings']); // ✅ Redirect after update
      });
    },
    error: (err) => {
      console.error('Update Booking Error:', err);
      Swal.fire('Error!', 'Failed to update booking.', 'error');
    }
  });
}

}
