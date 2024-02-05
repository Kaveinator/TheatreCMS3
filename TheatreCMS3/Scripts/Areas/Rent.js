console.log("HelloWorld");

$(function () {
    $("#RentalType").change(function () {
        var selectedType = $(this).val();
        $(".rentalEquipmentContainer, .rentalRoomContainer").hide();
        if (selectedType === "RentalEquipment") {
            $(".rentalEquipmentContainer").show();
        } else if (selectedType === "RentalRoom") {
            $(".rentalRoomContainer").show();
        }
    });
});


//Function for RentalHistory model, Create and Edit pages:
window.onload = function () {
    labelNameChangeFunction();
};
function labelNameChangeFunction() {
    var DamagesIncurredlabelvalue = document.getElementById('RentalHistory-create--damagesIncurredLabel');
    var Noteslabelvalue = document.getElementById('RentalHistory-create--notesLabel');
    var checkboxValue = document.getElementById('rentalDamageCheckbox').checked;

    if (checkboxValue) {
        DamagesIncurredlabelvalue.style.display = "block";
        Noteslabelvalue.style.display = "none";
    }

    else
    {
        Noteslabelvalue.style.display = "block";
        DamagesIncurredlabelvalue.style.display = "none";
    }
}

$(document).ready(function () {
    $('.RentalHistory-index--tr').hover(
        function () {
            $(this).find('.RentalHistory-index--dropdownMenuButton').show();
        },
        function () {
            $(this).find('.RentalHistory-index--dropdownMenuButton').hide();
        }
    );
});

//Filtering function:
function filterTable() {
    var dropdown = document.getElementById("sortingSelect")
    var selectedValue = dropdown.value;

    if (selectedValue === "rentalsAtoZ") {
        function sortTable() {
            var table, rows, switching, i, x, y, shouldSwitch;
            table = document.getElementById("myTable");
            switching = true;
            //Set the sorting direction to ascending:
            dir = "asc";
            /*Make a loop that will continue until
            no switching has been done:*/
            while (switching) {
                //start by saying: no switching is done:
                switching = false;
                rows = table.rows;
                console.log(rows);
                /*Loop through all table rows*/
                for (i = 1; i < rows.length - 1; i++) {
                    //start by saying there should be no switching:
                    shouldSwitch = false;
                    /*Get the two elements you want to compare,
                    one from current row and one from the next:*/
                    x = rows[i].getElementsByTagName("td")[2].innerText.toLowerCase();
                    console.log("x: " + x);
                    y = rows[i + 1].getElementsByTagName("td")[2].innerText.toLowerCase();
                    console.log("y: " + y);
                    /*check if the two rows should switch place,
                    based on the direction, asc or desc:*/
                    if (x > y) {
                        //if so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    /*If a switch has been marked, make the switch
                    and mark that a switch has been done:*/
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
        }
        return sortTable();
    }
    else if (selectedValue === "rentalsZtoA") {
        function sortTable() {
            var table, rows, switching, i, x, y, shouldSwitch;
            table = document.getElementById("myTable");
            switching = true;
            dir = "desc";
            while (switching) {
                switching = false;
                rows = table.rows;
                console.log(rows);
                for (i = 1; i < rows.length - 1; i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[2].innerText.toLowerCase();
                    console.log("x: " + x);
                    y = rows[i + 1].getElementsByTagName("td")[2].innerText.toLowerCase();
                    console.log("y: " + y);
                    if (x < y) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
        }
        return sortTable();
    }

    else if (selectedValue === "damagedrentals")
    {
        function sortTable() {
            var table, rows, switching, i, x, y, shouldSwitch;
            table = document.getElementById("myTable");
            switching = true;
            while (switching) {
                switching = false;
                rows = table.rows;
                console.log(rows);
                for (i = 1; i < rows.length - 1; i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[1].innerHTML.toLowerCase();
                    console.log("x: " + x);
                    y = rows[i + 1].getElementsByTagName("td")[1].innerHTML.toLowerCase();
                    console.log("y: " + y);
                    if (x < y) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
        }
        return sortTable();
    }

    else if (selectedValue === "undamagedrentals")
    {
        function sortTable() {
            var table, rows, switching, i, x, y, shouldSwitch;
            table = document.getElementById("myTable");
            switching = true;
            while (switching) {
                switching = false;
                rows = table.rows;
                console.log(rows);
                for (i = 1; i < rows.length - 1; i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[1].innerHTML.toLowerCase();
                    console.log("x: " + x);
                    y = rows[i + 1].getElementsByTagName("td")[1].innerHTML.toLowerCase();
                    console.log("y: " + y);
                    if (x > y) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
        }
        return sortTable();
    }
    
}