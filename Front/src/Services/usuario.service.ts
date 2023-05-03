import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

const token = localStorage.getItem("token") ?? "";

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

   public ObterUsuarioPelolocalId() : Observable<any>
   { 
      let headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${token}`})};
      return this.http.get<any>(this.apiUrl + "Usuario/ObterUsuarioPelolocalId", headers);
   }

   
}