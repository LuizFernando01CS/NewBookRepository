import { Component } from '@angular/core';
import { GoogleAuthProvider } from '@angular/fire/auth';
import { AngularFireAuth } from '@angular/fire/compat/auth';

@Component({
  selector: 'app-como-funciona',
  templateUrl: './como-funciona.component.html',
  styleUrls: ['./como-funciona.component.scss'],
})
export class ComoFuncionaComponent {
  constructor(private angularFireAuth: AngularFireAuth) {}

  login() {
    this.angularFireAuth.signInWithPopup(new GoogleAuthProvider()).then(
      (status: any) => {
        console.log('VEEER STATUS', status);
      },
      (err) => {
        alert(err.mensagem);
      }
    );
  }

  ngOnInit() {}
}
