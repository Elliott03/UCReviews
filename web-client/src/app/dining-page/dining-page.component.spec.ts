import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiningPageComponent } from './dining-page.component';

describe('DiningPageComponent', () => {
  let component: DiningPageComponent;
  let fixture: ComponentFixture<DiningPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DiningPageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(DiningPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
