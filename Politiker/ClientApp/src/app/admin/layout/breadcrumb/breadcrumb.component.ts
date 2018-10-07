import { Component, OnInit } from '@angular/core';
import { BreadcrumbModel } from './breadcrumb-model';
import { NavigationEnd, ActivatedRoute, Router, UrlTree, PRIMARY_OUTLET, RouteConfigLoadEnd, NavigationStart } from '@angular/router';
import { filter, distinctUntilChanged, map, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent implements OnInit {
  breadcrumbs: BreadcrumbModel[] = [];
  breadcrumbRoute$ = this.router.events
    .pipe(
    filter(event => event instanceof NavigationEnd),
    map(() => {
      return this.route.root;
    }),
    map(root => {
      this.breadcrumbs = this.getBreadcrumbs(this.route.root);
      console.log(root);
    })
  )
    .subscribe(data => console.log(data));
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

  }

  getBreadcrumbs(route: ActivatedRoute, url: string = "/admin", breadcrumbs: BreadcrumbModel[] = []) {
    const CHILD_DATA_TITLE = 'title';

    let label = route.snapshot.data && route.snapshot.data[CHILD_DATA_TITLE] ? route.snapshot.data[CHILD_DATA_TITLE] : '';

    const path = route.routeConfig ? route.routeConfig.path : '';
    const nextUrl = path ? `${url}${path}/` : '';

    let breadcrumb = null;
    if (label && path) {

      breadcrumb = {
        Label: label,
        Segment: nextUrl
      };
    }
      const newBreadcrumbs = breadcrumb ? [...breadcrumbs, breadcrumb] : breadcrumbs;

    if (route.firstChild) {

      return this.getBreadcrumbs(route.firstChild, nextUrl, newBreadcrumbs);
    }
    return newBreadcrumbs;
    }

  }
