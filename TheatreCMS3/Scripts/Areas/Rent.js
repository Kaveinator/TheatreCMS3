// Rental History Create
var Counter = 0;
function checkLink() {
    Counter += 1;
    if (Counter % 2 == 0) {
        document.getElementById("Switch").innerHTML = "Notes"
    }
    else {
        document.getElementById("Switch").innerHTML = "Damages"
    }
}

