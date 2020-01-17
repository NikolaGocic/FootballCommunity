import React,{Component} from 'react';
import ReactDOM from 'react-dom';
import Navigation from './navigation';

class Fixtures extends Component{

    constructor(props){
        super(props);
        this.state={}
    }

    render (){
        return (
            <div className="div-container">
                <div className="div-header">

                </div>
                <div className="div-main">
                    <div className="div-navbar">
                        <Navigation></Navigation>

                    </div>
                    <div className="div-games">

                    </div>

                </div>
            </div>
        )
    }

}



export default Fixtures;