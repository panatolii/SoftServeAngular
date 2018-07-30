import { Component } from '@angular/core';

import { MenuItem } from 'primeng/api';

@Component({
  selector: 'presentation/app-headmenu',
  templateUrl: './app-headmenu.component.html',
  styleUrls: ['./app-headmenu.component.css']
})
export class AppHeadmenuComponent {
  items: MenuItem[] = [
    {
      label: 'Home',
      icon: 'fa fa-home',
      routerLink: 'home'
    },
    {
      label: 'Edit',
      icon: 'fa fa-cog',
      routerLink: 'profile'
    },
    {
      label: 'Doctors',
      icon: 'fa fa-user-md',
      routerLink: 'doctors'
    }
];
}
