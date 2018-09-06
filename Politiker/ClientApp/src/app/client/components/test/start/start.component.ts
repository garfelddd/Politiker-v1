import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { RegionService } from '../../../../services/region.service';
import { RegionModel } from '../../../../models/region.model';
import { Observable } from "rxjs/index";
import { Poll  } from '../../../../models/poll.model';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.scss']
})
export class StartComponent implements OnInit {
  regions: string[] = [];
  dataPoll: Poll = new Poll();
  @Output() returnedData = new EventEmitter<Poll>();

  constructor(private _regionService: RegionService) { }

  ngOnInit() {
    this._regionService.getRegionsByName("Polska")
      .subscribe(data => this.dataPoll.Regions = data);
  }
  selectRegion(value: string) {
    this.dataPoll.Region = value;
  }
  selectAge(value: string) {
    this.dataPoll.Age = value;
  }
  next() {
    console.log(this.dataPoll);
    this.returnedData.emit(this.dataPoll);
  }

}
