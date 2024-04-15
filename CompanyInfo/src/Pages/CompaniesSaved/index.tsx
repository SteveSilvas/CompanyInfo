import React, { useEffect, useState } from "react";
import { CompanyInfo } from "../../@types/types";
import api from "../../Services/Api";
const CompaniesSaved: React.FC = () => {
    const [companies, setCompanies] = useState<CompanyInfo[]>([]);
    useEffect(() => {
        requestCompanies();
    }, []);

    const requestCompanies = () => {
        api.get(`Activity/GetAllAtividades`)
            .then((response) => {
                setCompanies(response.data);
            })
            .catch((ex) => {
                console.error(ex)
            });
    }
    const renderCompaniesSaved = (): JSX.Element[] | []=> {
        return companies.map((company: CompanyInfo, index: number) => (
            <div 
                style={{ display: "flex", gap: "20px", backgroundColor: "gray", padding: "10px", margin: '0px' }}
                key={index}
            >
                {company.fantasia}
            </div>
        ));
    }
    return (
        <div className='CompaniesSaved'>
            CompaniesSaved
            {renderCompaniesSaved()}
        </div>
    );
}

export default CompaniesSaved;