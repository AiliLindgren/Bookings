console.log("hej")

function SayHello() {
    console.log("hej")
}
//dropdown
/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}
let index = 0;
function AddAmount() {
    index++;
    result = index;
    if (index < 0) {

        alert("Don't even think about it")

    }
    else
        document.getElementById("result").innerText = result;
}
function DecreaseAmount() {
    index--;
    let result = index;
    if (index < 0)
        alert("Don't even think about it")
    else
        document.getElementById("result").innerText = result;
}
//popuptime
var tpick = {
    attach: function (target) {
        // attach() : attach time picker to target

        // Generate a unique random ID for the time picker
        var uniqueID = 0;
        while (document.getElementById("tpick-" + uniqueID) != null) {
            uniqueID = Math.floor(Math.random() * (100 - 2)) + 1;
        }

        // Create wrapper
        var tw = document.createElement("div");
        tw.id = "tpick-" + uniqueID;
        tw.classList.add("tpop");
        tw.dataset.target = target;
        tw.addEventListener("click", function (evt) {
            if (evt.target.classList.contains("tpop")) {
                this.classList.remove("show");
            }
        });

        // Create new time picker
        var tp = document.createElement("div");
        tp.classList.add("tpicker");

        // Create hour picker
        tp.appendChild(this.draw("h"));
        tp.appendChild(this.draw("m"));
        tp.appendChild(this.draw("ap"));

        // OK button
        var bottom = document.createElement("div"),
            ok = document.createElement("input");
        ok.setAttribute("type", "button");
        ok.value = "OK";
        ok.addEventListener("click", function () { tpick.set(this); });
        bottom.classList.add("tpicker-btn");
        bottom.appendChild(ok);
        tp.appendChild(bottom);

        // Attach time picker to body
        tw.appendChild(tp);
        document.body.appendChild(tw);

        // Attach on focus event
        var target = document.getElementById(target);
        target.dataset.dp = uniqueID;
        target.onfocus = function () {
            document.getElementById("tpick-" + this.dataset.dp).classList.add("show");
        };
    },

    draw: function (type) {
        // draw() : support function to create the hr, min, am/pm selector

        // Create the controls
        var docket = document.createElement("div"),
            up = document.createElement("div"),
            down = document.createElement("div"),
            text = document.createElement("input");
        docket.classList.add("tpicker-" + type);
        up.classList.add("tpicker-up");
        down.classList.add("tpicker-down");
        up.innerHTML = "&#65087;";
        down.innerHTML = "&#65088;";
        text.readOnly = true;
        text.setAttribute("type", "text");

        // Default values + click event
        // You can do your own modifications here
        if (type == "h") {
            text.value = "12";
            up.addEventListener("click", function () { tpick.spin("h", 1, this); });
            down.addEventListener("click", function () { tpick.spin("h", 0, this); });
        } else if (type == "m") {
            text.value = "10";
            up.addEventListener("click", function () { tpick.spin("m", 1, this); });
            down.addEventListener("click", function () { tpick.spin("m", 0, this); });
        } else {
            text.value = "AM";
            up.addEventListener("click", function () { tpick.spin("ap", 1, this); });
            down.addEventListener("click", function () { tpick.spin("ap", 0, this); });
        }

        // Complete + return the docket
        docket.appendChild(up);
        docket.appendChild(text);
        docket.appendChild(down);
        return docket;
    },

    spin: function (type, direction, el) {
        // spin() : when the up/down button is pressed

        // Get current field + value
        var parent = el.parentElement,
            field = parent.getElementsByTagName("input")[0],
            value = field.value;

        // Spin it
        if (type == "h") {
            value = parseInt(value);
            if (direction) { value++; } else { value--; }
            if (value == 0) { value = 12; }
            else if (value > 12) { value = 1; }
        } else if (type == "m") {
            value = parseInt(value);
            if (direction) { value += 15; } else { value -= 15; }
            if (value < 0) { value = 55; }
            else if (value > 60) { value = 0; }
            if (value < 10) { value = "0" + value; }
        }
        else {
            value = value == "PM" ? "AM" : "PM";
        }
        field.value = value;
    },

    set: function (el) {
        // set() : set the selected time on the target

        // Get the parent container
        var parent = el.parentElement;
        while (parent.classList.contains("tpop") == false) {
            parent = parent.parentElement;
        }

        // Formulate + set selected time
        var input = parent.querySelectorAll("input[type=text]");
        var time = input[0].value + ":" + input[1].value + " " + input[2].value;
        document.getElementById(parent.dataset.target).value = time;

        // Close popup
        parent.classList.remove("show");
    }
};
//calender
let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();
let selectYear = document.getElementById("year");
let selectMonth = document.getElementById("month");

let months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

let monthAndYear = document.getElementById("monthAndYear");
showCalendar(currentMonth, currentYear);


function next() {
    currentYear = (currentMonth === 11) ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    showCalendar(currentMonth, currentYear);
}

function previous() {
    currentYear = (currentMonth === 0) ? currentYear - 1 : currentYear;
    currentMonth = (currentMonth === 0) ? 11 : currentMonth - 1;
    showCalendar(currentMonth, currentYear);
}

function jump() {
    currentYear = parseInt(selectYear.value);
    currentMonth = parseInt(selectMonth.value);
    showCalendar(currentMonth, currentYear);
}

function showCalendar(month, year) {

    let firstDay = (new Date(year, month)).getDay();
    let daysInMonth = 32 - new Date(year, month, 32).getDate();

    let tbl = document.getElementById("calendar-body"); // body of the calendar

    // clearing all previous cells
    tbl.innerHTML = "";

    // filing data about month and in the page via DOM.
    monthAndYear.innerHTML = months[month] + " " + year;
    selectYear.value = year;
    selectMonth.value = month;

    // creating all cells
    let date = 1;
    for (let i = 0; i < 6; i++) {
        // creates a table row
        let row = document.createElement("tr");

        //creating individual cells, filing them up with data.
        for (let j = 0; j < 7; j++) {
            if (i === 0 && j < firstDay) {
                let cell = document.createElement("td");
                let cellText = document.createTextNode("");
                let cellbutton = document.createElement("button")
                cell.appendChild(cellText);
                row.appendChild(cell);
                cell.appendChild(cellbutton);
            }
            else if (date > daysInMonth) {
                break;
            }

            else {
                let cell = document.createElement("td");
                let cellText = document.createTextNode(date);
                if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
                    cell.classList.add("bg-info");
                } // color today's date
                cell.appendChild(cellText);
                row.appendChild(cell);
                date++;
            }


        }

        tbl.appendChild(row); // appending each row into calendar body.
    }

}