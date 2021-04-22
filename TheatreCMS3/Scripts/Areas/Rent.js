function rentalChange(value) {
    var hideElements = document.getElementsByClassName("to-hide");
    for (i = 0; i < hideElements.length; i++) {
        var listOfClasses = hideElements[i].classList;
        if (listOfClasses.contains("d-none")) {
            continue;
        }
        else {
            listOfClasses.add("d-none");
        }
    }
    var hiddenElements = document.getElementsByClassName(value);
    for (i = 0; i < hiddenElements.length; i++) {
        hiddenElements[i].classList.remove("d-none");
    }
    document.getElementById("rentalType").value = value
}