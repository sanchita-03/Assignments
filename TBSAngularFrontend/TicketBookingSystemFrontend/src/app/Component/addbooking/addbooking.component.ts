import { Component } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { Booking, Status } from '../../model/booking';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';  // ✅ Import SweetAlert2
import { Router } from '@angular/router';

@Component({
  selector: 'app-addbooking',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './addbooking.component.html',
  styleUrl: './addbooking.component.css'
})
export class AddbookingComponent {
  bookings: Booking[] = [];
  seatNumberInput: string = "";

  newBooking: Booking = {
    userId: undefined,
    eventId: undefined,
    seatNumber: [],
    bookingDate: new Date(),  // Default to current date
    status: Status.Pending     // Default to "Pending"
  };

  constructor(private bookingService: BookingService, private router: Router) {}

  addBookings(): void {
    this.newBooking.seatNumber = this.seatNumberInput
      .split(',')
      .map(num => parseInt(num.trim(), 10))
      .filter(num => !isNaN(num));

    this.bookingService.addBookings(this.newBooking).subscribe({
      next: (res) => {
        console.log('Booking Added:', res);
        this.bookings.push(res);

        // ✅ Success Alert
        Swal.fire({
          title: 'Success!',
          text: `Booking for Event ID ${this.newBooking.eventId} has been added successfully.`,
          icon: 'success',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/getallbookings']); // ✅ Navigate to Get All Bookings page
        });;

        // Reset form after submission
        this.newBooking = {
          userId: undefined,
          eventId: undefined,
          seatNumber: [],
          bookingDate: new Date(),
          status: Status.Pending
        };
        this.seatNumberInput = "";
      },
      error: (err) => {
        console.error('Booking Failed:', err);

        // ❌ Error Alert
        Swal.fire({
          title: 'Booking Failed!',
          text: 'An error occurred while adding the booking. Please try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    });
  }
}
