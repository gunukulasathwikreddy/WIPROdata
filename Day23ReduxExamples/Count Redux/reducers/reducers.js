const initialState = {
    count : 0
}

const CountReducer = (state = initialState, action) => {
    switch(action.type) {
        case 'INCREMENT' :
            return {...state,count: state.count + 1};
        case 'DECREMENT' :
            return {...state,count:state.count -1};
        case 'SQUARE' : 
            return {...state, count: Math.pow(state.count, 2)}; // you can also write state.count * state.count
        case 'MULBY6' : 
            return {...state, count : state.count * 6}
        default : 
            return state;  
    }
}

export default CountReducer;