import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { UserService } from 'src/app/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[
    UserService
  ]
})
export class LoginComponent implements OnInit {

  user: any = {};

  loadingFindByEmailAndPassword: boolean;

  constructor(private router: Router, private _toastrService: ToastrService, private _userService: UserService) { }

  ngOnInit() {

    let body: HTMLElement = document.getElementById('body');

    body.style.paddingTop = '0px';

  }

  findByEmailAndPassword(){

    this.loadingFindByEmailAndPassword = true;

    this._userService.findByEmailAndPassword(this.user).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindByEmailAndPassword = false;

        localStorage.setItem('userConnect', JSON.stringify(res.userConnect));
        localStorage.setItem('sessionToken', JSON.stringify(res.sessionToken));

        this.router.navigateByUrl('/menu/home');

      }else if(res.statusCode == 204){

        this.loadingFindByEmailAndPassword = false;
        this._toastrService.error(res.message);

      }else if(res.statusCode == 403){

        this.loadingFindByEmailAndPassword = false;
        this._toastrService.error(res.message);

      }else if(res.statusCode == 500){

        this.loadingFindByEmailAndPassword = false;
        this._toastrService.error(res.message);

      }

    }, error => {

      this.loadingFindByEmailAndPassword = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    });

  }

  keyPress(e: any){

    if(e.keyCode == 13){

      this.findByEmailAndPassword();

    }

  }
}
