import { Component } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { Booking, Status } from '../../model/booking';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { EventmodelService } from '../../services/eventmodel.service'; // ✅ Import Event Service
import { Observable } from 'rxjs'; // ✅ Import Observable
import { Eventmodel } from '../../model/eventmodel';

@Component({
  selector: 'app-addbooking',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './addbooking.component.html',
  styleUrl: './addbooking.component.css'
})
export class AddbookingComponent {
  seatNumberInput: string = "";
  eventsList$: Observable<Eventmodel[]>; // ✅ Observable instead of array
  username: string | null = '';

  newBooking: Booking = {
    userId: undefined,
    eventId: undefined,
    seatNumber: [],
    bookingDate: new Date(),
    status: Status.Pending
  };

  constructor(
    private bookingService: BookingService,
    private eventService: EventmodelService, // ✅ Inject Event Service
    private router: Router
  ) {
    this.eventsList$ = this.eventService.getAllEvents(); // ✅ Assign service call directly to Observable
  }


  ngOnInit(): void {
    const userData = localStorage.getItem('user');
    if (userData) {
      this.username = JSON.parse(userData).username; // ✅ Extract username from stored object
    }
  }

  addBookings(): void {
    this.newBooking.seatNumber = this.seatNumberInput
      .split(',')
      .map(num => parseInt(num.trim(), 10))
      .filter(num => !isNaN(num));

    this.bookingService.addBookings(this.newBooking).subscribe({
      next: (res) => {
        console.log('Booking Added:', res);

        Swal.fire({
          title: 'Success!',
          text: `Booking for Event ID ${this.newBooking.eventId} has been added successfully.`,
          icon: 'success',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/getallbookings']);
        });

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
        let errorMessage = 'An error occurred while adding the booking. Please try again.';
        if (err.error && err.error.message) {
          errorMessage = err.error.message;
        }
        Swal.fire({
          title: 'Booking Failed!',
          text: errorMessage,
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    });
  }
}
