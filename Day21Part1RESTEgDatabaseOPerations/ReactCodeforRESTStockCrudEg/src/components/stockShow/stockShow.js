import axios from 'axios';
import React, {Component, useEffect, useState} from 'react';
import Menu from '../menu/menu';

const StockShow = () => {

  const [stocks,setStockData] = useState([])

  useEffect(() => {
    const fetchData = async () => {
      const response = await
        axios.get("http://localhost:5223/api/Stock");
        setStockData(response.data)
    }
    fetchData();
  },[])  
  return(
    <div>
      <Menu/>
      <br/>
      <table border="3" align="center">
        <tr>
          <th>Stock ID</th>
          <th>Stock Name</th>
          <th>Quantity</th>
          <th>Price</th>
        </tr>
        {stocks.map((item) =>
        <tr>
          <td>{item.stockID}</td>
           <td>{item.stockName}</td>
            <td>{item.quantity}</td>
           <td>{item.price}</td>
        </tr>
      )}
      </table>
    </div>
  )
}

export default StockShow;