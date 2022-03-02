/*  ==========================================
 CHANGE LABEL TEXT FROM NOTES TO DAMAGED INCURRED
* ========================================== */

$("#RentalDamaged").click(function () {
    if (this.checked) {
        document.getElementById("changeLabel").innerHTML = "Damages Incurred";
    }
    else {
        document.getElementById("changeLabel").innerHTML = "Notes";
    }
});

// few other ways to write this code using vanilla js

//function changedText() {
//    try {
//        var damageIncurred = document.getElementById("RentalDamaged");
//        var text = document.getElementById("SpotToChange");

//        if (damageIncurred.checked == true) {
//            text.innerHTML = "Damaged Incurred"
//        }
//        else {
//            text.innerHTML = "Notes"
//        }
//    }
//    catch(e) {
//        alert(e.message);
//    }
//}

//function changeLabel(checkbox) {
//    if (checkbox.checked) {
//        document.getElementById("test").innerHTML = "Damaged Incurred";
//    }
//    else {
//        document.getElementById("test").innerHTML = "Notes";
//    }
//}
