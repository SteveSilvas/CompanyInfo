import React, { useState } from "react";
import { AiFillCloseCircle } from "react-icons/ai";
import { IoIosAddCircle } from "react-icons/io";
import { IoRefreshCircle } from "react-icons/io5";
import { CnpjType, CompanyInfo } from "../../@types/types";
import CompanyInfoDetail from "../../components/CompanyInfo";
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

    const handleRemoveCnpj = (index: number): void => {
        const cnpjsLocal = [...cnpjs];
        cnpjsLocal.splice(index, 1);
        setCnpjs(cnpjsLocal);
    }

    const handleCnpjChange = (index: number, value: string): void => {
        const updatedCnpjs = [...cnpjs];
        updatedCnpjs[index].cnpj = value;
        setCnpjs(updatedCnpjs);
    }

    const handleSearchCompanies = (): void => {
        setCnpjs(cnpjs.filter(cnpj => cnpj.cnpj));
        cnpjs.map(cnpj => {
            requestCompany(cnpj.cnpj)
        });
    }

    const requestCompany = async (cnpj: string) => {
        cnpj = cnpj.replace(/\D/g, "");

        try {
            const response = await api.get(`Company/GetByCnpj/?cnpj=${cnpj}`);
            const companyExists = companiesSearcheds.find(company => clearCnpj(company.cnpj) === clearCnpj(cnpj));
            if (!companyExists) {
                setCompaniesSearcheds(prevCompanies => [...prevCompanies, response.data]);
            }
        } catch (error) {
            alert(error);
        }
    }

    const clearCnpj = (cnpj: string): string => {
        return cnpj.replace(/\D/g, "");
    }
    const handleRefresh = () => {
        setCompaniesSearcheds([]);
        setCnpjs([{ cnpj: "", key: 0 }]);
    }

    const handleAddCnpj = () => {
        const cnpjsLocal = [...cnpjs];
        cnpjsLocal.push({ cnpj: "", key: cnpjsLocal.length });
        setCnpjs(cnpjsLocal);
    }
    const handleSaveCompany = (company: CompanyInfo) => {
        api.post(`Company/Create`, company)
            .then((response) => {
                console.log(response.data.message);
                if (response && response.data && response.data.message) {
                    alert(response.data.message);
                } else {
                    alert("Empresa Salva com sucesso.");
                }
            })
            .catch((error) => {
                console.log(error);
                alert("Erro ao salvar Empresa - " + error.response.data);
            });
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
                    onClick={handleSearchCompanies}
                    disabled={cnpjs.length === 0}>
                    Search
                </button>
            </section>
            <section className="CompaniesSearched">
                {companiesSearcheds.map((company, index) => (
                    <CompanyInfoDetail key={index} company={company} handleSaveCompany={handleSaveCompany} />
                ))}
            </section>
        </div>
    );
}

export default Homepage;