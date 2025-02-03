import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiningCategoryIconComponent } from './dining-category-icon.component';

describe('DiningCategoryIconComponent', () => {
  let component: DiningCategoryIconComponent;
  let fixture: ComponentFixture<DiningCategoryIconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DiningCategoryIconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DiningCategoryIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
