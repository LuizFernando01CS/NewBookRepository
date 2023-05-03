import { Component, EventEmitter, Output } from '@angular/core';
import { IAService } from '../../../../../Services/ia.service';
import { RequestEditChatIA } from '../../../../../app/interfaces/request/request-edit-chat-ia';

@Component({
  selector: 'app-edit-bot',
  templateUrl: './edit-bot.component.html',
  styleUrls: ['./edit-bot.component.scss']
})
export class EditBotComponent {
  colorUser: any;
  colorIA: any;
  colorChatIA: any;
  NameIA: string = "";
  IA:any;
  loaded: boolean = false;
  loadedChat: boolean = false;

  @Output() open: EventEmitter<any> = new EventEmitter();

  constructor(
    private iaService: IAService
  ) {
  }

  ngOnInit() {
    this.GetIA();
  }

  GetIA(){
    this.iaService.GetIAByUserId(localStorage.getItem("user") || "0").subscribe(x =>{
      this.IA = x;
      this.colorUser = x.userColorMessage;
      this.colorIA = x.iAColorMessage;
      this.NameIA = x.nameIA;
      this.colorChatIA = x.iAChatColor;
      this.loadedChat = true;
    });
  }

  changeColor(){
  }

  Cancelar(){
    this.open.emit(null);
  }

  SaveEdit(){
    this.loaded = true;
    var requestEditChatIA: RequestEditChatIA = {
      userId: localStorage.getItem("user") || "0",
      userColorMessage: this.colorUser,
      iAColorMessage: this.colorIA,
      iAChatColor:  this.colorChatIA,
      nameIA: this.NameIA
    };

    this.iaService.SaveEditChatIA(requestEditChatIA).subscribe(x => { this.loaded = false;  this.open.emit(null)});
  }
}
