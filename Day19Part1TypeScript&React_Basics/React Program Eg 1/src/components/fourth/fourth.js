import React, {Component, useState} from 'react';

const Four = () => {

  const [name,setName] = useState('')

  const ajay = () => {
    setName("Hi I am Ajay");
  }

  const pralavi = () => {
    setName("Hi I am Pralavi...");
  }

  const uday = () => {
    setName("Hi I am Uday...");
  }

  return(
    <div>
      <hr/>
      <input type="button" value="Ajay" onClick={ajay} />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Pralavi" onClick={pralavi} /> 
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Uday" onClick={uday} />
      <br/>
      <br/>
      Name is : <b>{name}</b>
      <hr/>
    </div>
  )
}

export default Four;