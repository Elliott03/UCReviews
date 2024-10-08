import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DormDashboardComponent } from './dorm-dashboard.component';

describe('DashboardComponent', () => {
  let component: DormDashboardComponent;
  let fixture: ComponentFixture<DormDashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DormDashboardComponent]
    });
    fixture = TestBed.createComponent(DormDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
