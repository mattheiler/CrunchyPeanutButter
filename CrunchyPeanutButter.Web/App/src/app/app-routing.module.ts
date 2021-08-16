import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

// Include, when enabling autentication.
//import { AuthGuard } from "./auth";

import { UnauthorizedComponent } from "./unauthorized/unauthorized.component";
import { ForbiddenComponent } from "./forbidden/forbidden.component";

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "home"
  },
  {
    path: "home",
    loadChildren: () => import("./home").then(module => module.HomeModule),
    // Enable the route guard, if the user must be authenticated.
    //canLoad: [AuthGuard]
    data: { hasLayout: true }
  },
  {
    path: "forbidden",
    component: ForbiddenComponent,
    // Enable the route guard, if the user must be authenticated.
    // canActivate: [AuthGuard]
  },
  {
    path: "unauthorized",
    component: UnauthorizedComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
