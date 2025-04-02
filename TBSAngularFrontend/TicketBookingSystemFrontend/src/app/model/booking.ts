export class Booking {
    bookingId?: number;
    userId?: number;
    eventId?: number;
    seatNumber?: number[];  
    bookingDate?: Date;      
    status?: Status;    
}

export enum Status {
    Pending = 1,
    Confirmed =2,
    Cancelled = 3
}
// public int BookingId { get; set; }
// [Required]
// public int UserId { get; set; }
// [JsonIgnore]
// public User? User { get; set; }
// [Required]
// public int EventId { get; set; }
// [JsonIgnore]
// public Event? Event { get; set; }
// [Required]
// public List<int> SeatNumber { get; set; } = new List<int>();
// [Required]
// public DateTime BookingDate { get; set; } = DateTime.Now;
// [Required]
// public Status Status { get; set; } = Status.Pending;
// [JsonIgnore]
// public Payment? Payment { get; set; }