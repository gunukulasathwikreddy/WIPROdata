import logo from './logo.svg';
import './App.css';
import First from './components/first/first';
import Second from './components/second/second';
import Third from './components/third/third';
import Four from './components/fourth/fourth';
import ButtonEx from './components/buttonex/buttonex';
import Five from './components/fifth/fifth';
import Six from './components/sixth/sixth';
import Seven from './components/seventh/seventh';
import Eight from './components/eigth/eigth';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Menu from './components/menu/menu';
import Login from './components/login/login';

function App() {
  return (
    <div className="App">
      <p>Welcome to React Programming...From Wipro</p>

      <BrowserRouter>
      <Routes>
         <Route path="/" element={<Login />} />
        <Route path="/menu" element ={<Menu/>}/>
        <Route path='/first' element={<First />} />
        <Route path='/second' element={<Second />} />
        <Route path='/third' element={<Third firstName="Sachin" lastName="Tendulkar" company="BCCI" />} />
        <Route path='/fourth' element={<Four />} />
        <Route path='/fifth' element={<Five />} />
        <Route path='/sixth' element={<Six />} />
        <Route path='/seventh' element={<Seven />} />
        <Route path='/eigth' element={<Eight />} />
        <Route path='/buttonex' element={<ButtonEx />} />
      </Routes>
      </BrowserRouter>

    </div>
  );
}

export default App;
