import { Routes } from '@angular/router';
import { AppHomeComponent } from './Presentation/Pages/app-home/app-home.component';
import { AppProfileComponent } from './Presentation/Pages/app-profile/app-profile.component';
import { AppDoctorListComponent } from './Presentation/pages/Doctors/app-doctor-list/app-doctor-list.component';

import { AppDoctorDetailsComponent } from './Presentation/Pages/Doctors/app-doctor-details/app-doctor-details.component';

export const routes: Routes = [
  { path: 'home' , component: AppHomeComponent },
  { path: 'profile' , component: AppProfileComponent },
  { path: 'doctors' , component: AppDoctorListComponent },

  { path: 'details' , component: AppDoctorDetailsComponent },
  { path: '' , redirectTo: 'home' , pathMatch: 'full' }
];
