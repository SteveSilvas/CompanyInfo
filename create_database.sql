CREATE DATABASE CompanyInfo;
USE CompanyInfo;

CREATE TABLE Atividade (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Code VARCHAR(255) NOT NULL,
    Text VARCHAR(255) NOT NULL
);

DESCRIBE Atividade;

INSERT INTO Atividade (Code, Text)
VALUES ('codigo1', 'Texto para código 1'),
       ('codigo2', 'Texto para código 2'),
       ('codigo3', 'Texto para código 3');

SELECT * FROM Atividade;

CREATE TABLE Empresa (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Abertura VARCHAR(255) NOT NULL,
    Situacao VARCHAR(255) NOT NULL,
    Tipo VARCHAR(255) NOT NULL,
    Nome VARCHAR(255) NOT NULL,
    Fantasia VARCHAR(255) NOT NULL,
    Porte VARCHAR(255) NOT NULL,
    NaturezaJuridica VARCHAR(255) NOT NULL,
    Logradouro VARCHAR(255) NOT NULL,
    Numero VARCHAR(255) NOT NULL,
    Complemento VARCHAR(255) NOT NULL,
    Municipio VARCHAR(255) NOT NULL,
    Bairro VARCHAR(255) NOT NULL,
    UF VARCHAR(255) NOT NULL,
    CEP VARCHAR(255) NOT NULL,
    Telefone VARCHAR(255) NOT NULL,
    DataSituacao VARCHAR(255) NOT NULL,
    CNPJ VARCHAR(255) NOT NULL,
    UltimaAtualizacao DATETIME NOT NULL,
    Status VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    EFR VARCHAR(255) NOT NULL,
    MotivoSituacao VARCHAR(255) NOT NULL,
    SituacaoEspecial VARCHAR(255) NOT NULL,
    DataSituacaoEspecial VARCHAR(255) NOT NULL,
    CapitalSocial VARCHAR(255) NOT NULL
);


INSERT INTO Empresa (Abertura, Situacao, Tipo, Nome, Fantasia, Porte, NaturezaJuridica, Logradouro, Numero, Complemento, Municipio, Bairro, UF, CEP, Telefone, DataSituacao, CNPJ, UltimaAtualizacao, Status, Email, EFR, MotivoSituacao, SituacaoEspecial, DataSituacaoEspecial, CapitalSocial)
VALUES ('01/01/2000', 'Ativa', 'Matriz', 'Empresa A LTDA', 'Empresa A', 'Grande', 'Sociedade Limitada', 'Rua Principal', '123', 'Sala 1', 'Cidade A', 'Centro', 'SP', '12345-678', '(11) 1234-5678', '01/01/2022', '00.000.000/0001-00', '2023-04-11 12:34:56', 'OK', 'empresaA@example.com', 'Responsável A', 'Motivo A', '', '', '');

INSERT INTO Empresa (Abertura, Situacao, Tipo, Nome, Fantasia, Porte, NaturezaJuridica, Logradouro, Numero, Complemento, Municipio, Bairro, UF, CEP, Telefone, DataSituacao, CNPJ, UltimaAtualizacao, Status, Email, EFR, MotivoSituacao, SituacaoEspecial, DataSituacaoEspecial, CapitalSocial)
VALUES ('05/05/2010', 'Ativa', 'Filial', 'Empresa B Filial LTDA', 'Filial B', 'Média', 'Sociedade Limitada', 'Av. Secundária', '456', '', 'Cidade B', 'Centro', 'RJ', '54321-098', '(21) 9876-5432', '02/02/2022', '11.111.111/0001-11', '2023-04-11 10:20:30', 'OK', 'filialB@example.com', 'Responsável B', 'Motivo B', '', '', '1000000.00');

INSERT INTO Empresa (Abertura, Situacao, Tipo, Nome, Fantasia, Porte, NaturezaJuridica, Logradouro, Numero, Complemento, Municipio, Bairro, UF, CEP, Telefone, DataSituacao, CNPJ, UltimaAtualizacao, Status, Email, EFR, MotivoSituacao, SituacaoEspecial, DataSituacaoEspecial, CapitalSocial)
VALUES ('10/10/2015', 'Ativa', 'Matriz', 'Empresa C S/A', 'Empresa C', 'Pequena', 'Sociedade Anônima', 'Rua Comercial', '789', '', 'Cidade C', 'Periferia', 'MG', '98765-432', '(31) 1234-5678', '03/03/2022', '22.222.222/0001-22', '2023-04-11 08:00:00', 'OK', 'empresaC@example.com', 'Responsável C', 'Motivo C', '', '', '500000.00');

