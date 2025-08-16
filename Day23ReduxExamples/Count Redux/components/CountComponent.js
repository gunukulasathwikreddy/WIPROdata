import { useDispatch, useSelector } from "react-redux";
import { decrement, increment, mulby6, square } from "../actions/actions";


const CountComponent = () => {
    const count = useSelector( (state) => state.count);
    const dispatch = useDispatch();
    return(
        <div>
            Result is : <b>{count}</b> <hr/>
            <input type="button" value="Increment" 
                onClick={() => dispatch(increment())} /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="Decrement" 
                onClick={() => dispatch(decrement())} /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <input type="button" value="Square" 
                onClick={() => dispatch(square())} /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="Mulby6" 
                onClick={() => dispatch(mulby6())} />
        </div>
    )
}

export default CountComponent;