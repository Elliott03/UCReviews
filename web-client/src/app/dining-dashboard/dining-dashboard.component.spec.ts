import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiningDashboardComponent } from './dining-dashboard.component';

describe('DiningDashboardComponent', () => {
  let component: DiningDashboardComponent;
  let fixture: ComponentFixture<DiningDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DiningDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DiningDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
