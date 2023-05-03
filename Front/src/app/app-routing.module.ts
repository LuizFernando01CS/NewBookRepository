import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { CriarLivroComponent } from './pages/criar-livro/criar-livro.component';
import { ComoFuncionaComponent } from './pages/como-funciona/como-funciona.component';
import { MeusLivrosComponent } from './pages/meus-livros/meus-livros.component';
import { PerfilComponent } from './pages/perfil/perfil.component';
import { LoginComponent } from './pages/login/login.component';
import { LivrariaComponent } from './pages/livraria/livraria.component';
import { CreateAccountComponent } from './pages/create-account/create-account.component';
import { AuthGuard } from './guards/auth-guard';
import { AuthGuardOpposite } from './guards/auth-guard-opposite';

console.log(localStorage.getItem("token") != "" && localStorage.getItem("token") != undefined  &&  localStorage.getItem("token") != null ? false : true);

const routes: Routes = 
[
  {
    path: 'home',
    component: HomeComponent
    // children: [
    //   {
    //     path: 'criarlivro',
    //     component: CriarLivroComponent,
    //     data: { title: titleName + 'criarlivro' }
    //   }
    // ]
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'criarlivro',
    component: CriarLivroComponent,
    data: {animation: 'criarlivro'},
    canActivate: [AuthGuard]
  },
  {
    path: 'comoFunciona',
    component: ComoFuncionaComponent,
    data: {animation: 'comoFunciona'}
  },
  {
    path: 'livraria',
    component: LivrariaComponent,
    data: {animation: 'livraria'},
    canActivate: [AuthGuard]
  },
  {
    path: 'perfil',
    component: PerfilComponent,
    data: {animation: 'perfil'},
    canActivate: [AuthGuard]
  }
  ,
  {
    path: 'login',
    component: LoginComponent,
    data: {animation: 'login'},
    canActivate: [AuthGuardOpposite]
  }
  ,
  {
    path: 'criarConta',
    component: CreateAccountComponent,
    data: {animation: 'criarConta'}
  },
  // { path: '',   redirectTo: '/first-component', pathMatch: 'full' }, // redirect to `first-component`
  // { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
