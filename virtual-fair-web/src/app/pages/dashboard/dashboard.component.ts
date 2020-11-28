import { Component, OnInit } from '@angular/core';
import * as Chartist from 'chartist';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor() { }
  
  ngOnInit() {
  }

  slides = [
    {img: "https://images.unsplash.com/photo-1464226184884-fa280b87c399?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80"},
    {img: "https://media.istockphoto.com/photos/fruit-and-food-distribution-truck-loaded-with-containers-full-of-to-picture-id1068635350?k=6&m=1068635350&s=612x612&w=0&h=rX6dOkXs72dI9xht5p5M0Xgoj4fRE74zlKSNwfIEUo4="},
    {img: "https://media.istockphoto.com/photos/food-factory-assembly-line-with-apples-and-workers-picture-id1160835424?k=6&m=1160835424&s=612x612&w=0&h=eKg-gDbYFvf1Es_QWrkPvysNC-0a_sCQahrkGJPeOLE="},
    {img: "https://agfstorage.blob.core.windows.net/misc/AGF_nl/2020/01/17/APC02.jpg"}
  ];
  slideConfig = {"slidesToShow": 2, "slidesToScroll": 2,   autoplay: true,
  autoplaySpeed: 2000};
  
  addSlide() {
    this.slides.push({img: "http://placehold.it/350x150/777777"})
  }
  
  removeSlide() {
    this.slides.length = this.slides.length - 1;
  }
  
  slickInit(e) {
    console.log('slick initialized');
  }
  
  breakpoint(e) {
    console.log('breakpoint');
  }
  
  afterChange(e) {
    console.log('afterChange');
  }
  
  beforeChange(e) {
    console.log('beforeChange');
  }

}
