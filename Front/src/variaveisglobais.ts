import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class Variaveisglobais {
  // L = Ambiente Local
  // P = Produção 
  // H = Homologação
  // D = Dev
  // E = Espelho 

  ambiente = "L";


  apiUrl = ""; 
  apiIAUrl = "";

  apiUrlLocal = "https://localhost:7067/";
  apiIAUrlLocal = "https://localhost:7293/";

  apiUrlProducao = "";
  apiIAUrlProducao = "";

  apiUrlHomologacao = "";
  apiIAUrlHomologacao = "";

  apiUrlDev = "";
  apiIAUrlDev = "";

  apiUrlEspelho = "";
  apiIAUrlEspelho = "";

}
