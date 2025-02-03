import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealPlanIconComponent } from './meal-plan-icon.component';

describe('MealPlanIconComponent', () => {
  let component: MealPlanIconComponent;
  let fixture: ComponentFixture<MealPlanIconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MealPlanIconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MealPlanIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
