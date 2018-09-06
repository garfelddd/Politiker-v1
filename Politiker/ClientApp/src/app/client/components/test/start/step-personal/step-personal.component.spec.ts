import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StepPersonalComponent } from './step-personal.component';

describe('StepPersonalComponent', () => {
  let component: StepPersonalComponent;
  let fixture: ComponentFixture<StepPersonalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StepPersonalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StepPersonalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
