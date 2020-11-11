import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";

import { SecurityTokenGuard } from "./guards/security-token.guard";
import { LoginGuard } from "./guards/login.guard";
import { LoginComponent } from "./pages/login/login.component";

const routes: Routes = [
  {
    path: "",
    redirectTo: "login",
    pathMatch: "full",
  },
  {
    path: "main",
    loadChildren: () =>
      import("../app/pages/main-layout/main-layout.module").then(
        (m) => m.MainLayoutModule
      ),
    canActivate: [SecurityTokenGuard],
  },
  {
    path: "login",
    component: LoginComponent,
    canActivate: [LoginGuard]
  },
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true,
    }),
  ],
  exports: [],
})
export class AppRoutingModule {}
