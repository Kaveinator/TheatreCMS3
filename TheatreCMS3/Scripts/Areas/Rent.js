window.addEventListener('load', function () {
    loadDisplay();
});

window.addEventListener('load', function () {
    toggleNotes();
});

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
    expiredDiv.style.display = "none";
}

var current = true;

// Functionality for button to toggle between current and expired rental requests
function toggleRentals() {
    var btn = document.getElementById("RentalRequest-Index--button");
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

// Create Rental History page

function toggleNotes() {
    var label = document.getElementById("RentalHistory-Create--label");
    var checkbox = document.getElementById("RentalHistory-Create--checkbox");

    if (checkbox.checked) {
        label.innerHTML = "Damages Incurred";
    }
    else if (!checkbox.checked) {
        label.innerHTML = "Notes";
    }
}
