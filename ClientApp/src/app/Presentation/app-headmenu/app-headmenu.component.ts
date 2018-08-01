import { Component, ViewChild } from "@angular/core";

import { MenuItem } from 'primeng/api';
import {  EventEmitter, Input, Output } from '@angular/core';
import {AppLoginComponent} from '../Pages/app-login/app-login.component';

import {MessageService} from 'primeng/api';
import {Message} from 'primeng//api';


@Component({
  selector: 'presentation/app-headmenu',
  templateUrl: './app-headmenu.component.html',
  styleUrls: ['./app-headmenu.component.css']
})
export class AppHeadmenuComponent {
  constructor( ) {}
  @Output()
  login = new EventEmitter();
  @ViewChild(AppLoginComponent)
  loginCom: AppLoginComponent;
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

onClick() {
  console.log("onClick");
  this.loginCom.showDialog();
}

}
