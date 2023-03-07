import { Injectable } from '@angular/core';

const webkitSpeechRecognition = (window as any).SpeechRecognition || (window as any).webkitSpeechRecognition;

@Injectable()
export class FuncaoIaService {
    apiUrl =   "";

    recognition = new webkitSpeechRecognition();

    isStoppedSpeechRecog = false;
    public text = '';
    tempWords: any;
  
    constructor() 
    {
    }

    init() {

        this.recognition.interimResults = true;
        this.recognition.lang = 'pt-BR';
    
        this.recognition.addEventListener('result', (e:any) => {
          const transcript = Array.from(e.results)
            .map((result:any) => result[0])
            .map((result) => result.transcript)
            .join('');
          this.tempWords = transcript;
          console.log(transcript);
        });
      }
    
      start() {
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
        this.wordConcat(true)
        this.recognition.stop();
        console.log("End speech recognition")
        this.text = "";
      }
    
      wordConcat(stop: boolean) {
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
}