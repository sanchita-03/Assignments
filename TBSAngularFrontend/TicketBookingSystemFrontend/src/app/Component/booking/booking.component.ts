import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from '../../services/booking.service';
import { Booking, Status } from '../../model/booking';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-booking',
  imports:[FormsModule,CommonModule],
  standalone:true,
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})
export class BookingComponent implements OnInit {
  bookings: Booking[] = [];
  StatusEnum = Status; // ✅ Expose Enum to HTML

  constructor(private bookingService: BookingService, private router: Router) {}

  ngOnInit(): void {
    this.fetchBookings();
  }

  fetchBookings(): void {
    this.bookingService.getAllBookings().subscribe({
      next: (res) => {
        this.bookings = res.map(b => ({
          bookingId: b.bookingId || 0,  // ✅ Ensure bookingId is set
          userId: b.userId,
          eventId: b.eventId,
          seatNumber: b.seatNumber,
          status: b.status,
          bookingDate: b.bookingDate
        }));
      },
      error: (err) => {
        console.error("Error fetching bookings:", err);
      }
    });
  }

  navigateToCancelBooking(bookingId?: number): void {
    if (!bookingId) {
      console.warn("Invalid booking ID");
      return;
    }
    this.router.navigate(['/cancel-booking', bookingId]); // ✅ Navigate with ID
  }

  getStatusText(status: Status | undefined): string {
    if (status === undefined) return "Unknown";
    return Status[status];
  }
}
