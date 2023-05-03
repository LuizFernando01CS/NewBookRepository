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
  active = false;


  apiUrl = "https://localhost:7067/"; 
  apiIAUrl = "https://localhost:7040/";

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
