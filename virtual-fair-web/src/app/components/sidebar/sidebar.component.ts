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
    { path: '/main/dashboard', title: 'Inicio',  icon: 'home', class: '' },
    { path: '/main/user-list', title: 'Usuarios',  icon:'group', class: '', requiredProfile: [1] },
    { path: '/main/purchase-request', title: 'Compra de Productos',  icon:'shopping_cart', class: '', requiredProfile: [5, 6] },
    { path: '/main/sales-process', title: 'Procesos de Venta',  icon:'store', class: '', requiredProfile: [1, 3] },
    { path: '/main/contract-list', title: 'Contratos',  icon:'history_edu', class: '', requiredProfile: [1] },
    { path: '/main/auction-list', title: 'Subastas de Transporte',  icon:'gavel', class: '', requiredProfile: [1, 4] },
    { path: '/main/loss-report', title: 'Perdidas de Fruta',  icon:'description', class: '', requiredProfile: [2] },
    // { path: '/main/buy-residue', title: 'Comprar productos',  icon:'shopping_basket', class: '', requiredProfile: [5] },


    // { path: '/main/table-list', title: 'Table List',  icon:'content_paste', class: '' },
    // { path: '/main/typography', title: 'Typography',  icon:'library_books', class: '' },
    // { path: '/main/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
    // { path: '/main/maps', title: 'Maps',  icon:'location_on', class: '' },
    // { path: '/main/notifications', title: 'Notifications',  icon:'notifications', class: '' },
    // { path: '/main/download-app', title: 'Cerrar Sesión',  icon:'get_app', class: 'active-pro' },
    { path: '/main/my-profile', title: 'Mi Perfil',  icon:'person', class: '' }

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor(public _userService: UserService) {}

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };

  logout() {
    this._userService.logout();
  }
}
