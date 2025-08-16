import axios from 'axios';
import React, {Component, useState} from 'react';
import { useNavigate } from 'react-router-dom';

const StockAdd = () => {
  const navigate = useNavigate();
   const [data, setData] = useState({
        stockName : '',
        quantity : 0,
        price : 0
    })

    const addStock = () => {
      axios.post("http://localhost:5223/api/Stock",{
        stockName : data.stockName,
        quantity : data.quantity,
        price : data.price,
      }).then(resp => {
          alert(resp.data);
          console.log(resp.data);
        })
        setTimeout(() => {
      // console.log("This runs after 5 seconds!");
          navigate("/stockShow");
    }, 5000);
    }

    const handleChange = event => {
        setData({
            ...data,[event.target.name] : event.target.value  
        })
    }

     return (
    <div>
            <label>Stock Name : </label>
            <input type="text" name="stockName" 
                value={data.stockName} onChange={handleChange} /> <br/><br/> 
            <label>Quantity : </label>
            <input type="number" name="quantity" 
                value={data.quantity} onChange={handleChange} /> <br/><br/> 
            <label>Price : </label>
            <input type="number" name="price" 
                value={data.price} onChange={handleChange} /> <br/><br/> 
            <input type="button" value="Add Stock" onClick={addStock} />

    </div>
  )


}

export default StockAdd;