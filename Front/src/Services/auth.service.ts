import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { RequestAuthGoogle } from '../app/interfaces/request/request-auth-google';
import { Observable } from 'rxjs';
import { ResponseAuthGoogle } from 'src/app/interfaces/response/response-auth-google';
import { RequestAuthInterno } from 'src/app/interfaces/request/request-auth-interno';

@Injectable()
export class AuthService {
  apiUrl = '';
  apiIAUrl = '';
  constructor(
    private http: HttpClient,
    private variaveisglobais: Variaveisglobais
  ) {
    this.apiUrl = this.variaveisglobais.apiUrl;
    this.apiIAUrl = this.variaveisglobais.apiIAUrl;
  }

  public AuthGoogle(requestAuthGoogle: RequestAuthGoogle) {
    return this.http.post<ResponseAuthGoogle>(
      this.apiUrl + 'Auth/AuthGoogle',
      requestAuthGoogle
    );
  }

  public AuthInterno(requestAuthInterno: RequestAuthInterno){
    return this.http.post<RequestAuthInterno>(
      this.apiUrl + 'Auth/AuthInterno',
      requestAuthInterno
    );
  }
  
}
