import React, { useState } from "react";
import { IoIosAddCircle } from "react-icons/io";
import { CnpjType, CompanyInfo } from "../../@types/types";
import api from "../../Services/Api";
const Homepage: React.FC = () => {
    const [companiesSearcheds, setCompaniesSearcheds] = useState<CompanyInfo[]>([]);
    const [cnpjs, setCnpjs] = useState<CnpjType[]>([{ cnpj: "", key: 0 }]);

    const renderInputs = (): JSX.Element[] => {
        return cnpjs.map((cnpj, index) => (
            <input
                key={index}
                type="text"
                placeholder="Digite o CNPJ"
                value={cnpj.cnpj}
                onChange={(e) => handleCnpjChange(index, e.target.value)}
            />
        ));
    }

    const handleCnpjChange = (index: number, value: string) => {
        const updatedCnpjs = [...cnpjs];
        updatedCnpjs[index].cnpj = value;
        setCnpjs(updatedCnpjs);
    }
    const handleSearchCompanies = () => {
        cnpjs.map(cnpj => {
            if (cnpj.cnpj) requestCompany(cnpj.cnpj)
        });
    }

    const requestCompany = (cnpj: string) => {
        cnpj = cnpj.replace(/\D/g, "");
        api.get(`Company/GetByCnpj/?cnpj=${cnpj}`)
            .then((response) => {
                const companies: CompanyInfo[] = companiesSearcheds;
                companies.push(response.data);
                setCompaniesSearcheds(companies);
            })
            .catch((error) => {
                alert(error);
            });
    }

    const handleAddCnpj = () => {
        const cnpjsLocal = [...cnpjs];
        cnpjsLocal.push({ cnpj: "", key: cnpjsLocal.length });
        setCnpjs(cnpjsLocal);
    }
    const handleSaveCompany = (company: CompanyInfo) => {
        api.post(`Company/Create`, company)
            .then((response) => {
                alert("Empresa Salva com sucesso.");
            })
            .catch((error) => {
                alert("Erro ao salvar Empresa - " + error);
            });
    }
    
    return (
        <div className='Homepage' style={{ display: "flex", flexDirection: "row", width: "100%", justifyContent: "start", alignItems: "start"}}>
            <section style={{  position: "relative",display: "flex", flexDirection: "column", width: "30%", padding: "1rem", borderRadius: "10px", border: "1px solid #c3c3c3"  }}>
                Buscar Empresa por CNPJ
                    <IoIosAddCircle
                        onClick={handleAddCnpj}
                        style={{ cursor: "pointer", color: "greenyellow", position: "absolute", right: "10px", top: "10px", height: "30px", width: "30px" }} />
                    
                <div style={{ display: "flex", flexDirection: "column", gap: "20px", marginTop: "20px", margin: '0px', borderRadius: "10px", border: "1px solid #c3c3c3" }}>
                {renderInputs()}

                </div>
                <button
                    onClick={handleSearchCompanies}
                    style={{ cursor: "pointer", backgroundColor: "green", color: "white" }}
                >
                    Search
                </button>
            </section>
            <section>
                {companiesSearcheds.map((company, index) => (
                    <div
                        key={index}
                        style={{ display: "flex", gap: "20px", padding: "10px", margin: '0px', borderRadius: "10px", border: "1px solid #c3c3c3" }}
                    >
                        <div style={{ display: "flex", flexDirection: "column", gap: "20px", backgroundColor: "#c3c3c3", padding: "10px", margin: '0px' }}>
                            <div>Fantasia: {company.fantasia}</div>
                            <div>Nome: {company.nome}</div>
                            <div>CNPJ: {company.cnpj}</div>
                            <div>Status: {company.status}</div>
                            <div>Motivo Situação: {company.motivoSituacao}</div>
                            <div>Situação Especial: {company.situacaoEspecial}</div>
                            <div>Data Situação Especial: {company.dataSituacaoEspecial}</div>
                            <div>Porte: {company.porte}</div>
                            <div>Abertura: {company.abertura}</div>
                            <div>Situação: {company.situacao}</div>
                            <div>Data Situação: {company.dataSituacao}</div>
                            <div>Tipo: {company.tipo}</div>
                            <div>Natureza Jurídica: {company.naturezaJuridica}</div>
                        </div>

                        <div style={{ display: "flex", flexDirection: "column", gap: "20px", backgroundColor: "#c3c3c3", padding: "10px", margin: '0px' }}>
                            <div>Capital Social: {company.capitalSocial}</div>
                            <div>Logradouro: {company.logradouro}</div>
                            <div>Número: {company.numero}</div>
                            <div>Complemento: {company.complemento}</div>
                            <div>Município: {company.municipio}</div>
                            <div>Bairro: {company.bairro}</div>
                            <div>UF: {company.uf}</div>
                            <div>CEP: {company.cep}</div>
                            <div>Telefone: {company.telefone}</div>
                            <div>Última Atualização: {company.ultimaAtualizacao}</div>
                            <div>Email: {company.email}</div>
                            <div>EFR: {company.efr}</div>
                            <div>Billing: {JSON.stringify(company.billing)}</div>
                        </div>
                        <div>
                            <button onClick={handleSaveCompany(company)}>Salvar</button>    
                        </div>
                    </div>
                ))}
            </section>
        </div>
    );
}

export default Homepage;