import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { FuncaoIaService } from '../Services/funcao.ia.service';
import { ConversaIA } from '../app/interfaces/tabelas/conversa-ia';

@Injectable()
export class ConversaIaService {
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

  public ObterConversaIA(IdUsuario: string) {
    return this.http.get<any>(
      this.apiIAUrl + 'IA/ObterConversaIA/' + IdUsuario
    );
  }
}
