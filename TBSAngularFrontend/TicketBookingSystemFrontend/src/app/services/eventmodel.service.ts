import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Eventmodel } from '../model/eventmodel';

@Injectable({
  providedIn: 'root'
})
export class EventmodelService {
    private http = inject(HttpClient);
    private apiUrl = "https://localhost:7229/api/EventModel";
  
    getAllEvents():Observable<Eventmodel[]>{
      return this.http.get<Eventmodel[]>(`${this.apiUrl}`)
    }
  }

  