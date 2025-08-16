import React, {Component} from 'react';
import { Link } from 'react-router-dom';

const Menu = () => {
  return(
    <div>
      <p>**Welcome to Stock Page***</p>
      <br/>
      <Link to="/stockShow">Show Stock</Link>
      &nbsp;&nbsp;&nbsp;&nbsp;
      <Link to="/stockSearch">Search Stock</Link>
      &nbsp;&nbsp;&nbsp;&nbsp;
      <Link to="/stockAdd">Add Stock</Link>
    </div>
  )
}

export default Menu;