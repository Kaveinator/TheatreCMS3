$(document).ready(function () {
    $("#myCheck input[type='checkbox']").click(function () {
        var label = $("label[for='DamagesIncurred']");

        if (this.checked) {
            label.text("Damages Incurred");
            /*$(".RH-index-damaged").html('<span class="bi bi-x-circle-fill red-color"></span>');*/
        } else {
            label.text("Notes");
            /*$(".RH-index-damaged").html('<span class="bi bi-check-circle-fill green-color"></span>');*/
        }
    });
});

function sortList() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementsByClassName("RH-index-rentalname");
    switching = true;

    while (switching) {
        switching = false;
        rows = table.rows;

        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;

            x = rows[i].getElementsByClassName("RH-index-rentalname")[0];
            y = rows[i + 1].getElementsByClassName("RH-index-rentalname")[0];
            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
        }
    }
    
}

function myFunction() {
    document.getElementByClass("RH-index-sortdrop").classList.toggle("show");
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.RH-index-sortdrop')) {
        var dropdowns = document.getElementsByClassName("RH-index-sortcontent");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}

