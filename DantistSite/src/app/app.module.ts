import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppHomeComponent } from './pages/app-home/app-home.component';
import { AppProfileComponent } from './pages/app-profile/app-profile.component';
import { RouterModule } from "@angular/router";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SideBarComponent } from './side-bar/side-bar.component';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';


@NgModule({
  declarations: [
    AppComponent,
    AppHomeComponent,
    AppProfileComponent,
    SideBarComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MenubarModule,
    ButtonModule,
    InputTextModule,
    RouterModule.forRoot([
            {path: 'home', component: AppHomeComponent },
            {path: 'profile', component: AppProfileComponent },
            {path: '', redirectTo: 'home', pathMatch: 'full'},

    ])
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
