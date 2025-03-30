import "./App.css";
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from "./pages/HomePage";
import MovieDetailsPage from "./pages/MovieDetailsPage";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <header className="App-header">
          <nav className="navbar ">
            <div className="container-fluid">
              <a className="navbar-brand text-white" href="/" >
                AuraFlix
              </a>
            </div>
          </nav>
        </header>

        <main className="App-main">
          <Routes>
            <Route index path='/' element={<HomePage />}/>
            <Route path="/MovieDetailsPage/:id" element={<MovieDetailsPage />} />
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  );
}

export default App;
