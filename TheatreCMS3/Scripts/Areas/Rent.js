/*  ==========================================
 CHANGE LABEL TEXT FROM NOTES TO DAMAGED INCURRED
* ========================================== */
//function changed() {
//    let damagedIncurred = document.getElementsByClassName("check-box");
//    let notes = document.getElementById("changeName");
//    if (!damagedIncurred.checked) {
//        notes.te = "Damaged Incurred";
//    }
//    else {
//        notes.innerHTML = "Damaged Incurred";
//    }
//}

function changedText() {
    var damageIncurred = document.getElementById("RentalDamaged");
    var text = document.getElementById("changeName");

    if (damageIncurred.checked == true) {
        text.innerHTML = "Damaged Incurred"
    }
    else {
        text.innerHTML = "Damaged Incurred"
    }

}

  