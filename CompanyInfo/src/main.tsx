import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import NavigationBar from './components/NavigationBar/index.tsx'
import AppRoutes from './routes/AppRoutes.tsx'

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <BrowserRouter>
            <NavigationBar />
            <AppRoutes />
        </BrowserRouter>
    </React.StrictMode>,
)
