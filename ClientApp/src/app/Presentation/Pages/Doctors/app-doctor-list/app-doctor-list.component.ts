import { Component, OnInit } from '@angular/core';
import { Doctor } from '../../../../Models/doctor';
import {Service, DbProvider, ApiProvider, ApiService, ApiTestServiceService} from '../../../../Services/Index';
import { EntityBase } from '../../../../Models/entity-base';

@Component({
  selector: 'app-app-doctor-list',
  templateUrl: './app-doctor-list.component.html',
  styleUrls: ['./app-doctor-list.component.css'],
  providers: [ApiTestServiceService,
    {provide: Service, useClass: ApiService},
    {provide: ApiProvider, useClass: DbProvider}
  ]

})
export class AppDoctorListComponent implements OnInit {

  strn: string;
  doctors: Doctor[];
  constructor(private service: Service<Doctor>) {
    this.doctors = new Array();
   }

  ngOnInit() {
    console.log('Oninit AppDoctorListComponent');
    this.service.url = 'doctor';
     this.service.list().then((items: Doctor []) => {
      items.forEach(i => {
      this.doctors.push(new Doctor(i));
      });
      // this.doctors = d;
    });

  }

}
