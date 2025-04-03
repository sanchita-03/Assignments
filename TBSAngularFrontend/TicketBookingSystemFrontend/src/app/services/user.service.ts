import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthResponse, Login } from '../model/login';
import { Register, RegistrationResponse } from '../model/register';

@Injectable({
  providedIn: 'root'
})
export class UserService {
//https://localhost:7229/api/Auth/login
private apiUrl = "https://localhost:7229/api/Auth";
  constructor(private http:HttpClient) { }

  login(loginData:Login):Observable<AuthResponse>{
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`,loginData)
  }

  register(registerData:Register):Observable<RegistrationResponse>{
    return this.http.post<RegistrationResponse>(`${this.apiUrl}/register`,registerData)
    }

    isLoggedIn():boolean{
        return !!localStorage.getItem('token');
      }
    
}
