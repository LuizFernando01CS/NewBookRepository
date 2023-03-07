import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { CriarLivroComponent } from './pages/criar-livro/criar-livro.component';
import { ComoFuncionaComponent } from './pages/como-funciona/como-funciona.component';
import { MeusLivrosComponent } from './pages/meus-livros/meus-livros.component';

const titleName = "CriadorLivro - ";

const routes: Routes = [
{
  path: 'home',
  component: HomeComponent,
  // children: [
  //   {
  //     path: 'criarlivro',
  //     component: CriarLivroComponent,
  //     data: { title: titleName + 'criarlivro' }
  //   }
  // ]
},
{
  path: 'criarlivro',
  component: CriarLivroComponent,
  data: {animation: 'criarlivro'}
},
{
  path: 'comoFunciona',
  component: ComoFuncionaComponent,
  data: {animation: 'comoFunciona'}
},
{
  path: 'meusLivros',
  component: MeusLivrosComponent,
  data: {animation: 'meusLivros'}
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
