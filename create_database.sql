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
    CapitalSocial VARCHAR(255) NOT NULL,
    BillingFree INT NULL,
    BillingDatabase INT NULL
);

DESCRIBE Empresa;
SELECT * FROM Empresa;

CREATE TABLE AtividadeXEmpresa
(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    IdEmpresa INT NOT NULL,
    IdAtividade INT NOT NULL,
    Tipo INT NOT NULL,
    CONSTRAINT FK_AtividadeXEmpresa_Empresa FOREIGN KEY (IdEmpresa) REFERENCES Empresa(Id),
    CONSTRAINT FK_AtividadeXEmpresa_Atividade FOREIGN KEY (IdAtividade) REFERENCES Atividade(Id)
);

DESCRIBE AtividadeXEmpresa;

CREATE TABLE Qsa (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    IdEmpresa INT NOT NULL,
    FOREIGN KEY (IdEmpresa) REFERENCES Empresa(Id)
);

SELECT * FROM Empresa EM
LEFT JOIN AtividadeXEmpresa EA
ON EA.IdEmpresa = EM.Id
LEFT JOIN Atividade ATI
ON ATI.Id = EA.IdAtividade
INNER JOIN Qsa QSA
ON QSA.IdEmpresa = EM.Id;

DELETE FROM AtividadeXEmpresa; 
DELETE FROM Atividade;
DELETE FROM Qsa;
DELETE FROM Empresa;

DROP TABLE AtividadeXEmpresa;
DROP TABLE Atividade;
DROP TABLE Qsa;
DROP TABLE Empresa;

