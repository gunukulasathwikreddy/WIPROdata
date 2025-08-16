import { useDispatch, useSelector } from "react-redux";
import { sachin,kane,sathwik } from "../actions/actions";


const Names = () => {
    // Access the sname value from the Redux store
    const sname = useSelector( (state) => state.sname)
    // Get the dispatch function from Redux
    const dispatch = useDispatch();
    return (
        <div>
            <h1>Name is : {sname}</h1>
            <input type="button" value="Sachin" onClick={() => dispatch(sachin())} />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="Kane" onClick={() => dispatch(kane())} /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="Sathwik" onClick={() => dispatch(sathwik())} />
        </div>
    )
}

export default Names;