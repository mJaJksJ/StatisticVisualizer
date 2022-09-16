import React from 'react';
import { BrowserRouter, Link } from 'react-router-dom';
import './custom.css'
import AppRouter from './components/Router/AppRouter';

const App: React.FC = () => {
  {
    return (
      <BrowserRouter>
        <header>
          <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light border-bottom box-shadow mb-3" style={{ 'backgroundColor': '#148F2A' }}>
            <div className="container-fluid">
              <a className="navbar-brand text-white">StatisticVisualizer</a>
              <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
              </button>
              <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                <ul className="navbar-nav flex-grow-1">
                  <li className="nav-item">
                    <Link to="/upload" className="nav-link text-white">Загрузить файл</Link>
                  </li>
                  <li className="nav-item">
                    <Link to="/statistic" className="nav-link text-white">Статистика</Link>
                  </li>
                </ul>
              </div>
            </div>
          </nav>
        </header>

        <div className="container">
          <main role="main" className="pb-3">
            <AppRouter />
          </main>
        </div>

        <footer className="border-top footer text-muted">
          <div className="container">
            &copy; 2022 - StatisticVisualizer - <a href="https://github.com/mJaJksJ">mJaJksJ</a>
          </div>
        </footer>
      </BrowserRouter>
    );
  }
}

export default App