import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { Variaveisglobais } from 'src/variaveisglobais';
import { RequestCompreender } from '../app/interfaces/request/request-compreender';
import { SendMessageRequest } from '../app/interfaces/request/send-message-request';
import { ChatIAResponse } from 'src/app/interfaces/response/chat-ia-response';
import { RequestEditChatIA } from '../app/interfaces/request/request-edit-chat-ia';

@Injectable()
export class IAService {
  apiUrl = '';
  apiIAUrl = '';
  constructor(
    private http: HttpClient,
    private variaveisglobais: Variaveisglobais,
  ) {
    this.apiUrl = this.variaveisglobais.apiUrl;
    this.apiIAUrl = this.variaveisglobais.apiIAUrl;
  }

  public SendMessage(sendMessageRequest: SendMessageRequest) {
    let headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json'})};
    return this.http.post<any>(this.apiIAUrl + 'IA/EnviandoMensagem', sendMessageRequest, headers); 
  }

  public CompreenderPergunta(requestPergunta: RequestCompreender) {
    let headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json'})};
    return this.http.post<ChatIAResponse>(this.apiIAUrl + 'IA/CompreenderPergunta', requestPergunta, headers);
  }

  public SaveEditChatIA(requestEditChatIA: RequestEditChatIA){
    let headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json'})};
    return this.http.post<any>(this.apiIAUrl + 'IA/SalvarEdicaoChatIA', requestEditChatIA, headers);
  }

  public GetIAByUserId(userId: string){
    let headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json'})};
    return this.http.get<any>(this.apiIAUrl + `IA/ObterIA/${userId}`, headers);
  }

  public ObterConversaIA(IdUsuario: string) {
    return this.http.get<any>(
      this.apiIAUrl + 'IA/ObterConversaIA/' + IdUsuario
    );
  }
}
