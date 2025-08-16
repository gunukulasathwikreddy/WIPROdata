import logo from './logo.svg';
import './App.css';
import StockShow from './components/stockShow/stockShow';
import StockSearch from './components/stockSearch/stockSearch';
import StockAdd from './components/stockAdd/stockAdd';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Menu from './components/menu/menu';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Menu />} />
        <Route path = "/stockShow" element = {<StockShow/>}/>
        <Route path = "/stockSearch" element = {<StockSearch/>}/>
        <Route path = "/stockAdd" element = {<StockAdd/>}/>
      </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
