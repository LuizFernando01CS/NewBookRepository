import { Component } from '@angular/core';
import { AuthService } from 'src/Services/auth.service';
import { UsuarioService } from '../../../Services/usuario.service';
import { ScriptService } from '../../../Services/script.service';
import { Router } from '@angular/router';
import { RequestAuthInterno } from 'src/app/interfaces/request/request-auth-interno';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  user: any;
  responseAuthGoogle: any;
  logado: boolean = false;

  constructor(
     private usuarioService: UsuarioService,
     private authService: AuthService,
     public scriptService: ScriptService,
     private router: Router){}


  onClickLogin(form: any){
    if(form.userName == undefined || form.userName == null || form.userName == ""){
      alert("Nome de Usuario é obrigatório!");
      return;
    }

    if(form.password == undefined || form.password == null || form.password == ""){
      alert("Senha é obrigatório!");
      return;
    }

    if(form.password != form.confirmPassword){
      alert("Senhas Divergentes!");
      return;
    }

    var requestAuthInterno: RequestAuthInterno = {
      email: form.userName,
      Password: form.password
    };

    this.authService.AuthInterno(requestAuthInterno);  
  }

  AuthGoogle(){
    this.authService.AuthGoogle();
  }

  ngOnInit() 
  {
    this.authService.AuthGoogle();
  }

  CreateAccount(){
    this.router.navigate(['/', 'criarConta']);
  }

  AuthFacebook()
  {

  }

  closeModal(){
 
  }
}
