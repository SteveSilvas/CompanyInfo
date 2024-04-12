export type CompanyInfo = {
    abertura: string;
    atividadePrincipal: any[] | null; 
    atividadesSecundarias: any[] | null;
    bairro: string;
    billing: {
        free: boolean;
        database: boolean;
    };
    capitalSocial: string;
    cep: string;
    cnpj: string;
    complemento: string;
    dataSituacao: string;
    dataSituacaoEspecial: string;
    efr: string;
    email: string;
    extra: Record<string, any>;
    fantasia: string;
    logradouro: string;
    motivoSituacao: string;
    municipio: string;
    naturezaJuridica: string;
    nome: string;
    numero: string;
    porte: string;
    qsa: { nome: string }[];
    situacao: string;
    situacaoEspecial: string;
    status: string;
    telefone: string;
    tipo: string;
    uf: string;
    ultimaAtualizacao: string;
}

export type CnpjType = {
    cnpj: string;
    key: number;
}