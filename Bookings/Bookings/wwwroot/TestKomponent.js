﻿function changeAmount(operator, price, numberOfPeople, totalPrice, totalPeople) {
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
    //$('#totalPeople').text(selectElement.value);
    $('#totalPeopleHidden').val(newTotalPeople);
    //ChangeMonth(new Date().getMonth,numberOfPeople)
}

function aFunction(selectElement) {

    $('#chosenDateAndTime').text(selectElement.value);
    $('#chosenDateAndTimeHidden').val(selectElement.value);
}


//function SendDateAndTime() {
//    var DateAndTime = document.getElementById("ProductID").value
//    document.getElementById("chosenDateAndTime").innerText = DateAndTime
//}

//function Tid() {
//    var x = document.getElementById("myBtn").value;
//    document.getElementById("demo").innerHTML = x;
   
//}