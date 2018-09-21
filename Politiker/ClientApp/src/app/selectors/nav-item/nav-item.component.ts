import { Component, OnInit, Input, Output, EventEmitter, ContentChild } from '@angular/core';
import { NavItemBodyComponent } from './nav-item-body.component';

@Component({
  selector: 'nav-item',
  templateUrl: './nav-item.component.html',
  styleUrls: ['./nav-item.component.scss']
})
export class NavItemComponent implements OnInit {

  collapsed: boolean = false;
  @ContentChild(NavItemBodyComponent) body: NavItemBodyComponent;

  constructor() { }

  ngOnInit() {
    this.body.toggle(this.collapsed);
  }

  toggle() {
    this.collapsed = !this.collapsed;
    this.body.toggle(this.collapsed);
  }

}
