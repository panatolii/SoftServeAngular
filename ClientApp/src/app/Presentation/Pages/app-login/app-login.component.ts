import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import {MessageService} from 'primeng/api';
import {Message} from 'primeng//api';

@Component({
  selector: 'app-app-login',
  templateUrl: './app-login.component.html',
  styleUrls: ['./app-login.component.css'],

})
export class AppLoginComponent implements OnInit {


  title = 'app';
  display = false;
  constructor( private oAuthService: OAuthService) {}

  showDialog() {
    this.display = true;
  }
  login() {
    console.log('try login...');
    this.oAuthService.tokenEndpoint  = 'http://localhost:35078/Token';
    this.oAuthService.setStorage(sessionStorage);
    this.oAuthService.fetchTokenUsingPasswordFlow('student@gmal.com', 'Uh4z312~@')
    .then((x: any) => {

        localStorage.setItem('id_token', x.id_token);
        this.oAuthService.setupAutomaticSilentRefresh();
        //this.us.navigate('');
        this.display = false;
        //this.messageService.add({severity: 'success', summary: 'Service Message', detail: 'Via MessageService'});
    })
    .catch();

  }
  ngOnInit() {
  }

}
