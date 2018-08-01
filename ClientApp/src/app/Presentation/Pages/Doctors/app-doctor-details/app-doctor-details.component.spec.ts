import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppDoctorDetailsComponent } from './app-doctor-details.component';

describe('AppDoctorDetailsComponent', () => {
  let component: AppDoctorDetailsComponent;
  let fixture: ComponentFixture<AppDoctorDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppDoctorDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppDoctorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
