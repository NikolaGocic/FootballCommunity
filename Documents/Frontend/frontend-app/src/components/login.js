import React,{Component} from 'react';
import ReactDOM from 'react-dom';
import FootballCommunity from "../FootballCommunity.svg";
import {NavLink} from 'react-router-dom'; 
import {Navbar,Nav} from 'react-bootstrap'; 

import createHistory from 'history/createBrowserHistory';

import Button from 'react-bootstrap/Button';

import {withRouter} from 'react-router-dom';

import "./style.scss";

const history=createHistory();

class Login extends Component {
    constructor(props){
        super(props);
        this.state={ isLoginOpen: true, isRegisterOpen: false};
    }

    showLoginBox(){
        this.setState({isLoginOpen:true, isRegisterOpen:false});
    }

    showRegisterBox(){
        this.setState({isLoginOpen:false, isRegisterOpen:true});
    }
    render (){
        return (
            <div className="root-container">
                <div className="box-controller">
                    <div className={"controller " + (this.state.isLoginOpen ? "selected-controller" : "")} onClick={this.showLoginBox.bind(this)}>
                        Login
                    </div>
                    <div className={"controller " + (this.state.isRegisterOpen ? "selected-controller" : "")} onClick={this.showRegisterBox.bind(this)}>
                        Register
                    </div>
                </div>
                <div id="box-container">
                    {this.state.isLoginOpen && <LoginBox />}
                    {this.state.isRegisterOpen && <RegisterBox />}

                </div>
            </div>

        );
    }
}





class LoginBox extends React.Component{
    constructor(){
        super();
        this.state={
            Username: '',
            Password: ''
        };

        this.Username=this.Username.bind(this);
        this.Password=this.Password.bind(this);
        this.submitLogin=this.submitLogin.bind(this);

    }

    submitLogin(event){
        debugger;
        fetch('https://localhost:44313/Api/login/Login',{
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body : JSON.stringify({
                Username: this.state.Username,
                Password: this.state.Password
            })
        }).then((Response) => Response.json())
            .then((result) =>{
                console.log(result);
                if(result.Status === 'Invalid')
                {
                    alert('Invalid User');
                }
                else
                {
                    history.push("/fixtures");
                }
            })
        
    }

    Password(event){
        this.setState({Password : event.target.value});
    }

    Username(event){
        this.setState({Username : event.target.value});

    }

    render(){
        return (
        <div className="inner-container">

            <div className="box-header">
                Login
            </div>

            <div className="image">
                <img src={FootballCommunity}></img>

            </div>

            <div className="box">


                <div className="input-group">
                    <label htmlFor="username">Username</label>
                    <input type="text" name="username" onChange={this.Username.bind(this)} className="login-input" placeholder="Username"></input>

                </div>

                <div className="input-group">
                    <label htmlFor="password">Password</label>
                    <input type="text" name="password" onChange={this.Password.bind(this)} className="login-input" placeholder="Password"></input>
                    
                </div>

                <div className="footer">
                    <Button type="button" className="login-btn" onClick={this.submitLogin.bind(this)}>Login</Button>
                </div>

                


            </div>
        </div>
        );
    }
}

class RegisterBox extends React.Component{
    constructor(){
        super();
        this.state={
            FirstName: '',
            LastName: '',
            Username: '',
            Password: '',
            Email: '',
        };

        this.FirstName=this.FirstName.bind(this);
        this.LastName=this.LastName.bind(this);
        this.Username=this.Username.bind(this);
        this.Password=this.Password.bind(this);
        this.Email=this.Email.bind(this);

    }

    FirstName(event){
        this.setState({FirstName: event.target.value});

    }

    LastName(event){
        this.setState({LastName: event.target.value});

    }

    Username(event){
        this.setState({Username: event.target.value});

    }

    Password(event){
        this.setState({Password: event.target.value});

    }

    Email(event){
        this.setState({Email: event.target.value});
    }

    submitRegister(event){
        console.log("123456");
        fetch('https://localhost:44313/Api/login/InsertUser',{
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                FirstName: this.state.FirstName,
                LastName: this.state.LastName,
                Username: this.state.Username,
                Password: this.state.Password,
                Email: this.state.Email
            })
        }).then((Response) => Response.json())
            .then((Result)=>{
                console.log("usao samo u rezulta");
                if(Result.Status === 'Success'){
                    console.log(this.history);
                    console.log(this.props);
                    console.log(this.props.router);
                    console.log(history);
                    history.push("/fixtures");
                    //this.history.push("/fixtures");

                }
                else
                {
                    alert('Sorrrrrry !!!! Un-authenticated User !!!!!');
                }
            })


    }

    render(){
        return (
        <div className="inner-container">
            <div className="box-header">
                Register
            </div>

            <div className="image">
                <img src={FootballCommunity}></img>

            </div>
            <div className="box">

                <div className="input-group">
                    <label htmlFor="firstName">FirstName</label>
                    <input type="text" name="FirstName" onChange={this.FirstName.bind(this)} className="register-input" placeholder="FirstName"></input>

                </div>

                <div className="input-group">
                    <label htmlFor="lastName">LastName</label>
                    <input type="text" name="lastName" onChange={this.LastName.bind(this)} className="register-input" placeholder="LastName"></input>

                </div>

                <div className="input-group">
                    <label htmlFor="username">Username</label>
                    <input type="text" name="username" onChange={this.Username.bind(this)} className="register-input" placeholder="Username"></input>

                </div>

                <div className="input-group">
                    <label htmlFor="password">Password</label>
                    <input type="text" name="password" onChange={this.Password.bind(this)} className="register-input" placeholder="Password"></input>
                    
                </div>

                <div className="input-group">
                    <label htmlFor="email">Email</label>
                    <input type="text" name="email" onChange={this.Email.bind(this)} className="register-input" placeholder="Email"></input>

                </div>

                <div className="footer">
                    <Button type="button" className="register-btn" onClick={this.submitRegister.bind(this)}>Register</Button>

                </div>

                


            </div>
        </div>
        );
    }
} 

export default withRouter(Login);








