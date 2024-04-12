import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import NavigatorBar from './components/NavigationBar/index.tsx'
import AppRoutes from './routes/AppRoutes.tsx'

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <BrowserRouter>
            <NavigatorBar/>
            <AppRoutes/>
        </BrowserRouter>
    </React.StrictMode>,
)
