import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
  providers: [UserService],
})
export class LoginComponent implements OnInit {
  user: any = {};
  testingUsersLogin: Array<any> = [
    {
      email: "administrador@virtualfair.cl",
      password: "12345",
      rol: "Administrador",
    },
    {
      email: "consultor@virtualfair.cl",
      password: "12345",
      rol: "Consultor",
    },
    {
      email: "adoh.astuh@gmail.com",
      password: "12345",
      rol: "Productor",
    },
    {
      email: "ad.astudillo@alumnos.duoc.cl",
      password: "12345",
      rol: "Transportista",
    },
    {
      email: "clienteinterno@virtualfair.cl",
      password: "12345",
      rol: "Cliente Interno",
    },
    {
      email: "clienteexterno@virtualfair.cl",
      password: "12345",
      rol: "Cliente Externo",
    },
  ];

  loadingFindByEmailAndPassword: boolean;

  constructor(public router: Router, public _userService: UserService, public _utilsService: UtilsService) {}

  ngOnInit() {}

  findByEmailAndPassword() {
    this.loadingFindByEmailAndPassword = true;

    this._userService.findByEmailAndPassword(this.user).subscribe(
      (res) => {
        if (res.statusCode == 200) {
          this.loadingFindByEmailAndPassword = false;

          const remainingTime: any =
            new Date(res.sessionToken.expirationDate).getTime() -
            new Date(res.sessionToken.creationDate).getTime();
          const loginExpiration: any = new Date(
            Date.now() + remainingTime
          ).getTime();

          res.sessionToken.loginExpiration = loginExpiration;

          localStorage.setItem("userConnect", JSON.stringify(res.userConnect));
          localStorage.setItem(
            "sessionToken",
            JSON.stringify(res.sessionToken)
          );

          this.router.navigateByUrl("/main");
        } else if (res.statusCode == 204) {
          this.loadingFindByEmailAndPassword = false;
          //this._toastrService.error(res.message);
        } else if (res.statusCode == 403) {
          this.loadingFindByEmailAndPassword = false;
          let notificationData = {
            message:
              "Credenciales incorrectas",
            resultType: "failure",
          };

          this._utilsService.showNotification(notificationData);
          //this._toastrService.error(res.message);
        } else if (res.statusCode == 500) {
          this.loadingFindByEmailAndPassword = false;
          //this._toastrService.error(res.message);
        }
      },
      (error) => {
        this.loadingFindByEmailAndPassword = false;
        //this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
        console.clear();
      }
    );
  }

  keyPress(e: any) {
    if (e.keyCode == 13) {
      this.findByEmailAndPassword();
    }
  }
}
