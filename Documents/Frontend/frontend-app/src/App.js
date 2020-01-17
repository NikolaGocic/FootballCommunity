import React from 'react';
import logo from './logo.svg';
import './App.css';
import Home from './components/home'
import Login from './components/login'
import Navigation from './components/navigation';
import Fixtures from './components/fixtures';


import createHistory from 'history/createBrowserHistory';
import {Switch,Route,Router} from 'react-router-dom';



import Button from 'react-bootstrap/Button';


const history = createHistory();   


class App extends React.Component {
  constructor(props){
    super(props);

  }

  render() {
    return (
    <Router history={history} forceRefresh={true}>
      <div id="continer">
      
      <Switch>
            
            <Route exact path='/' component={Home}  />  
            <Route path='/login'  component={Login} />  
            <Route path='/fixtures' component={Fixtures} />
    
      </Switch>

      </div>






        


    </Router>

  );
  }
}

export default App;
