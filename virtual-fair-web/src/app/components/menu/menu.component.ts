import { Component, OnInit, HostListener } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  userConnect: any;

  width: number;

  constructor(private router: Router) { }

  ngOnInit() {

    this.userConnect = JSON.parse(localStorage.getItem('userConnect'));

    this.getPassingTopBody();

  }

  getPassingTopBody(){

    let body: HTMLElement = document.getElementById('body');

    if(this.width >= 1000){

      body.style.paddingTop = '56px';

    }else if(this.width >= 500 && this.width <= 1000){

      body.style.paddingTop = '56px';

    }else{

      body.style.paddingTop = '56px';

    }

  }

  logout(){

    this.router.navigateByUrl('/');
    localStorage.clear();

  }

  @HostListener('window:resize')
  resize(){

    this.width = window.innerWidth;
    
    this.getPassingTopBody();
  }
}
