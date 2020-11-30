import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ProfileService } from "app/services/profile.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-user-profile",
  templateUrl: "./user-profile.component.html",
  styleUrls: ["./user-profile.component.css"],
})
export class UserProfileComponent implements OnInit {
  userData: any;
  profileList: Array<any> = [];
  subscriptions: Subscription = new Subscription();
  processing: boolean = false;

  profileDescriptions: Array<any> = [
    {
      name: "Administrador",
      id: 1,
      imageUrl: "https://www.iconhot.com/icon/png/rrze/256/user-admin-1.png",
      description:
        "El administrador tiene acceso a las funcionalidades principales del negocio del sistema Feria Virtual, incluyendo la gestión de usuarios, procesos de ventas, vista de contratos, etc.",
    },
    {
      name: "Consultor",
      id: 2,
      imageUrl:
        "https://icon-library.com/images/advisor-icon/advisor-icon-4.jpg",
      description:
        "El rol de consultor evalúa el rendimiento de los productos a tráves del tiempo, y por ello tiene acceso a todos los reportes generados por el sistema.",
    },
    {
      name: "Productor",
      id: 3,
      imageUrl: "https://icon-library.com/images/veggie-icon/veggie-icon-4.jpg",
      description:
        "El productor es quien provee las frutas y verduras en los procesos de venta. Tiene acceso a los procesos de ventas públicos y puede participar en ellos.",
    },
    {
      name: "Transportista",
      id: 4,
      imageUrl:
        "https://www.iconhot.com/icon/png/wp-woothemes-ultimate/256/transport.png",
      description:
        "El transportista es quien se preocupa de transportar, de manera segura y a tiempo, los productos a los clientes finales. Tiene acceso a las subastas de transporte de los procesos de ventas y puede participar en ellos.",
    },
    {
      name: "Cliente interno",
      id: 4,
      imageUrl:
        "https://cdn0.iconfinder.com/data/icons/street-food-stalls/50/42-128.png",
      description:
        "El rol de cliente interno son comerciantes locales interesados en comprar productos a precio rebajado. Tienen acceso al saldo de productos en donde los pueden comprar.",
    },
    {
      name: "Cliente externo",
      id: 5,
      imageUrl:
        "http://www.myiconfinder.com/uploads/iconsets/256-256-47d229adfec409c48be84661d895a9bc-market.png",
      description:
        "El cliente externo es un cliente extranjero que compra grandes cantidades de productos a la vez. Tiene acceso a soliciar compras personalizadas.",
    },
  ];

  constructor(
    public _userService: UserService,
    public _profileService: ProfileService,
    public _utilsService: UtilsService,
    public _activatedRoute: ActivatedRoute
  ) {
    this._activatedRoute.params.subscribe((params) => {
      if (params["userDataEncoded"]) {
        this.userData = JSON.parse(atob(params["userDataEncoded"]));
      }
    });
  }

  ngOnInit() {
    if (!this.userData) {
      this.userData = this._userService.getUser();
    }
    this.setProfileList();
  }

  setProfileList() {
    this.subscriptions.add(
      this._profileService.findAll().subscribe((res) => {
        if (res.statusCode === 200) {
          this.profileList = res.profiles;
        } else {
        }
      })
    );
  }

  updateUser() {
    this.processing = true;
    this.userData.status = +this.userData.status;
    this._userService.update(this.userData).subscribe((res) => {
      this.processing = false;
      let resultModalData: any;
      if (res.statusCode === 200) {
        this.profileList = res.profiles;
        resultModalData = {
          message: "Los cambops han sido guardados con éxito.",
          resultType: "success",
        };
      } else {
        resultModalData = {
          message: "Hubo un problema al intentar guardar los cambios.",
          resultType: "failure",
        };
      }

      this._utilsService.showNotification(resultModalData);
    });
  }
}
