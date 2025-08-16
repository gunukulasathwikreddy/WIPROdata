import { createStore } from "@reduxjs/toolkit";
import CountReducer from "../reducers/reducers";

const Store = createStore(CountReducer);

export default Store;