import { Component } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-livraria',
  templateUrl: './livraria.component.html',
  styleUrls: ['./livraria.component.scss']
})

export class LivrariaComponent {
  filtros = [  {
    texto: "todos",
    value: 1
  },
  {
    texto: "primeiro",
    value: 2
  },
  {
    texto: "segundo",
    value: 3
  }];

  constructor(private router: Router) {

  }

  ngOnInit() {

    this.filtros = [    
      {
        texto: "todos",
        value: 1
      },
      {
        texto: "primeiro",
        value: 2
      },
      {
        texto: "segundo",
        value: 3
      }
  ]

    $('#buttonEscutar').hover(function() {
      $('#image-slider').css('background-image', 'url(../../../assets/NovaImagens/Escutar.png)');
    }, function() {
      $('#image-slider').css('background-image', 'url(../../../assets/NovaImagens/Escrevendo.jpg)');
    });  
  }

  abrirLivro(visualizando: boolean){
    this.router.navigate(['/','criarlivro', {visualizar: visualizando}]);
  }
}
