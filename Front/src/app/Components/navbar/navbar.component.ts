import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  logado: boolean = false;
  nomeCompleto: any;
  imagem: any;

  constructor(
     private router: Router) {
  }

  ngOnInit() {
    if(localStorage.getItem("logado") == "true"){
      this.imagem = localStorage.getItem("imagem") ?? "";
      this.nomeCompleto = localStorage.getItem("userName") ?? "";
      this.logado = true; 
    }
 }


 Perfil(){ 
    if(this.logado)
      this.router.navigate(['/', 'perfil']);
    else
      this.router.navigate(['/', 'login']);
 }
}
