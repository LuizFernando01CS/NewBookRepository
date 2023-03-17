import { Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {

  constructor(private scriptService: ScriptService, private router: Router) {

  }
  ngOnInit() {
     this.scriptService.ativarSideBar()
  }

  RotaInicio(){
    this.router.navigate(['/', 'home']);
  }

  RotameusLivroslivro(){
    this.router.navigate(['/', 'meusLivros']);
  }
}
