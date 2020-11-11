import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "app/services/user.service";
import {MatDialog } from '@angular/material/dialog';
import { UserRegisterComponent } from "app/pages/user-register/user-register.component";


@Component({
  selector: "app-user-list",
  templateUrl: "./user-list.component.html",
  styleUrls: ["./user-list.component.css"],
})
export class UserListComponent implements OnInit {
  users: Array<any> = new Array<any>();
  displayedUsers: Array<any> = [];
  searcher: string;
  loadingFindAll: boolean;
  searchTerm: string;

  constructor(private router: Router, private _userService: UserService, public _dialog: MatDialog) {}

  ngOnInit() {
    this.findAll();
  }

  findAll() {
    this.loadingFindAll = true;

    this._userService.findAll(this.searcher).subscribe(
      (res) => {
        if (res.statusCode == 200) {
          this.loadingFindAll = false;
          this.users = res.users;
          this.users.map(
            (user) =>
              (user.displayInfo = {
                id: user.id,
                fullName: user.fullName,
                email: user.email,
                profileName: user.profile.name.charAt(0).toUpperCase() + user.profile.name.toLowerCase().slice(1)
              })
          );
          this.users = this.users.sort((a,b)=> a.id - b.id);
          this.displayedUsers = JSON.parse(JSON.stringify(this.users));
        } else if (res.statusCode == 204) {
          this.loadingFindAll = false;
          this.users = res.users;
          if (res.message) {
            //this._toastrService.error(res.message);
          }
        } else if (res.statusCode == 403) {
          this.loadingFindAll = false;
          this.router.navigateByUrl("/");
          localStorage.clear();
        } else if (res.statusCode == 500) {
          this.loadingFindAll = false;
          //this._toastrService.error(res.message);
        }
      },
      (error) => {
        this.loadingFindAll = false;
        //this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
        console.clear();
      }
    );
  }

  registerUser() {
    this._dialog.open(UserRegisterComponent, {
      data: {
        animal: 'panda'
      },
      width: '700px',
    }).afterClosed().subscribe(res => {
      this.findAll();
    });
  }

  getUserEncoded(userData: any) {
    return btoa(JSON.stringify(userData));
  }

  searchUsers() {
    this.displayedUsers = this.users.filter(user =>
      this.filterUsersDisplayInfo(user)
    );
  }

  filterUsersDisplayInfo(user: any) {
    let matchesAny: boolean = false;
    Object.keys(user.displayInfo).forEach((key) => {
      if (user.displayInfo[key].toString().includes(this.searchTerm)) {
        matchesAny = true;
      }
    });
    return matchesAny;
  }
}
