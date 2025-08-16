const initialState = {
    sname : ''
}

const NameReducer = (state = initialState, action) => {
    switch(action.type) {
        case 'SACHIN' :
            return {...state,sname:'Hi I am Sachin'};
        case 'KANE' : 
            return {...state,sname:'Hi I am Kane'};
        case 'SATHWIK' : 
            return {...state,sname:'HI I am Sathwik'}
        default : 
            return state;
    }
}

export default NameReducer;