import { Routes } from '@angular/router';
import { Login } from './model/login';
import { LoginComponent } from './Component/login/login.component';
import { RegisterComponent } from './Component/register/register.component';
import { BookingComponent } from './Component/booking/booking.component';
import { AddbookingComponent } from './Component/addbooking/addbooking.component';
import { UpdatebookingComponent } from './Component/updatebooking/updatebooking.component';
import { CancelBookingComponent } from './Component/cancelbooking/cancelbooking.component';
import { WelcomedashboardComponent } from './Component/welcomedashboard/welcomedashboard.component';
import { HeaderComponent } from './Component/header/header.component';
import { GetalleventsComponent } from './Component/getallevents/getallevents.component';

export const routes: Routes = [
    {path:"login",component:LoginComponent},
    {path:"register",component:RegisterComponent},
    {path:"getallbookings",component:BookingComponent},
    {path:"addbooking",component:AddbookingComponent},
    {path:"updatebooking",component:UpdatebookingComponent},
    { path: '',component:WelcomedashboardComponent},
    {path:'welcomedashboard',component:WelcomedashboardComponent},
    { path: 'cancel-booking/:id', component: CancelBookingComponent },
    {path:'getallevents',component:GetalleventsComponent}
];
