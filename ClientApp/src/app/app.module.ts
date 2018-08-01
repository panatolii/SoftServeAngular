import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppHeadmenuComponent } from './Presentation/app-headmenu/app-headmenu.component';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { AppHomeComponent } from './Presentation/Pages/app-home/app-home.component';
import { AppProfileComponent } from './Presentation/Pages/app-profile/app-profile.component';
 import { RouterModule, Routes } from '@angular/router';
import { AppDoctorListComponent } from './Presentation/pages/Doctors/app-doctor-list/app-doctor-list.component';
import {TableModule} from 'primeng/table';
import { DataTableModule } from 'primeng/primeng';
import { DataGridModule } from 'primeng/primeng';
import {PanelModule} from 'primeng/panel';

import { EntityBase } from './Models/entity-base';
import {ApiService, ApiProvider, DbProvider, Service } from './Services/Index';
import { HttpClient, HttpClientModule, HttpResponse, HttpParams } from '@angular/common/http';
import { FormsModule } from '../../node_modules/@angular/forms';
import {CardModule} from 'primeng/card';
import {GrowlModule, Message} from 'primeng/primeng';
import {DialogModule} from 'primeng/dialog';
import { OAuthModule } from 'angular-oauth2-oidc';

import { routes } from './app.routes';
import { AppDoctorDetailsComponent } from './Presentation/Pages/Doctors/app-doctor-details/app-doctor-details.component';
import {AppLoginComponent} from './Presentation/Pages/app-login/app-login.component';
import {ToastModule} from 'primeng/toast';
import {MessagesModule} from 'primeng/messages';
import {MessageModule} from 'primeng/message';


@NgModule({
  declarations: [
    AppComponent,
    AppHeadmenuComponent,
    AppHomeComponent,
    AppProfileComponent,
    AppDoctorListComponent,
    AppDoctorDetailsComponent,
    AppLoginComponent



  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MenubarModule,
    TableModule,
    ButtonModule,
    CardModule,
    GrowlModule,
    DataGridModule,
    PanelModule,
    DataTableModule,
    InputTextModule,
    DialogModule,
    RouterModule.forRoot (routes),
    OAuthModule.forRoot(),
    ToastModule,MessagesModule,MessageModule
  ],
  providers: [ {provide: ApiProvider, useClass: DbProvider}, ToastModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
