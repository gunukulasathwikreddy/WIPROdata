import axios from 'axios';
import React, {Component, useState} from 'react';
import Menu from '../menu/menu';

const StockSearch = () => {
  const [stockID, SetStockID] = useState(0)
  const [stockData, SetStockData] = useState({});

 const handleChange = event => {
        SetStockID(event.target.value)
    }

    const show = () => {
      let sid = parseInt(stockID);
      axios.get("http://localhost:5223/api/Stock/"+sid).then(
            (response) => {
                SetStockData(response.data)
            }  
          )
    }

    return(
      <div>
        <Menu/>
        <br/>
         <label>
                Stock ID : </label>
            <input type="number" name="stockID" 
                value={stockID} onChange={handleChange} /> <br/>
            <input type="button" value="Show" onClick={show} />
            <hr/>
            Stock ID : <b> {stockData.stockID}</b> <br/>
            Stock Name : <b>{stockData.stockName}</b> <br/>
            Quantity : <b>{stockData.quantity}</b> <br/>
            Price : <b>{stockData.price}</b> <br/>
      </div>
    )
  

}

export default StockSearch;