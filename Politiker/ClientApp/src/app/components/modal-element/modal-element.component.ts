import { Component, OnInit, TemplateRef, Input, ViewChild, ViewContainerRef } from '@angular/core';
import { ModalComponentFactory } from '../../factories/modal-component-factory';

@Component({
  selector: 'app-modal-element',
  templateUrl: './modal-element.component.html',
  styleUrls: ['./modal-element.component.scss']
})
export class ModalElementComponent implements OnInit {

  @ViewChild('body', { read: ViewContainerRef }) private vcr: ViewContainerRef; 
  @Input() body: TemplateRef<any>;
  @Input() title: string = 'Potwierdzenie akcji';
  @Input() okTitle: string = 'Potwierdz';
  @Input() cancelTitle: string = 'Anuluj';
  constructor(private factory: ModalComponentFactory) { }

  ngOnInit() {

  }

  ngAfterViewInit() {
    if(this.body)
      this.vcr.createEmbeddedView(this.body);
  }

  onOk() {
    this.factory.ok();
  }

  onCancel() {
    this.factory.cancel();
  }
}
