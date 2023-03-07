import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as $ from 'jquery';
import { LivroService } from '../../../Services/livro.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  slide1Ativo: boolean = true;
  slide2Ativo: boolean = false;
  slide3Ativo: boolean = false;
  constructor(private router: Router, private livroService: LivroService) { }

  slide(number: any)
  {
    $('#thumbnail ul li').removeClass("active");
    $('#li' + number).addClass("active");

    if(number == 1){
      this.slide2Ativo = false;
      this.slide1Ativo = true;

      setTimeout(()=>{              
        $("#caption1").css("-webkit-animation", "ativo 1s linear 1 normal forwards");
        $("#caption2").css("-webkit-animation", "desativado 1s linear 1 normal forwards");
        
        $("#buttons1").css("-webkit-animation", "ativo 1s linear 1 normal forwards");
        $("#buttons2").css("-webkit-animation", "desativado 1s linear 1 normal forwards");

        $("#image-slider ul #Livro").css("-webkit-animation", "desativado 1s linear 1 normal forwards");
        
      setTimeout(()=>{              
        $("#image-slider ul #Livro").css("background-image","url(../../../assets/NovaImagens/livro.jpg)");
        $("#image-slider ul #Livro").css("-webkit-animation", "ativo 1s linear 1 normal forwards");
      }, 200);
 
    }, 100);

    }
    else if(number == 2){
      this.slide1Ativo = false;
      this.slide2Ativo = true;
      
      setTimeout(()=>{  
        $("#caption1").css("-webkit-animation", "desativado 1s linear 1 normal forwards");
        $("#caption2").css("-webkit-animation", "ativo 1s linear 1 normal forwards");

        $("#buttons1").css("-webkit-animation", "desativado 1s linear 1 normal forwards");
        $("#buttons2").css("-webkit-animation", "ativo 1s linear 1 normal forwards");


        $("#image-slider ul #Livro").css("-webkit-animation", "desativado 1s linear 1 normal forwards");             
      setTimeout(()=>{              
        $("#image-slider ul #Livro").css("background-image","url(../../../assets/NovaImagens/lampada.jpg)");
        $("#image-slider ul #Livro").css("-webkit-animation", "ativo 1s linear 1 normal forwards");
      }, 200);

    }, 100);
    }
    else{

    }

    this.livroService.getAll()
    .subscribe((data: any) => {
        console.log("VEEER DATA", data);
    });
  }

  ComoFuncionaPage(){
    this.router.navigate(['/comoFunciona']);
  }

  NovoLivroPage(){
    this.router.navigate(['/criarlivro']);
  }

  ngOnInit() {
    setTimeout(()=>{  
      $("#buttons1").css("opacity", "1");
  }, 100);
   
  }

}
