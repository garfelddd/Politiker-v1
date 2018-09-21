import { Component, OnInit, HostBinding } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';

@Component({
  selector: 'nav-item-body',
  templateUrl: './nav-item-body.component.html',
  styleUrls: ['./nav-item-body.component.scss'],
  animations: [
    trigger('toggle', [
      state('open', style({

      })),
      state('closed', style({
        height: '0px',
      })),
      transition('open => closed', [
        animate('0.6s ease-in-out')
      ]),
      transition('closed => open', [
        animate('0.6s ease-in-out')
      ]),
    ]),
  ],
})
export class NavItemBodyComponent implements OnInit {
  state: boolean = false;
  constructor() { }

  ngOnInit() {
  }
  toggle(state: boolean) {
    /*if (state === false) {
      this.display = '0px';
    }
    else {
      this.display = 'auto';
    }*/
    this.state = state;
  }

}
