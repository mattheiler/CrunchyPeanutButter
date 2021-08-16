import { NgModule } from "@angular/core";
import { HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { first } from "rxjs/operators";
import { UserManager, UserManagerSettings } from "oidc-client";

import { AuthInterceptor } from "./auth.interceptor";
import { AuthService } from "./auth.service";

import { LoginCallbackComponent } from "./login-callback.component";
import { LogoutCallbackComponent } from "./logout-callback.component";

@NgModule({
  declarations: [
    LoginCallbackComponent,
    LogoutCallbackComponent
  ],
  imports: [
    RouterModule.forChild([
      {
        path: "authentication/login-callback",
        component: LoginCallbackComponent
      },
      {
        path: "authentication/logout-callback",
        component: LogoutCallbackComponent
      }
    ])
  ],
  exports: [
    RouterModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    {
      provide: AuthService,
      deps: [HttpClient],
      useFactory: (http: HttpClient) => async () => {
        const authority = await http.get(".authority", { withCredentials: false, responseType: "text" }).pipe(first()).toPromise();
        const settings: UserManagerSettings = {
          authority,
          client_id: "NexteonWebApplication1",
          redirect_uri: location.origin + "/authentication/login-callback",
          post_logout_redirect_uri: location.origin + "/authentication/logout-callback",
          response_type: "code",
          scope: "openid profile"
        };
        return new AuthService(new UserManager(settings));
      }
    }
  ]
})
export class AuthModule {
}
