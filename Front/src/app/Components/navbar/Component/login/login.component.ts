import { Component } from '@angular/core';
import { GoogleAuthProvider } from '@angular/fire/auth';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { RequestAuthGoogle } from 'src/app/interfaces/request/request-auth-google';
import { AuthService } from 'src/Services/auth.service';
import { UsuarioService } from '../../../../../Services/usuario.service';
import * as $ from 'jquery';

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
    private formBuilder: FormBuilder,
     private usuarioService: UsuarioService,
     private angularFireAuth: AngularFireAuth,
     private authService: AuthService,
     public dialogRef: MatDialogRef<LoginComponent>){}


  onClickLogin(form: any){
    if(form.nomeUsuario == undefined || form.nomeUsuario == null || form.nomeUsuario == ""){
      alert("Nome de Usuario é obrigatório!");
      return;
    }

    if(form.senha == undefined || form.senha == null || form.senha == ""){
      alert("Senha é obrigatório!");
      return;
    }

    if(form.senha != form.ConfirmarSenha){
      alert("Senhas Divergentes!");
      return;
    }

    this.usuarioService.CriarUsuario(form).subscribe(x => 
    x.then((res: any)=> {
      console.log("VEER RES", res);

    }).catch((err: any) => { 
      console.log(err); // Here.
    }));
    
  }

  AuthGoogle(){

    this.angularFireAuth.signInWithPopup(new GoogleAuthProvider()).then(
      (status: any) => {
        this.user = status;

        var requestAuthGoogle: RequestAuthGoogle = {
          isNewUser: status.additionalUserInfo.isNewUser,
          email: status.additionalUserInfo.profile.email,
          family_name: status.additionalUserInfo.profile.family_name,
          given_name: status.additionalUserInfo.profile.given_name,
          name: status.additionalUserInfo.profile.name,
          idFirebase: status.additionalUserInfo.profile.id,
          locale: status.additionalUserInfo.profile.locale,
          image: status.additionalUserInfo.profile.picture,
          verified_email: status.additionalUserInfo.profile.verified_email,
          accessToken: status.credential.accessToken,
          idToken: status.credential.idToken,
          providerId: status.credential.providerId,
          SignInMethod: status.credential.SignInMethod,
          phoneNumber: status.user._delegate.phoneNumber,
          creationTime: status.user._delegate.metadata.creationTime,
          lastSignInTime: status.user._delegate.metadata.lastSignInTime,
        };

        this.authService.AuthGoogle(requestAuthGoogle).subscribe(x => {
          this.responseAuthGoogle = x;
          this.logado = this.responseAuthGoogle.logado;
          console.log(x);
        });
       
      },
      (err) => {
        alert(err.mensagem);
      }
    );
  }

  ngOnInit() 
  {
    var divNome: any = document.querySelector(".content");
    $(document).on("click", function(e) {
      var fora = !divNome.contains(e.target);

      if(fora) 
      {
        $(divNome).slideDown("slow/400/fast") 
        console.log(fora ? 'Fora!' : 'Dentro!');
      };
    });

  //   setTimeout(()=>{
  //     this.dialogRef.close();
  // }, 3000);
  }

  AuthFacebook()
  {

  }

  close(){
    debugger;
    this.dialogRef.close({data:this.responseAuthGoogle});
  }
}
