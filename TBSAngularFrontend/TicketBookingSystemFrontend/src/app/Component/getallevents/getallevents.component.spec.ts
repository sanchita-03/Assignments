import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetalleventsComponent } from './getallevents.component';

describe('GetalleventsComponent', () => {
  let component: GetalleventsComponent;
  let fixture: ComponentFixture<GetalleventsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetalleventsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetalleventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
