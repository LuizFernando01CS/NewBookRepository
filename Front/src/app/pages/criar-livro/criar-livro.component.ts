import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IAService } from '../../../Services/ia.service';
import { FormControl } from '@angular/forms';

const webkitSpeechRecognition = (window as any).SpeechRecognition || (window as any).webkitSpeechRecognition;

@Component({
  selector: 'app-criar-livro',
  templateUrl: './criar-livro.component.html',
  styleUrls: ['./criar-livro.component.scss'],
})

export class CriarLivroComponent implements OnInit {
  recognition = new webkitSpeechRecognition();
  activeMicrophone: boolean = false;
  activePhone: boolean = false;
  isStoppedSpeechRecog = false;
  public text = '';
  tempWords: any;
  EditingIA: boolean = false;

  visualizando: boolean = false;
  livro: any = 'veer';
  pergunta: any = '';
  teste2 = false;
  user: any;
  logado = false;


  responseAuthGoogle: any;
  
  messageControl = new FormControl('');

  editorConfig = {
    base_url: '/tinymce',
    suffix: '.min',
    plugin: 'list link image table wordcount',
    // plugins: [
    //   "advlist autolink lists link image charmap print preview anchor",
    //   "searchreplace visualblocks code fullscreen",
    //   "insertdatetime media table contextmenu paste"
    //   ],
       menubar: true,
       statusbar: false,

   toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image",
    height: 833,
    branding: false,
    promotion: false,

    setup: (editor: any) => {
      editor.on('init', () => {
        editor.setContent(this.livro);
      });
    },
  };

  constructor(
    private activeRoute: ActivatedRoute,
    private iaService: IAService
  ) {
    this.activeRoute.queryParams.subscribe((qp) => {
      this.visualizando = this.activeRoute.snapshot.params['visualizar'];
    });
  }

  ngOnInit() {
  }

  IASpeech(){

  }

  init() {

    this.recognition.interimResults = true;
    this.recognition.lang = 'pt-BR';

    this.recognition.addEventListener('result', (e:any) => {
      console.log("tessste audio", e);
      const transcript = Array.from(e.results)
        .map((result:any) => result[0])
        .map((result) => result.transcript)
        .join('');
      this.tempWords = transcript;
      console.log(transcript);
    });
  }

  start() {
    this.activeMicrophone = true;
    this.isStoppedSpeechRecog = false;
    this.recognition.start();
    console.log("Speech recognition started")
    this.init();
    this.recognition.addEventListener('end', (condition:any) => {
      if (this.isStoppedSpeechRecog) {   
        this.recognition.stop();
        console.log("End speech recognition")
      } else {
        this.wordConcat(false);
        this.recognition.start();
      }
    });
  }

  stop() {
    this.isStoppedSpeechRecog = true;
    this.activeMicrophone = false;
    this.wordConcat(true)
    this.recognition.stop();
    console.log("End speech recognition")
    this.text = "";
  }

  wordConcat(stop: boolean) {

    this.livro += ' ' + this.tempWords;

    this.text = this.text + ' ' + this.tempWords + ' ';
    
    console.log(this.text );

    localStorage.setItem("VozTextoCompleta", this.text);
    localStorage.setItem("VozTextoAtual", this.tempWords);

    this.tempWords = '';

    if(!stop){
      if(this.text.toLowerCase().indexOf("stoprodolfo") != -1 || this.text.toLowerCase().indexOf("stop rodolfo") != -1) 
      this.stop();

    if(this.text.toLowerCase().indexOf("parerodolfo") != -1 || this.text.toLowerCase().indexOf("pare rodolfo") != -1)
      this.stop();
    }

  }

  ActiveMicrophone() {
    this.activeMicrophone ? this.stop() :  this.start();
    
    this.pergunta = localStorage.getItem('VozTextoCompleta');
  }

  ActivePhone(){
    this.activePhone ? this.activePhone = false : this.activePhone = true;
  }

  changeLivro() {
    console.log(this.livro);
  }

  onOpen(){
  this.EditingIA = false;
  }

  EditIA(){
    this.EditingIA = this.EditingIA ? false : true;
  }
}
