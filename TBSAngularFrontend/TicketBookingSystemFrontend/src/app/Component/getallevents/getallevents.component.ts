import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Eventmodel, EventType } from '../../model/eventmodel';
import { EventmodelService } from '../../services/eventmodel.service';

@Component({
  selector: 'app-getallevents',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './getallevents.component.html',
  styleUrl: './getallevents.component.css'
})
export class GetalleventsComponent implements OnInit {
  eventmodel: Eventmodel[] = [];

  constructor(private eventServiceModel: EventmodelService) {}

  ngOnInit(): void {
    this.getAllEvents();
  }
  getAllEvents() {
    this.eventServiceModel.getAllEvents().subscribe({
      next: (data) => {
        console.log("API Response:", data);
        this.eventmodel = data;
      },
      error: (err) => console.error("Error fetching events:", err)
    });
  }

  getStatusText(eventType: EventType | undefined): string {
      if (eventType=== undefined) return "Unknown";
      return EventType[eventType];
    }
}
