export class Eventmodel {
        eventId? : number;
        eventName? : string;
        description? : string;
        date? : Date;
        venue? : string;
        totalSeats? : number;
        availableSeats? : number;
        price? : number;
        eventType? : EventType
    }
    
    export enum EventType{
        Concert=1,
        Movie=2,
        Sports=3,
        Conference=4,
        Theatre=5,
        Exhibition=6
    }
    
    // public int EventId { get; set; }
    // [Required]
    // public string EventName { get; set; }
    // [Required]
    // public string Description { get; set; }
    // [Required]
    // public DateTime Date { get; set; }
    // [Required]
    // public string Venue { get; set; }
    // [Required]
    // public int TotalSeats { get; set; }
    // [Required]
    // public int AvailableSeats { get; set; }
    // [Required]
    // public decimal Price { get; set; }
    // [Required]
    // public EventType EventType { get; set; }
    // public ICollection<Booking>? Bookings { get; set; }
