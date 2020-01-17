alert("Jedi govna");

function napraviOsnovno() {

    let btnProba = document.createElement("button");
    btnProba.innerHTML = "Klik";
    btnProba.className = "proba";
    document.body.appendChild(btnProba);

    btnProba.onclick = function () {
        console.log("Porukaaaa");
    }
}

this.napraviOsnovno();