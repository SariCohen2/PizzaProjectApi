let basicUrl = 'https://localhost:7150/PizzaShop/';
let basicToken = "";
function Get(params) {
    fetch(`${basicUrl}get/`)
        .then((res) => res.json())
        .then((data) => fillPizzaList(data))
        .catch(err => { console.log(err) })
}
function fillPizzaList(pizzaList) {
    var tbody = document.getElementById('pizzatbody');
    tbody.innerHTML = "";
    pizzaList.forEach(pizza => {
        tbody.innerHTML +=
            `<tr>
        <td>${pizza.name}    </td>
        <td>${pizza.gluten}</td>
        <td>${pizza.price}</td>
        <td>${pizza.id}</td>
        </tr>`
    });
}
function Post() {
    var name = prompt("insert name");
    var price = prompt("insert price");
    var gluten = prompt("if not contain gluten insert 0, else everything");
    if (gluten == 0)
        gluten = true;
    else
        gluten = false;
    const myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + basicToken);
    myHeaders.append("Content-Type", "application/json");
    fetch(`${basicUrl}new`,
        {
            method: 'post',
            mode: 'cors',
            headers: myHeaders,
            body: JSON.stringify({ "id": 0, "name": `${name}`, "price": price, "gluten": gluten })
        })
        .then(response => response.json())
        .then(result =>console.log(result))
        .catch(error => console.log('error in root in post', error));
}
function GetId() {
    let id = prompt("insert number");
    fetch(`${basicUrl}getId/${id}`,
        {
            method: 'GET',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
        })
        .then(response => response.json())
        .then(result => printGetId(result))
        .catch(error => console.log('error', error));
}
function printGetId(result) {
    document.getElementById("getId").innerHTML += " שם המוצר:" + result.name + ", קוד המוצר:" + result.id + ", מחיר המוצר:" + result.price + `<br>`;
}
function Put() {
    var id = prompt("insert id");
    var name = prompt("insert name");
    var price = prompt("insert price");
    var gluten = prompt("if not contain gluten insert 0, else everything");
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + basicToken);
    myHeaders.append("Content-Type", "application/json");

    if (gluten == 0)
        gluten = true;
    else
        gluten = false;
    fetch(`${basicUrl}update`,
        {
            method: 'Put',
            mode: 'cors',
            headers: myHeaders,
            body: JSON.stringify({ "id": id, "name": `${name}`, "price": price, "gluten": gluten })
        })
        .then(res => console.log(res))
        .catch(error => console.log('error', error));
}
function Delete() {
    let id = prompt("insert id");
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + basicToken);
    myHeaders.append("Content-Type", "application/json");
    fetch(`${basicUrl}delete/${id}`,
        {
            method: 'Delete',
            mode: 'cors',
            headers: myHeaders,
        })
        .then(res => console.log(res))
        .catch(error => console.log('error', error));
}

const url = 'https://localhost:7150/Login';

function Login() {
    var myHeaders = new Headers();
    const name = document.getElementById('usrname').value.trim();
    const password = document.getElementById('psw').value.trim();
    var theSite = document.getElementById("theSite");
    myHeaders.append("Content-Type", "application/json");
    var raw = JSON.stringify({
        Name: name,
        Password: password
    })
    var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: raw,
        redirect: "follow",
    };
    fetch(`${url}/Login`, requestOptions)
        .then((response) => response.text())
        .then((result) => {
            basicToken = result;
            if (basicToken.toString().includes("Microsoft.Asp")) {
                // alert("(˘･_･˘)שלום לך, אינך מוכר במערכת");
                document.getElementById("h1").innerHTML = " ברוכים הבאים " +name+" הינך מזוהה במערכת כלקוחה";
            }
            else {
                // alert("שלום לך, הינך מזוהה במערכת(●'◡'●)");
                document.getElementById("h1").innerHTML = " שלום לך! "+" הינך מזוהה במערכת כעובד "+name;
            }
            document.getElementById("container").innerHTML = "";
            document.getElementById("container").style.display = "none";
            theSite.style.display = "block";

        }).catch((error) => alert("error", error));
}
