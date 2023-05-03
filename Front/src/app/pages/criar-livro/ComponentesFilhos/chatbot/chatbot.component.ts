import { Component, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IAService } from 'src/Services/ia.service';
import { FuncaoIaService } from 'src/Services/funcao.ia.service';
import { SendMessageRequest } from 'src/app/interfaces/request/send-message-request';


interface Message {
  userName: string,
  message: string,
  index: number,
  messageType: number,
  creationDate: string
}

@Component({
  selector: 'app-chatbot',
  templateUrl: './chatbot.component.html',
  styleUrls: ['./chatbot.component.scss']
})
export class ChatbotComponent {
  @Output() open: EventEmitter<any> = new EventEmitter();
  messages: Message[] = [
  ];

  loadingIA: boolean = false;
  loadingChatIA: boolean = true;
  userName: string = "";
  iaName: string = "";
  mensagemRequest: string = "";
  activeMicrophone: boolean = false;

  constructor(
    private activeRoute: ActivatedRoute,
    private iaService: IAService,
    private funcaoIaService: FuncaoIaService
  ) {
    
  }
  
  ngOnInit() {
    this.ObterConversaIA();
  }

  EditChatIA(){

  }

  sendMessage(form: any){
    this.mensagemRequest = "";

    var lastIndex = 1;
    var sendMessage = form.value.message;

    if( this.messages.length > 0){
      lastIndex = this.messages[this.messages.length - 1].index
      sendMessage = this.messages[this.messages.length - 2].message + "\n\n" + this.messages[this.messages.length - 1].message + "\n\n" + form.value.message;
    }
   

    var sendMessageRequest: SendMessageRequest = {
      userId: 4,
      message: sendMessage,
      messageUser: form.value.message,
      lastIndex: lastIndex,
      messageType: 1
    };

    this.messages.push( 
    {
      userName: "Luiz",
      message: form.value.message,
      index: lastIndex,
      messageType: 1,
      creationDate: "2023-03-21 14:35:21"
    }); 

    this.loadingIA = true;
    this.iaService.SendMessage(sendMessageRequest).subscribe(x => {
      this.loadingIA = false;
      debugger;
      console.log(x);
      this.messages.push( 
        {
          userName: "Shifter",
          message: x.textResponse,
          index: x.lastIndex,
          messageType: 1,
          creationDate: "2023-03-21 14:35:21"
        });
    });
  }


  
  ObterConversaIA() {
    this.iaService.ObterConversaIA(localStorage.getItem('usuarioId') ?? "0").subscribe(x => {
      this.funcaoIaService.EditTemplateIA();
      this.userName = x.userName;
        for(var item = 0; item < x.messages.length; item++){
          this.messages.push( 
            {
              userName: x.messages[item].name,
              message: x.messages[item].message,
              index: x.messages[item].index,
              messageType: x.messages[item].messageType,
              creationDate: x.messages[item].creationDate
            });
        }
        this.loadingChatIA = false;
      });
  }

}
