import React, {Component} from 'react';
import { Link } from 'react-router-dom';

const Menu = () => {
  return (
    <div>
      <p>Welcome to the MENU.</p>
      <Link to="/first">First</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/second">Second</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/third">Third</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/fourth">Four</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/fifth">Five</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/sixth">Six</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/seventh">Seven</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/eigth">Eight</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/buttonex">Button Example</Link>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
  )
}

export default Menu;