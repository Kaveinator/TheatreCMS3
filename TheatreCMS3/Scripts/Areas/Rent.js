

// This function takes 1 parameter named whatever you want
// The parameter comes from "LabelChanger(this)" found in Create.cshtml and Edit.cshtml
function LabelChanger(checkbox) { // checked == (this)
    if (checkbox.checked) { // if if (this) is checked
        var newLabel = "DamagesIncurred";
        document.getElementById("Rent-Create--Label").innerHTML = newLabel;        
    }
    else { // if (this) is not checked
        var newLabel = "Notes";
        document.getElementById("Rent-Create--Label").innerHTML = newLabel;        
    }
}

