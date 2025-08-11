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

function App() {
  return (
    <div className="App">
      <p>Welcome to React Programming...From Wipro</p>

      <p>
        <First/>
      </p>

      <p>
        <Second/>
      </p>

      <p>
        <Third firstName="Sathwik Reddy" lastName="Gunukula" company="Wipro" />
      </p>

      <p>
        <Four/>
      </p>

      <p>
        <ButtonEx/>
      </p>

      <p>
        <Five/>
      </p>

      <p>
        <Six/>
      </p>

      <p>
        <Seven/>
      </p>

      <p>
        <Eight/>
      </p>

    </div>
  );
}

export default App;
