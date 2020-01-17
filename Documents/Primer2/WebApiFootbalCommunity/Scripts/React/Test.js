
class Test extends React.Component {
    showAlert() {
        alert("Alerttt");
    }

    render() { return
        (
            <div>
                <button onClick={this.showAlert}>Show Alert</button>
            </div>
        )
    }
}

