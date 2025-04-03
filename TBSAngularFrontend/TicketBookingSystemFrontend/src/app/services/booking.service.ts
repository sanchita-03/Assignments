import { inject, Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Booking, Status } from '../model/booking';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private http = inject(HttpClient)
  private apiUrl = "https://localhost:7229/api/Booking";
  
  // constructor(private http: HttpClient) { 
    
  // }
  getAllBookings():Observable<Booking[]>{
    return this.http.get<Booking[]>(`${this.apiUrl}`).pipe(
      map(bookings => bookings.map(booking => ({
        ...booking,
        // status: Status[booking.status as keyof typeof Status].toString() || 'Unknown',
        // status: booking.status.toString() || 'Unknown',
      })))
    );
  }

  //add bookings
  addBookings(booking : Booking):Observable<Booking>{
    return this.http.post<Booking>(`${this.apiUrl}`,booking)
  }

  cancelBooking(bookingId: number): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/cancelBooking/${bookingId}`, {});
  }
 // https://localhost:7229/api/Booking/cancelBooking/
  getBookingById(bookingId:number):Observable<Booking>{
    return this.http.get<Booking>(`${this.apiUrl}/${bookingId}`)
  }

  updateBooking(booking : Booking):Observable<Booking>{
    return this.http.put<Booking>(`${this.apiUrl}`,booking)
  }


  getAvailableSeats(eventId: number): Observable<number[]> {
    return this.http.get<number[]>(`${this.apiUrl}/available-seats/${eventId}`);
  }
}
