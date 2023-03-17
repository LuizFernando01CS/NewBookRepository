import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class UsuarioService {
    apiUrl =   "";
  constructor(private http: HttpClient, private variaveisglobais: Variaveisglobais) {
        this.apiUrl =this.variaveisglobais.apiUrl;
   }


   public CriarUsuario(form: any){
      return this.http.post<any>(this.apiUrl + "Usuario/CriarUsuario", form);
   }

   public   getAll()
   { 
        return this.http.get<any>(this.apiUrl + "Livro/GetAll");
   }
}