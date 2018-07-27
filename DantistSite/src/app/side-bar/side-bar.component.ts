import { Component } from '@angular/core';

import { MenuItem } from 'primeng/api';

@Component({
  selector: 'side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent {
  items: MenuItem[] = [
    {
      label: 'Home',
      icon: 'fa fa-file-o',
      routerLink: '/home'
    },
        {
      label: 'Profile',
      icon: 'fa fa-gear',
      routerLink: '/profile'
    },

];
}
