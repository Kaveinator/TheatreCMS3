function toggleCheck() {

    let damages = document.getElementById("damage-label");
    let notes = document.getElementById("notes-label");
    if (damages.hidden === true) {
        damages.hidden = false;
        notes.hidden = true;
    } else {
        damages.hidden = true;
        notes.hidden = false;
    }
}

$(document).ready(function () {
    $('.dropdown').hover(function () {
        $(this).addClass('show');
        $(this).find('.dropdown-menu').addClass('show');
    }, function () {
        $(this).removeClass('show');
        $(this).find('.dropdown-menu').removeClass('show');
    });
});
$(document).ready(function () {
   
    $('#partial-load').load('/Rent/RentalHistories/testPartial');
   
});

const select = document.getElementById('select');

select.addEventListener('change', function handleChange(event) {
    console.log(event.target.value);
    var sortOrder = event.target.value
    $('#partial-load').load('/Rent/RentalHistories/testPartial/?sortOrder='+sortOrder);

    
});


if (document.getElementById("check").checked === true) {
    document.getElementById("damage-label").hidden = false;
    document.getElementById("notes-label").hidden = true;
} else {
    document.getElementById("damage-label").hidden = true;
    document.getElementById("notes-label").hidden = false;
}

