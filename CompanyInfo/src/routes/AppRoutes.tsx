import { Route, Routes } from "react-router-dom";
import CompaniesSaved from "../Pages/CompaniesSaved";
import Homepage from "../Pages/HomePage";

const AppRoutes = () => {
    return (
        <Routes>
            <Route path='/' element={<Homepage />} />
            <Route path='/Companies' element={<CompaniesSaved />} />
        </Routes>
    );
}

export default AppRoutes;