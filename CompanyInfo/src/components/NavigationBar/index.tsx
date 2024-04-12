import { Link } from "react-router-dom";

const NavigatorBar = () => {
    return (
        <nav style={{ display: "flex", gap: "20px", backgroundColor: "gray", padding: "10px", margin: '0px' }}>
            <Link className="Link" to="/">Home</Link>
            <Link className="Link" to="/Companies">Empresas</Link>
        </nav>
    );
}

export default NavigatorBar;