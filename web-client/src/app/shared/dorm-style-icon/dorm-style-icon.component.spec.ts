import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DormStyleIconComponent } from './dorm-style-icon.component';

describe('DormStyleIconComponent', () => {
  let component: DormStyleIconComponent;
  let fixture: ComponentFixture<DormStyleIconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DormStyleIconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DormStyleIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
