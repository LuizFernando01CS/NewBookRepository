import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { FuncaoIaService } from '../Services/funcao.ia.service';
import { RequestCompreender } from '../app/interfaces/request/request-compreender';

@Injectable()
export class IAService {
  apiUrl = '';
  apiIAUrl = '';
  constructor(
    private http: HttpClient,
    private variaveisglobais: Variaveisglobais,
    private funcaoIaService: FuncaoIaService
  ) {
    this.apiUrl = this.variaveisglobais.apiUrl;
    this.apiIAUrl = this.variaveisglobais.apiIAUrl;
  }

  public StartVoice() {
    this.funcaoIaService.start();
  }

  public StopVoice() {
    this.funcaoIaService.stop();
  }

  public getAll() {
    return this.http.get<any>(this.apiUrl + 'Livro/GetAll');
  }

  public CompreenderPergunta(requestPergunta: RequestCompreender) {
    return this.http.post<any>(
      this.apiIAUrl + 'IA/CompreenderPergunta',
      requestPergunta
    );
  }
}
