import { NgModule, ModuleWithProviders } from "@angular/core";
import { CommonModule } from "@angular/common";

import { API_BASE_URL } from "./clients.generated"

@NgModule({
  declarations: [],
  imports: [CommonModule]
})
export class ApiModule {
  public static forRoot(baseUrl: string): ModuleWithProviders<ApiModule> {
    return {
      ngModule: ApiModule,
      providers: [
        {
          provide: API_BASE_URL,
          useValue: baseUrl
        }
      ]
    };
  }
}
