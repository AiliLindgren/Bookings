function changeAmount(operator, price, numberOfPeople, totalPrice, totalPeople) {
    let itemPrice = parseFloat(price)
    let newNumberOfPeople = parseFloat(document.getElementById(numberOfPeople).innerText)
    let newTotalPrice = parseFloat(document.getElementById(totalPrice).innerText)
    let newTotalPeople = parseFloat(document.getElementById(totalPeople).innerText)

    if (operator === '+' && newNumberOfPeople < 5) {
        newNumberOfPeople++
        newTotalPrice += itemPrice
        newTotalPeople++
    }
    if (operator === '-' && newNumberOfPeople > 0) {
        newNumberOfPeople--
        newTotalPrice -= itemPrice
        newTotalPeople--
    }
    document.getElementById(numberOfPeople).innerText = newNumberOfPeople
    document.getElementById(totalPrice).innerText = newTotalPrice
    document.getElementById(totalPeople).innerText = newTotalPeople
}

function SendDateAndTime() {    
    var DateAndTime = document.getElementById("ProductID").value
    document.getElementById("chosenDateAndTime").innerText = DateAndTime
}

function Tid() {
    var x = document.getElementById("myBtn").value;
    document.getElementById("demo").innerHTML = x;
}

//    once the value from your C# code is stored then you can get it value by javascript

//    var myval = document.getElementById("ProductID").value;


//var obj = { name: "John", age: 30, city: "New York" };
//var myJSON = JSON.stringify(obj);
//document.getElementById("demo").innerHTML = myJSON;

//function myFunction() {
//    var x = document.getElementsByTagName("H1")[0].getAttribute("class");
//    document.getElementById("demo").innerHTML = x;