import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GaragePageComponent } from './garage-page.component';

describe('GaragePageComponent', () => {
  let component: GaragePageComponent;
  let fixture: ComponentFixture<GaragePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GaragePageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(GaragePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
