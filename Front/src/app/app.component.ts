import { Component } from '@angular/core';
import { Variaveisglobais } from 'src/variaveisglobais';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'newbook';

  constructor(private variaveis: Variaveisglobais){}

  ngOnInit(): void {

    if (this.variaveis.ambiente == "L") {
      this.variaveis.apiUrl = this.variaveis.apiUrlLocal;
      this.variaveis.apiIAUrl = this.variaveis.apiIAUrlLocal;
    }
    else if (this.variaveis.ambiente == "P") {
      this.variaveis.apiUrl = this.variaveis.apiUrlProducao;
      this.variaveis.apiIAUrl = this.variaveis.apiIAUrlProducao;
    }
    else if (this.variaveis.ambiente == "H") {
      this.variaveis.apiUrl = this.variaveis.apiUrlHomologacao;
      this.variaveis.apiIAUrl = this.variaveis.apiIAUrlHomologacao;
    }
    else if (this.variaveis.ambiente == "D") {
      this.variaveis.apiUrl = this.variaveis.apiUrlDev;
      this.variaveis.apiIAUrl = this.variaveis.apiIAUrlDev;
    }
    else if (this.variaveis.ambiente == "E") {
      this.variaveis.apiUrl = this.variaveis.apiUrlEspelho;
      this.variaveis.apiIAUrl = this.variaveis.apiIAUrlEspelho;
    }
    localStorage.setItem('idLivro', '');
    localStorage.setItem('bkpLivro', '');
  }
}
