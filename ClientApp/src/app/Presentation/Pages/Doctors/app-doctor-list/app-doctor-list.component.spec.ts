import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppDoctorListComponent } from './app-doctor-list.component';

describe('AppDoctorListComponent', () => {
  let component: AppDoctorListComponent;
  let fixture: ComponentFixture<AppDoctorListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppDoctorListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppDoctorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
