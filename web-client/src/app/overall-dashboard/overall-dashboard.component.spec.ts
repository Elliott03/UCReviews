import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OverallDashboardComponent } from './overall-dashboard.component';

describe('OverallDashboardComponent', () => {
  let component: OverallDashboardComponent;
  let fixture: ComponentFixture<OverallDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OverallDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OverallDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
