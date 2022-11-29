window.onload = loadDisplay();

var acc = document.getElementsByClassName("RentalRequest-Index--accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");

        var panel = this.nextElementSibling;
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
          panel.style.maxHeight = panel.scrollHeight + "px";
        }
    });
}

// Hides expired rental requests when page loads
function loadDisplay() {
    var expiredDiv = document.getElementById("RentalRequest-Index--expiredDiv");
    expiredDiv.style.display = "none"
}

var btn = document.getElementById("RentalRequest-Index--button")

var current = true;

// Functionality for button to toggle between current and expired rental requests
function toggleRentals() {
    if (current) {
        btn.innerText = "Current Rentals";

        var currentDiv = document.getElementById("RentalRequest-Index--currentDiv");
        if (currentDiv.style.display === "none") {
            currentDiv.style.display = "block";
        } else {
            currentDiv.style.display = "none";
        }

        var expiredDiv = document.getElementById("RentalRequest-Index--expiredDiv");
        if (expiredDiv.style.display === "none") {
            expiredDiv.style.display = "block";
        } else {
            expiredDiv.style.display = "none";
        }

        current = false;
    }
    else if (!current) {
        btn.innerText = "Expired Rentals";

        var currentDiv = document.getElementById("RentalRequest-Index--currentDiv");
        if (currentDiv.style.display === "none") {
            currentDiv.style.display = "block";
        } else {
            currentDiv.style.display = "none";
        }

        var expiredDiv = document.getElementById("RentalRequest-Index--expiredDiv");
        if (expiredDiv.style.display === "none") {
            expiredDiv.style.display = "block";
        } else {
            expiredDiv.style.display = "none";
        }

        current = true;
    }
}