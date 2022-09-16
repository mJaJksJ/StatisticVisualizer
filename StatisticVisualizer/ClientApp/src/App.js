import React, { Component } from 'react';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <>
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
                    <a className="nav-link text-white">Загрузить файл</a>
                  </li>
                  <li className="nav-item">
                    <a className="nav-link text-white">Статистика</a>
                  </li>
                </ul>
              </div>
            </div>
          </nav>
        </header>

        <div class="container">
          <main role="main" class="pb-3">
          </main>
        </div>

        <footer class="border-top footer text-muted">
          <div class="container">
            &copy; 2022 - StatisticVisualizer - <a href="https://github.com/mJaJksJ">mJaJksJ</a>
          </div>
        </footer>
      </>
    );
  }
}
