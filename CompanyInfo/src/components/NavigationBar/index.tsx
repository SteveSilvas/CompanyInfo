import { Link } from "react-router-dom";
import './style.css';
const NavigationBar = () => {
    return (
        <nav className="NavigationBar">
            <Link className="Link" to="/">Home</Link>
            <Link className="Link" to="/Companies">Empresas</Link>
        </nav>
    );
}

export default NavigationBar;