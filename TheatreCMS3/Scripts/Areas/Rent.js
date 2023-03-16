// Function to change the label on the Create and Edit Form depending on checkbox
function notesToDamage(thecheckbox, thelabel) {

    var checkbox = document.getElementById(thecheckbox);
    var label = document.getElementById(thelabel);
    if (!checkbox.checked) {
        label.innerHTML = "Notes";
    }
    else {
        label.innerHTML = "Damages Incurred";
    }
}