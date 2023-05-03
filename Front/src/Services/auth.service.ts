import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { ResponseAuthGoogle } from 'src/app/interfaces/response/response-auth-google';
import { RequestAuthInterno } from 'src/app/interfaces/request/request-auth-interno';
import { OAuthService, AuthConfig } from 'angular-oauth2-oidc';
import { SocialAuthService } from '@abacritt/angularx-social-login';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

const token = localStorage.getItem("token") ?? "";

const OAuthConfig: AuthConfig = {
  issuer: "https://accounts.google.com",
  strictDiscoveryDocumentValidation: false,
  redirectUri: "http://localhost:4200/login",
  clientId: "639900823229-ms6skd1cvb21fth3lnamf6pj7q1hdndv.apps.googleusercontent.com",
  scope: "openid profile email"
} 

@Injectable()
export class AuthService {
  apiUrl = '';
  apiIAUrl = '';
  constructor(
    private http: HttpClient,
    private variaveisglobais: Variaveisglobais,
    private oAuthService: OAuthService,
    private authService: SocialAuthService,
    private router: Router,
    private toastr: ToastrService
  ) {

    this.apiUrl = this.variaveisglobais.apiUrl;
    this.apiIAUrl = this.variaveisglobais.apiIAUrl;

    this.oAuthService.configure(OAuthConfig);
  }



  public AuthGoogle() {
    if(localStorage.getItem("logado") != "true")
    {
      debugger;
      this.authService.authState.subscribe((user: any) => 
      {
        this.http.get(this.apiUrl + `Auth/ValidateToken/${user.idToken}`).subscribe({
           next: (result:any) => {

            if(result.error){
              this.toastr.error(result.message, 'Erro Inesperado');
              return;
            }

            localStorage.setItem("userName", result.name);
            localStorage.setItem("user", result.userId);
            localStorage.setItem("token", result.token);
            localStorage.setItem("logado", "true");
            window.location.href = "/home";
           },
           error: (x) => {
            debugger;
            this.toastr.error(x.message, 'Error Inesperado');
           }
          });
    });
  }
}

  public ValidateToken(token: any)
  {
    return this.http.get<any>(this.apiUrl + `Auth/ValidateToken/${token}`);
  }

  public AuthInterno(requestAuthInterno: RequestAuthInterno){
    let headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json'})};
    return this.http.post<any>(this.apiUrl + 'Auth/AuthInterno', requestAuthInterno, headers).subscribe({
      next:(result:any) => {
        if(result.error){
          this.toastr.error(result.message, 'Erro Inesperado');
          return;
        }

       localStorage.setItem("userName", result.name);
       localStorage.setItem("user", result.userId);
       localStorage.setItem("token", result.token);
       localStorage.setItem("logado", "true");
       window.location.href = "/home";
      },
      error: (x:any) => {
       this.toastr.error(x.message, 'Erro Inesperado');
      }
    }
  );
  }

  public async VerifyAuth(): Promise<any>{
    let headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${token}`})};
    return await this.http.get<boolean>(this.apiUrl + 'Auth/VerificarAutenticacao', headers).subscribe({
      next: (x: any) => {
        if(x.status == 401){
          this.toastr.info('Inicia a sessão novamente', 'Sessão Expirou!');
          this.logout();
          return false;
        }
        return true;
      },
      error: (x) => {
        if(x.status == 401){
          this.toastr.info('Inicia a sessão novamente', 'Sessão Expirou!');
          this.logout();
          return false;
        }
        return true;
      }
    });
  }

  public logout(){
    this.oAuthService.logOut();
    localStorage.removeItem("userName");
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    localStorage.removeItem("logado");
    localStorage.setItem("logado", "false");

    window.location.href = "/login";
  }
  
}
