class CommentBox extends React.Component {
    klik() {
        console.log("Ja sam ja jeremija");
    }
    render() {
        return (
            <div className="glavniDiv">
                <button onClick={this.klik} className="btnKlik">Posalji poruku</button>
            </div>
            
           

        );
    }
}

ReactDOM.render(React.createElement(CommentBox, { name: "World" }), document.getElementById('content'));

