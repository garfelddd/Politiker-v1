import { Component, OnInit, HostListener } from '@angular/core';
import { NavItemComponent } from './nav-item.component';

@Component({
  selector: 'nav-item-head',
  templateUrl: './nav-item-head.component.html',
  styleUrls: ['./nav-item-head.component.scss']
})
export class NavItemHeadComponent implements OnInit {

  @HostListener('click', ['$event.target'])
  onClick(target) {
    this.toggle();
  }

  constructor(private navItem: NavItemComponent) { }

  ngOnInit() {
  }

  toggle() {
    this.navItem.toggle();
  }
}
