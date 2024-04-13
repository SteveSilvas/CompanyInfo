import React, { useEffect, useState } from "react";
import { CompanyInfo } from "../../@types/types";
import api from "../../Services/Api";

const CompaniesSaved: React.FC = () => {
    const [companies, setCompanies] = useState<CompanyInfo[]>([]);

    useEffect(() => {
        requestCompanies();
    }, []);

    const requestCompanies = () => {
        api.get(`/Company/GetAll`)
            .then((response) => {
                setCompanies(response.data);
            })
            .catch((ex) => {
                console.error(ex);
            });
    };

    const renderCompaniesSaved = (): JSX.Element[] => {
        return companies.map((company: CompanyInfo, index: number) => (
            <div 
                style={{ 
                    display: "flex", 
                    flexDirection: "column", 
                    backgroundColor: "lightgray", 
                    padding: "10px", 
                    margin: '10px', 
                    borderRadius: "5px" 
                }}
                key={index}
            >
                <h2>{company.nome}</h2>
                <p><strong>CNPJ:</strong> {company.cnpj}</p>
                <p><strong>Telefone:</strong> {company.telefone}</p>
                <p><strong>Endereço:</strong> {company.logradouro}, {company.numero}, {company.bairro}, {company.municipio} - {company.uf}</p>
                <p><strong>Situação:</strong> {company.situacao}</p>
            </div>
        ));
    };

    return (
        <div className='CompaniesSaved'>
            <h1>Empresas Salvas</h1>
            <div style={{ display: "flex", flexWrap: "wrap" }}>
                {renderCompaniesSaved()}
            </div>
        </div>
    );
};

export default CompaniesSaved;
