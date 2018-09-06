import { Injectable } from '@angular/core';
import { RegionModel } from "../models/region.model";
import { Observable } from "rxjs/index";
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  baseUrl: string = '/api/region/';
  constructor(private http: HttpClient) { }

  getRegionsById(id: number): Observable<RegionModel[]>{
    return this.http.get<RegionModel[]>(this.baseUrl + id);
  }
  getRegionsByName(name: string): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + "getbyname/" + name);
  }
}
