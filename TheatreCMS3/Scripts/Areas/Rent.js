﻿try {
    changeDamagedToNotes();
} catch {
    console.error();
}

function changeDamagedToNotes() {
    var checkbox = document.getElementById("RentalDamaged")
    if (checkbox.checked == true) {
        console.log("Checkbox is checked.." + checkbox.checked);
        document.getElementById("damages-incurred").style.display = 'flex';
        document.getElementById("notes").style.display = 'none';
    }
    else {
        console.log("Checkbox is not checked..");
        document.getElementById("damages-incurred").style.display = 'none';
        document.getElementById("notes").style.display = 'flex';
    }
}

function test() {
    $.ajax({
        type: "POST",
        url: "NoSorting",
        success: function (result) {
/*            alert('ok');*/
            $('#rental-list').html(result);
        },
        error: function (result) {
            console.log('error');
        }
    });
}
