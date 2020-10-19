import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { UserService } from 'src/app/services/user.service';
import { environment } from 'src/environments/environment';

declare var $:any;

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  providers:[
    UserService
  ]
})
export class UserComponent implements OnInit {

  users: Array<any> = new Array<any>();

  searcher: string;

  loadingFindAll: boolean;

  constructor(private router: Router, private _toastrService: ToastrService, private _userService: UserService) { }

  ngOnInit() {
    
    this.findAll();

  }

  findAll(){

    this.loadingFindAll = true;

    this._userService.findAll(this.searcher).subscribe(res => {

      if(res.statusCode == 200){

        this.loadingFindAll = false;
        this.users = res.users;

      }else if(res.statusCode == 204){

        this.loadingFindAll = false;
        this.users = res.users;

        if(res.message){

          this._toastrService.error(res.message);

        }

      }else if(res.statusCode == 403){

        this.loadingFindAll = false;
        this.router.navigateByUrl('/');
        localStorage.clear();

      }else if(res.statusCode == 500){

        this.loadingFindAll = false;
        this._toastrService.error(res.message);

      }

    }, error => {

      this.loadingFindAll = false;
      this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
      console.clear();

    });

  }

  registerUser() {
    $('#myModal').on('shown.bs.modal', function () {
      $('#myInput').trigger('focus')
    })
  }
}
