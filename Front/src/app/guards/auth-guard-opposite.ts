import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot} from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardOpposite implements CanActivate {

  constructor(private authService: AuthService, private http: HttpClient) { }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<any>{
    if(localStorage.getItem("token") != undefined && localStorage.getItem("token") != null && localStorage.getItem("token") != ""){
      window.location.href = "/home";
      return false;
    } 

    return true;
  }
}