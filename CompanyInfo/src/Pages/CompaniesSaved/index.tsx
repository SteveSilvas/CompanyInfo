import React, { useEffect, useState } from "react";
import { CompanyInfo } from "../../@types/types";
import api from "../../Services/Api";
import CompanyInfoDetail from "../../components/CompanyInfo";
import './style.css';
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
    }
    const renderCompaniesSaved = (): JSX.Element[] | [] => {
        return companies.map((company: CompanyInfo, index: number) => (
            <CompanyInfoDetail company={company} key={index} />
        ));
    };

    return (
        <div className='CompaniesSavedPage'>
            {renderCompaniesSaved()}
        </div>
    );
};

export default CompaniesSaved;
