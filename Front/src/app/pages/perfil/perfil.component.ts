import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from 'src/Services/usuario.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent {
  usuario:any;

  constructor(private activatedRoute: ActivatedRoute, private router: Router,
    private usuarioService: UsuarioService) 
  {
    let questoesParam = this.activatedRoute.
    queryParamMap.subscribe(params => params.get('usuario') || 'None');
  }

  ngOnInit() 
  {

    //  var logadoStorage = localStorage.getItem("logado");

    // if(logadoStorage != "true")
    //   this.router.navigate(['/home']);
      
    //   this.ObterUsuario();
  }

  ObterUsuario()
{
    this.usuarioService.ObterUsuarioPelolocalId().subscribe( 
    {
      next : response => {this.usuario = response; console.log(response);}, 
      error(err) { console.log(`Error occurred: ${err}`)},
      complete() { }
    });
}

}
