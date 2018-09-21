import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavItemHeadComponent } from './nav-item-head.component';

describe('NavItemHeadComponent', () => {
  let component: NavItemHeadComponent;
  let fixture: ComponentFixture<NavItemHeadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavItemHeadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavItemHeadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
