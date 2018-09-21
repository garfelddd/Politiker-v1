import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavItemBodyComponent } from './nav-item-body.component';

describe('NavItemBodyComponent', () => {
  let component: NavItemBodyComponent;
  let fixture: ComponentFixture<NavItemBodyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavItemBodyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavItemBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
