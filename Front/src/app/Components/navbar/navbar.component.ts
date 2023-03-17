import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ScriptService } from '../../../Services/script.service';
import { LoginComponent } from './Component/login/login.component';
// import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  logado: boolean = false;
  element: any;
  modal: any;
  constructor(
    private scriptService: ScriptService, 
     private matDialog: MatDialog) {
  }

  ngOnInit() {
    this.scriptService.ativarNavBar();

    var logadoStorage = localStorage.getItem("logado");

 

    // this.logado = logadoStorage != undefined && logadoStorage != null && logadoStorage != "" ? Boolean(logadoStorage) : false;
 }

 Perfil(){
  
    if(this.logado){
      //tela perfil
    }
    else{
      const dialogModal = this.matDialog.open(LoginComponent, {width: '500px'});
      dialogModal.backdropClick().subscribe(result => {
        dialogModal.close();
      });
    }
 }
}
