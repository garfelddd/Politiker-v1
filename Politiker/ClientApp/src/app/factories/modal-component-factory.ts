import { ComponentFactoryResolver, Injector, ViewContainerRef, TemplateRef, ComponentRef, Injectable, ComponentFactory, Type } from "@angular/core";
import { Observable, Subscription, Subject } from "rxjs";
import { ModalState } from "../states/modal-state";
import { takeUntil } from "rxjs/operators";

@Injectable({
  providedIn: 'root',
})
export class ModalComponentFactory {
  public result$: Subject<any>;

  //public result: Observable<any> = this.result$.asObservable();
  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private injector: Injector,
    private modalState: ModalState
  ) { }


  openInstance<C>(comp: Type<C>): C {
    this.result$ = new Subject<any>();
    this.result$.pipe(takeUntil(this.result$));
    let componentRef = this.componentFactoryResolver
      .resolveComponentFactory(comp);

    const componentView = this.modalState.vcr.createComponent(componentRef, null, this.injector);

    return componentView.instance;
  }

  cancel() {

    this.result$.thrownError;
    this.result$ = null;
    this.modalState.vcr.clear();
  }

  ok() {
    this.result$.complete();
    this.result$ = null;
    this.modalState.vcr.clear();
  }

}
