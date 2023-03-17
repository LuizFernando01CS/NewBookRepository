export interface Usuario {
    id: number;
    dataCriacao: string;
    dataAtualizacao: string;
    peloSite: boolean;
    login: string;
    email: string;
    password: string;
    informacoesPessoaisID: number;
    firebaseId: string;
    createAuthGoogle: boolean;
    imagem: string;
    ultimoAcesso: string;
    provedorId: string;
    metodoAcesso: string;
}
