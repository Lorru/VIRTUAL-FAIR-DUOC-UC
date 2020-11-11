import { Component, OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { ProfileService } from "app/services/profile.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-user-register",
  templateUrl: "./user-register.component.html",
  styleUrls: ["./user-register.component.css"],
})
export class UserRegisterComponent implements OnInit {
  profileList: Array<any> = [];
  newUserData: any = {};
  processing: boolean = false;
  subscriptions: Subscription = new Subscription();

  constructor(
    private _profileService: ProfileService,
    private _userService: UserService,
    public dialogRef: MatDialogRef<UserRegisterComponent>,
    private _utilsService: UtilsService
  ) {}

  ngOnInit(): void {
    this.setProfileList();
    this.newUserData.password = this.generatePassword(
      8,
      "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890,./;'[]=-)(*&^%$#@!~`"
    );
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  setProfileList() {
    this.subscriptions.add(this._profileService.findAll().subscribe((res) => {
      if (res.statusCode === 200) {
        this.profileList = res.profiles;
      } else {
      }
    }));
  }

  registerNewUser() {
    this.processing = true;
    this.subscriptions.add(this._userService.create(this.newUserData).subscribe((res) => {
      this.processing = false;
      let resultModalData: any;
      if (res.statusCode === 201) {
        resultModalData = {
          message: "El usuario ha sido registrado con éxito.",
          resultType: "success",
        };
        this.dialogRef.close();
      } else {
        resultModalData = {
          message: "Hubo un problema al intentar registrar el usuario.",
          resultType: "failure",
        };
      }

      this._utilsService.showNotification(resultModalData);
    }));
  }

  generatePassword(lengthOfCode: number, possible: string) {
    let text = "";
    for (let i = 0; i < lengthOfCode; i++) {
      text += possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return text;
  }
}
