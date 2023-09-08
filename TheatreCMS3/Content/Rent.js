

function changeFunction() {
    var changes = "Damages Incurred";
    var changed = "Notes";
    const checkBox = document.querySelector("#check");

        if (checkBox.checked) {
            document.getElementById("change").innerHTML = changes;
        }
        else {
            document.getElementById("change").innerHTML = changed;
        }
    
}
