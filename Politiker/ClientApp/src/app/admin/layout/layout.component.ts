import { Component, OnInit, ContentChild, ViewContainerRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ModalState } from '../../states/modal-state';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  providers: [ModalState]
})
export class LayoutComponent implements OnInit {
  @ViewChild('modal', { read: ViewContainerRef }) modalSection: ViewContainerRef;
  constructor(private modalState: ModalState) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.modalState.vcr = this.modalSection;
  }
}
