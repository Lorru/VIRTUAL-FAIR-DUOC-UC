import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/services/user.service';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
    requiredProfile?: any;
}
export const ROUTES: RouteInfo[] = [
    { path: '/main/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    { path: '/main/user-list', title: 'Usuarios',  icon:'group', class: '', requiredProfile: [1] },
    { path: '/main/purchase-request', title: 'Solicitudes de Compra',  icon:'shopping_cart', class: '', requiredProfile: [6] },
    { path: '/main/sales-process', title: 'Procesos de Venta',  icon:'store', class: '', requiredProfile: [1, 3] },

    // { path: '/main/table-list', title: 'Table List',  icon:'content_paste', class: '' },
    // { path: '/main/typography', title: 'Typography',  icon:'library_books', class: '' },
    // { path: '/main/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
    // { path: '/main/maps', title: 'Maps',  icon:'location_on', class: '' },
    // { path: '/main/notifications', title: 'Notifications',  icon:'notifications', class: '' },
    { path: '/main/download-app', title: 'Aplicación de escritorio',  icon:'get_app', class: 'active-pro' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor(private _userService: UserService) {}

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
