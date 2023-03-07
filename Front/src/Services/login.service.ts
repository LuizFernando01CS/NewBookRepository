import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { RequestAuthGoogle } from '../app/interfaces/request/request-auth-google';

@Injectable()
export class LoginService {
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
    return this.http.post<any>(
      this.apiUrl + 'Auth/AuthGoogle',
      requestAuthGoogle
    );
  }

  public ObterConversaIA(IdUsuario: string) {
    return this.http.get<any>(
      this.apiIAUrl + 'IA/ObterConversaIA/' + IdUsuario
    );
  }
}
