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