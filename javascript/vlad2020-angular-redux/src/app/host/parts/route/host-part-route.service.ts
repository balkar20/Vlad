// //Author Vlad Balkarov//vlad//

import {Injectable} from '@angular/core';
import {ActivatedRoute, ActivatedRouteSnapshot, Event, NavigationEnd, Router} from '@angular/router';
import {Observable, of, Subject} from 'rxjs';
import {filter, map, switchMap, takeUntil} from 'rxjs/operators';
import {AppHostPartRouteData, appHostPartRouteDataCreate} from './host-part-route-data';
import {AppHostPartRouteDataPage} from '@app/host/parts/route/data/host-part-route-data-page';

/** Хост. Часть "Route". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartRouteService {

  /**
   * Конструктор.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private extRouter: Router
  ) {
    this.onNavigationEnd = this.onNavigationEnd.bind(this);
  }

  /**
   * Получить ключ страницы.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns Observable<string> Ключ страницы.
   */
  getPageKey$(extRoute: ActivatedRoute, unsubscribe$: Subject<boolean>) {
    return extRoute.data.pipe(
      filter(routeData => !!routeData.page),
      map(routeData => routeData.page.key),
      takeUntil(unsubscribe$)
    );
  }

  /**
   * Получить поток данных.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppHostPartRouteData>} Поток данных.
   */
  getData$(unsubscribe$: Subject<boolean>): Observable<AppHostPartRouteData> {
    return this.extRouter.events.pipe(
      filter(event => event instanceof NavigationEnd),
      switchMap(this.onNavigationEnd),
      takeUntil(unsubscribe$)
    );
  }

  /**
   * @param {Event} event
   * @returns {Observable<AppHostPartRouteData>}
   */
  private onNavigationEnd(event: Event): Observable<AppHostPartRouteData> {
    let routeData: AppHostPartRouteData;

    if (event instanceof NavigationEnd) {
      routeData = appHostPartRouteDataCreate();

      this.fillRouteData(routeData, this.extRouter.routerState.snapshot.root);
    }

    return of(routeData);
  }

  /**
   * @param {AppHostPartRouteData} routeData
   * @param {ActivatedRouteSnapshot} route
   */
  private fillRouteData(routeData: AppHostPartRouteData, route: ActivatedRouteSnapshot) {
    if (route.children.length > 0) {
      route.children.forEach(child => {
        this.fillRouteData(routeData, child);
      });
    } else {
      const page = route.data.page;

      if (page) {
        routeData.page = <AppHostPartRouteDataPage>page;
      }
    }
  }
}
