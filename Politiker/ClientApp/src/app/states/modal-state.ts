import { Injectable, ViewContainerRef } from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class ModalState {
  public vcr: ViewContainerRef;
}
