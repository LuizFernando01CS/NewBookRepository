import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as $ from 'jquery';
import { IAService } from '../../../Services/ia.service';
import { RequestCompreender } from '../../../app/interfaces/request/request-compreender';
import { ConversaIaService } from '../../../Services/conversa.ia.service';
import { GoogleAuthProvider } from '@angular/fire/auth';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { RequestAuthGoogle } from '../../../app/interfaces/request/request-auth-google';

@Component({
  selector: 'app-criar-livro',
  templateUrl: './criar-livro.component.html',
  styleUrls: ['./criar-livro.component.scss'],
})
export class CriarLivroComponent implements OnInit {
  visualizando: boolean = false;
  livro: any = 'veer';
  pergunta: any = '';
  teste2 = false;
  user: any;
  logado = false;
  mensagens: any = [
    {
      mensagem: 'mensagem1das4d5sa46dsad',
    },
  ];
  //pesquisando 1 = IA desativado
  //pesquisando 2 = IA escutando
  //pesquisando 3 = IA gravando
  //pesquisando 4 = IA pesquisando
  pesquisando: any = 1;

  editorConfig = {
    base_url: '/tinymce',
    suffix: '.min',
    plugin: 'list link image table wordcount',
    min_height: 850,
    setup: (editor: any) => {
      editor.on('init', () => {
        editor.setContent(this.livro);
      });
    },
  };

  constructor(
    private activeRoute: ActivatedRoute,
    private iaService: IAService,
    private conversaIaService: ConversaIaService,
    private angularFireAuth: AngularFireAuth
  ) {
    this.activeRoute.queryParams.subscribe((qp) => {
      this.visualizando = this.activeRoute.snapshot.params['visualizar'];
    });
  }

  login() {
    this.angularFireAuth.signInWithPopup(new GoogleAuthProvider()).then(
      (status: any) => {
        console.log('VEEER STATUS', status);
        this.user = status;
        console.log(
          'VEER A MAIS',
          this.user.additionalUserInfo.profile.picture
        );

        var requestAuthGoogle: RequestAuthGoogle = {
          isNewUser: status.additionalUserInfo.isNewUser,
          email: status.additionalUserInfo.profile.email,
          family_name: status.additionalUserInfo.profile.family_name,
          given_name: status.additionalUserInfo.profile.given_name,
          name: status.additionalUserInfo.profile.name,
          idFirebase: status.additionalUserInfo.profile.id,
          locale: status.additionalUserInfo.profile.locale,
          image: status.additionalUserInfo.profile.picture,
          verified_email: status.additionalUserInfo.profile.verified_email,
          accessToken: status.credential.accessToken,
          idToken: status.credential.idToken,
          providerId: status.credential.providerId,
          SignInMethod: status.credential.SignInMethod,
          phoneNumber: status.user.delegate.phoneNumber,
          creationTime: status.user.delegate.metadata.creationTime,
          lastSignInTime: status.user.delegate.metadata.lastSignInTime,
        };

        this.logado = true;
      },
      (err) => {
        alert(err.mensagem);
      }
    );
  }

  ngOnInit() {
    this.ObterConversaIA();

    if (this.pesquisando == 3) {
      setTimeout(() => {
        this.CompreenderPergunta();
      }, 2000);
    }

    if (this.pesquisando == 4) this.PararIA();

    console.log(this.livro);
  }

  ObterConversaIA() {
    this.conversaIaService
      .ObterConversaIA(localStorage.getItem('idUsuario')!)
      .subscribe((x) => {
        console.log('VEER RESULT', x);
      });
  }
  CompreenderPergunta() {
    setTimeout(() => {
      if (this.pesquisando == 3) {
        this.pesquisando = 4;
        debugger;
        var resquestCompreender: RequestCompreender = {
          idUsuario:
            localStorage.getItem('idUsuario') === undefined
              ? 0
              : Number(localStorage.getItem('idUsuario')!),
          pergunta: this.pergunta,
          tipoMensagem: 2,
        };

        this.iaService
          .CompreenderPergunta(resquestCompreender)
          .subscribe((x) => {});
      }
    }, 2000);
  }

  teste() {
    if (this.pergunta == '') {
      console.log('ERROR');
      return;
    }

    debugger;
    var resquestCompreender: RequestCompreender = {
      idUsuario:
        localStorage.getItem('idUsuario') == undefined
          ? 0
          : Number(localStorage.getItem('idUsuario')!),
      pergunta: this.pergunta,
      tipoMensagem: 1,
    };

    this.iaService.CompreenderPergunta(resquestCompreender).subscribe((x) => {
      console.log('VEER RESULT', x);
    });
  }

  AtiviarIA() {
    this.iaService.StartVoice();

    this.pergunta = localStorage.getItem('VozTextoCompleta');

    this.pesquisando = 2;

    setTimeout(() => {
      this.pesquisando = 3;
    }, 2000);
  }

  changeLivro() {
    debugger;
    console.log(this.livro);
  }

  PararIA() {
    this.iaService.StopVoice();
  }
}
