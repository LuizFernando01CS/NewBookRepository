import { Component } from '@angular/core';
import { Variaveisglobais } from 'src/variaveisglobais';
import { ScriptService } from '../Services/script.service';
import { OAuthService} from 'angular-oauth2-oidc';
import { FuncaoIaService } from 'src/Services/funcao.ia.service';
import { AuthService } from 'src/Services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'newbook';

  constructor(private variaveis: Variaveisglobais, 
    private scriptService: ScriptService,
    private oAuthService: OAuthService,
    private funcaoIaService: FuncaoIaService,
    private authService: AuthService){}

  ngOnInit(): void {

    // if (this.variaveis.ambiente == "L") {
    //   this.variaveis.apiUrl = this.variaveis.apiUrlLocal;
    //   this.variaveis.apiIAUrl = this.variaveis.apiIAUrlLocal;
    // }
    // else if (this.variaveis.ambiente == "P") {
    //   this.variaveis.apiUrl = this.variaveis.apiUrlProducao;
    //   this.variaveis.apiIAUrl = this.variaveis.apiIAUrlProducao;
    // }
    // else if (this.variaveis.ambiente == "H") {
    //   this.variaveis.apiUrl = this.variaveis.apiUrlHomologacao;
    //   this.variaveis.apiIAUrl = this.variaveis.apiIAUrlHomologacao;
    // }
    // else if (this.variaveis.ambiente == "D") {
    //   this.variaveis.apiUrl = this.variaveis.apiUrlDev;
    //   this.variaveis.apiIAUrl = this.variaveis.apiIAUrlDev;
    // }
    // else if (this.variaveis.ambiente == "E") {
    //   this.variaveis.apiUrl = this.variaveis.apiUrlEspelho;
    //   this.variaveis.apiIAUrl = this.variaveis.apiIAUrlEspelho;
    // }
    // this.scriptService.ativarNavBar();
    this.funcaoIaService.EditTemplateIA();

    this.scriptService.ativarSideBar();  
  }
}
