import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { Variaveisglobais } from 'src/variaveisglobais';
import { NavMenuComponent } from './Components/nav-menu/nav-menu.component';
import { CriarLivroComponent } from './pages/criar-livro/criar-livro.component';
import { ComoFuncionaComponent } from './pages/como-funciona/como-funciona.component';
import { LivroService } from '../Services/livro.service';
import { LivrariaComponent } from './pages/livraria/livraria.component';
import { ScriptService } from '../Services/script.service';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MeusLivrosComponent } from './pages/meus-livros/meus-livros.component';
import { EditorModule, TINYMCE_SCRIPT_SRC } from '@tinymce/tinymce-angular';
import { IAService } from '../Services/ia.service';
import { FuncaoIaService } from '../Services/funcao.ia.service';
import { ConversaIaService } from '../Services/conversa.ia.service';
import { GoogleAuthProvider } from '@angular/fire/auth';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFireModule } from '@angular/fire/compat';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { AuthService } from '../Services/auth.service';
import { LoginComponent } from './pages/login/login.component';
import { MatDialogModule} from '@angular/material/dialog';
import { UsuarioService } from '../Services/usuario.service';
import { PerfilComponent } from './pages/perfil/perfil.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { SocialLoginModule, SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import {GoogleLoginProvider} from '@abacritt/angularx-social-login';
import { ChatbotComponent } from './pages/criar-livro/ComponentesFilhos/chatbot/chatbot.component';
import { CreateAccountComponent } from './pages/create-account/create-account.component';
import { NgxSkeletonLoaderModule } from 'ngx-skeleton-loader';
import { EditBotComponent } from './pages/criar-livro/ComponentesFilhos/edit-bot/edit-bot.component';
import { ColorPickerModule } from 'ngx-color-picker';
import { LoadingComponent } from './Components/loadings/loading.component';
import { AuthGuard } from '../app/guards/auth-guard';
import { AuthGuardOpposite } from '../app/guards/auth-guard-opposite';
import { ToastrModule } from 'ngx-toastr';

const firebaseConfig = {
  apiKey: 'AIzaSyCAZLfSEP2m8BDMTxtzNSLaMsmkLbToxAg',
  authDomain: 'autenticacaonewbook.firebaseapp.com',
  projectId: 'autenticacaonewbook',
  storageBucket: 'autenticacaonewbook.appspot.com',
  messagingSenderId: '2167688347',
  appId: '1:2167688347:web:aa2252d7bc0c23bdd48a3e',
  measurementId: 'G-12WWL6PE83',
};

const googleAuth2 =  {
  provide: 'SocialAuthServiceConfig',
  useValue: {
    autoLogin: false,
    providers: [
      {
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider(
          '639900823229-ms6skd1cvb21fth3lnamf6pj7q1hdndv.apps.googleusercontent.com'
        )
      }
    ],
    onError: (err) => {
      console.error(err);
    }
  } as SocialAuthServiceConfig,
}


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    CriarLivroComponent,
    ComoFuncionaComponent,
    LivrariaComponent,
    MeusLivrosComponent,
    NavbarComponent,
    LoginComponent,
    PerfilComponent,
    ChatbotComponent,
    CreateAccountComponent,
    EditBotComponent,
    LoadingComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    // MatSelectModule,
    MatInputModule,
    BrowserAnimationsModule,
    EditorModule,
    FormsModule,
    AngularFireModule.initializeApp(firebaseConfig),
    AngularFireModule,
    MatDialogModule,
    ReactiveFormsModule,
    OAuthModule.forRoot(),
    SocialLoginModule,
    NgxSkeletonLoaderModule,
    ColorPickerModule,
    ToastrModule.forRoot()
  ],

  exports: [
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    // MatSelectModule,
    MatInputModule,
    BrowserAnimationsModule
  ],

  providers: [
    { provide: TINYMCE_SCRIPT_SRC, useValue: 'tinymce/tinymce.min.js' },
    Variaveisglobais,
    LivroService,
    ScriptService,
    IAService,
    FuncaoIaService,
    ConversaIaService,
    AngularFireAuth,
    GoogleAuthProvider,
    AuthService,
    AuthGuard,
    AuthGuardOpposite,
    UsuarioService,
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '639900823229-ms6skd1cvb21fth3lnamf6pj7q1hdndv.apps.googleusercontent.com'
            )
          }
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig,
    }
    
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA 
  ],
  
  bootstrap: [AppComponent],
})
export class AppModule {}
