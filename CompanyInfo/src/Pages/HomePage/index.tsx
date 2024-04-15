import React, { useState } from "react";
import { AiFillCloseCircle } from "react-icons/ai";
import { IoIosAddCircle } from "react-icons/io";
import { IoRefreshCircle } from "react-icons/io5";
import { CnpjType, CompanyInfo } from "../../@types/types";
import api from "../../Services/Api";
import './style.css';
const Homepage: React.FC = () => {
    const [companiesSearcheds, setCompaniesSearcheds] = useState<CompanyInfo[]>([]);
    const [cnpjs, setCnpjs] = useState<CnpjType[]>([{ cnpj: "", key: 0 }]);

    const renderInputs = (): JSX.Element[] => {
        return cnpjs.map((cnpj, index) => (
            <div key={index} className="InputContainer">
                <input
                    className="InputCnpj"
                    key={index}
                    type="text"
                    placeholder="Digite o CNPJ"
                    value={cnpj.cnpj}
                    onChange={(e) => handleCnpjChange(index, e.target.value)}
                />
                <AiFillCloseCircle className="InputCloseIcon" onClick={() => handleRemoveCnpj(index)} />
            </div>

        ));
    }

    const handleRemoveCnpj = (index: number) => {
        const cnpjsLocal = [...cnpjs];
        cnpjsLocal.splice(index, 1);
        setCnpjs(cnpjsLocal);
    }

    const handleCnpjChange = (index: number, value: string) => {
        const updatedCnpjs = [...cnpjs];
        updatedCnpjs[index].cnpj = value;
        setCnpjs(updatedCnpjs);
    }

    const handleSearchCompanies = () => {
        setCnpjs(cnpjs.filter(cnpj => cnpj.cnpj));
        cnpjs.map(cnpj => {
            requestCompany(cnpj.cnpj)
        });
    }

    const requestCompany = async (cnpj: string) => {
        cnpj = cnpj.replace(/\D/g, "");

        try {
            const response = await api.get(`Company/GetByCnpj/?cnpj=${cnpj}`);

            const companyExists = companiesSearcheds.some(company => company.cnpj === cnpj);

            if (!companyExists) {
                setCompaniesSearcheds(prevCompanies => [...prevCompanies, response.data]);
            }
        } catch (error) {
            console.error(error);
        }
    }

    const handleRefresh = () => {
        setCompaniesSearcheds([]);
        setCnpjs([{ cnpj: "", key: 0 }]);
    }

    const handleAddCnpj = () => {
        console.warn("first")
        const cnpjsLocal = [...cnpjs];
        cnpjsLocal.push({ cnpj: "", key: cnpjsLocal.length });
        setCnpjs(cnpjsLocal);

        console.warn(cnpjsLocal)
    }
    return (
        <div className='HomePage'>
            <section className="SearchArea">
                <div className="SearchAreaTitleRow">
                    <IoRefreshCircle
                        onClick={handleRefresh}
                        className="SearchAreaAddIcon" />
                    <strong className="SearchAreaTitle">Buscar Empresa por CNPJ</strong>
                    <IoIosAddCircle
                        onClick={handleAddCnpj}
                        className="SearchAreaAddIcon"
                    />
                </div>
                <div className="SearchAreaInputBox">
                    {renderInputs()}
                </div>
                <button
                    className="SearchAreaButton"
                    onClick={handleSearchCompanies}>
                    Search
                </button>
            </section>
            <section className="CompaniesSearched">
                {companiesSearcheds.map((company, index) => (
                    <div
                    key={index}
                    className="CompanyContainer">
                        <div className="CompanyInfo">
                            <div>
                                <span className="CompanyInfoTitle">Fantasia:</span>
                                <span className="CompanyInfoValue">{company.fantasia}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Nome: </span>
                                <span className="CompanyInfoValue">{company.nome}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">CNPJ: </span>
                                <span className="CompanyInfoValue">{company.cnpj}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Status: </span>
                                <span className="CompanyInfoValue">{company.status}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Motivo Situação: </span>
                                <span className="CompanyInfoValue">{company.motivoSituacao}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Situação Especial: </span>
                                <span className="CompanyInfoValue">{company.situacaoEspecial}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Data Situação Especial: </span>
                                <span className="CompanyInfoValue">{company.dataSituacaoEspecial}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Porte: </span>
                                <span className="CompanyInfoValue">{company.porte}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Abertura: </span>
                                <span className="CompanyInfoValue">{company.abertura}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Situação: </span>
                                <span className="CompanyInfoValue">{company.situacao}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Data Situação: </span>
                                <span className="CompanyInfoValue">{company.dataSituacao}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Tipo: </span>
                                <span className="CompanyInfoValue">{company.tipo}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Natureza Jurídica: </span>
                                <span className="CompanyInfoValue">{company.naturezaJuridica}</span>
                            </div>
                        </div>
                    
                        <div className="CompanyInfo">
                            <div>
                                <span className="CompanyInfoTitle">Capital Social: </span>
                                <span className="CompanyInfoValue">{company.capitalSocial}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Logradouro: </span>
                                <span className="CompanyInfoValue">{company.logradouro}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Número: </span>
                                <span className="CompanyInfoValue">{company.numero}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Complemento: </span>
                                <span className="CompanyInfoValue">{company.complemento}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Município: </span>
                                <span className="CompanyInfoValue">{company.municipio}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Bairro: </span>
                                <span className="CompanyInfoValue">{company.bairro}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">UF: </span>
                                <span className="CompanyInfoValue">{company.uf}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">CEP: </span>
                                <span className="CompanyInfoValue">{company.cep}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Telefone: </span>
                                <span className="CompanyInfoValue">{company.telefone}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Última Atualização: </span>
                                <span className="CompanyInfoValue">{company.ultimaAtualizacao}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Email: </span>
                                <span className="CompanyInfoValue">{company.email}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">EFR: </span>
                                <span className="CompanyInfoValue">{company.efr}</span>
                            </div>
                            <div>
                                <span className="CompanyInfoTitle">Billing: </span>
                                <span className="CompanyInfoValue">{JSON.stringify(company.billing)}</span>
                            </div>
                        </div>
                    </div>
                ))}
            </section>
        </div>
    );
}

export default Homepage;