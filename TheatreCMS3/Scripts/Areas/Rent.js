var label = document.getElementById("damages");
var checkbox = document.getElementById("isDamaged");

// changes label from Notes to Damages incurred on create page
checkbox.addEventListener("change", function () {
    if (this.checked == true) {
        label.innerHTML = "Damages Incurred";
    } else {
        label.innerHTML = "Notes";
    }
});

// loads the proper label depending if the checkbox is already checked
window.addEventListener("load", function () {
    if (checkbox.checked == true) {
        label.innerHTML = "Damages Incurred";
    } else {
        label.innerHTML = "Notes";
    }
});



