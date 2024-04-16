import { CompanyInfo } from "../../@types/types";
import './style.css';
interface ICompanyInfoDetail {
    company: CompanyInfo;
    handleSaveCompany?: (company: CompanyInfo) => void;
}
const CompanyInfoDetail: React.FC<ICompanyInfoDetail> = ({ company, handleSaveCompany }) => {

    const renderSaveButton = () => {
        if (handleSaveCompany) {
            return (
                <button
                    className="CompanySaveButton"
                    onClick={() => handleSaveCompany(company)}>
                    Salvar
                </button>
            )
        }
    }
    return (
        <div
            className="CompanyContainer">
            <h3 className="CompanyTitle">{company.nome}</h3>
            <div className="CompanyHr"></div>
            <div className="CompanyData">
                <div className="CompanyInfo">
                    <div>
                        <span className="CompanyInfoTitle">Fantasia:</span>
                        <span className="CompanyInfoValue">{company.fantasia}</span>
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
                    <div>
                        <span className="CompanyInfoTitle">Capital Social: </span>
                        <span className="CompanyInfoValue">{company.capitalSocial}</span>
                    </div>
                </div>
                <div className="CompanyInfo">
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
                        <div className="CompanyInfoValueBilling">
                            <span className="CompanyInfoTitle" style={{ fontWeight: "normal" }}>Free: </span>
                            <span className="CompanyInfoValue">{company.billing.free ? "Sim" : "Não"}</span>
                            <span className="CompanyInfoTitle" style={{ fontWeight: "normal" }}>Database: </span>
                            <span className="CompanyInfoValue">{company.billing.database ? "Sim" : "Não"}</span>
                        </div>

                    </div>
                </div>
            </div>
            {renderSaveButton()}
        </div>
    );
}

export default CompanyInfoDetail;