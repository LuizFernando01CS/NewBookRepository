import { Usuario } from "../tabelas/usuario";

export interface ResponseAuthGoogle {
    token: string;
    logado: boolean;
    usuario: Usuario;
}
