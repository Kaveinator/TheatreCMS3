var label = document.getElementById("damages");
var checkbox = document.getElementById("isDamaged");

checkbox.addEventListener("change", function () {
    if (this.checked == true) {
        label.innerHTML = "Damages Incurred";
    } else {
        label.innerHTML = "Notes";
    }
});

//function labelToggle() {
//    if (label.checked == true) {
//        label.innerHTML = "Damages Incurred";
//    } else {
//        label.innerHTML = "Notes";
//    }
//}


