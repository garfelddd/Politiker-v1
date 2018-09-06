import { Component, OnInit } from '@angular/core';
import { Poll } from '../../../../models/poll.model';

@Component({
  selector: 'app-manage-test',
  templateUrl: './manage-test.component.html',
  styleUrls: ['./manage-test.component.scss']
})
export class ManageTestComponent implements OnInit {

  dataPoll: Poll = null;
  constructor() { }

  ngOnInit() {
  }

  saveDataPoll(value) {
    this.dataPoll = value;
  }

}
