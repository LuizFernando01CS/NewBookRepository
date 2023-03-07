import { Mensagens } from './mensagens';

export interface ConversaIA {
  Id: number;
  idUsuario: number;
  mensagens: Mensagens[];
}
