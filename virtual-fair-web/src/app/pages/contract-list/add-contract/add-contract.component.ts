import { Component, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { MatDialogRef } from "@angular/material/dialog";
import { ContractService } from "app/services/contract.service";
import { ProfileService } from "app/services/profile.service";
import { UserService } from "app/services/user.service";
import { UtilsService } from "app/utils/utils.service";
import {
  FileSystemDirectoryEntry,
  FileSystemFileEntry,
  NgxFileDropEntry,
} from "ngx-file-drop";
import { Observable, Subscription } from "rxjs";
import { map, startWith } from "rxjs/operators";

@Component({
  selector: "app-add-contract",
  templateUrl: "./add-contract.component.html",
  styleUrls: ["./add-contract.component.css"],
})
export class AddContractComponent implements OnInit {
  processing: boolean = false;
  subscriptions: Subscription = new Subscription();

  contract: any = {};

  myControl = new FormControl();
  filteredOptions: Observable<string[]>;

  users: any[] = [];
  currentFileResult: any;

  public files: NgxFileDropEntry[] = [];

  constructor(
    private _userService: UserService,
    public dialogRef: MatDialogRef<AddContractComponent>,
    private _contractService: ContractService,
    private _utilsService: UtilsService
  ) {}

  ngOnInit(): void {
    this.findAllUsers();

    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(""),
      map((value) => (typeof value === "string" ? value : value.fullName)),
      map((name) => (name ? this._filter(name) : this.users.slice()))
    );
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  saveContract() {
    const doc = this.files[0].fileEntry as FileSystemFileEntry;
    doc.file((file: File) => {
      this.handleUpload(file, (res) => {
        const body: any = {
          expirationDate: new Date(this.contract.expirationDate),
          idUser: this.myControl.value.id,
          contractPath: res,
          isValid: 1,
        };
        this._contractService.create(body).subscribe((res: any) => {
          console.log("res", res);
          this.processing = false;
          let resultModalData: any;
          if (res.statusCode === 201) {
            resultModalData = {
              message: "El contrato ha sido registrado con éxito.",
              resultType: "success",
            };
            this.dialogRef.close();
          } else {
            resultModalData = {
              message: "Hubo un problema al intentar registrar el contrato.",
              resultType: "failure",
            };
          }

          this._utilsService.showNotification(resultModalData);
        });
      });
    });
  }

  registerNewUser() {
    this.processing = true;
    // this.subscriptions.add(
    //   this._userService.create(this.newUserData).subscribe((res) => {
    //     this.processing = false;
    //     let resultModalData: any;
    //     if (res.statusCode === 201) {
    //       resultModalData = {
    //         message: "El usuario ha sido registrado con éxito.",
    //         resultType: "success",
    //       };
    //       this.dialogRef.close();
    //     } else {
    //       resultModalData = {
    //         message: "Hubo un problema al intentar registrar el usuario.",
    //         resultType: "failure",
    //       };
    //     }

    //     this._utilsService.showNotification(resultModalData);
    //   })
    // );
  }

  public fileOver(event) {
    console.log(event);
  }

  public fileLeave(event) {
    console.log(event);
  }

  private _filter(value: string): string[] {
    return this.users.filter(
      (user) => user.fullName.toLowerCase().indexOf(value.toLowerCase()) === 0
    );
  }

  findAllUsers() {
    this._userService.findAll().subscribe(
      (res) => {
        if (res.statusCode == 200) {
          this.users = res.users;
          this.users.map(
            (user) =>
              (user.displayInfo = {
                id: user.id,
                fullName: user.fullName,
                email: user.email,
                profileName:
                  user.profile.name.charAt(0).toUpperCase() +
                  user.profile.name.toLowerCase().slice(1),
              })
          );
          this.users = this.users.sort((a, b) => a.id - b.id);
          this.filteredOptions = this.myControl.valueChanges.pipe(
            startWith(""),
            map((value) =>
              typeof value === "string" ? value : value.fullName
            ),
            map((name) => (name ? this._filter(name) : this.users.slice()))
          );
        } else if (res.statusCode == 204) {
          this.users = res.users;
          if (res.message) {
            //this._toastrService.error(res.message);
          }
        }
      },
      (error) => {
        //this._toastrService.error(environment.MESSAGE_ERROR_INTERNAL_API);
        console.clear();
      }
    );
  }

  displayFn(user: any): string {
    return user && user.fullName ? user.fullName : "";
  }

  handleUpload(file, callback) {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      callback(reader.result);
    };
  }

  public dropped(files: NgxFileDropEntry[]) {
    this.files = files;
  }
}
