function is_Checked() {
    var checkbox = $('.check-box');
    console.log(checkbox);
    var checkbox = $('check-box input[type="checkbox"]');
    var isChecked = $("input[type=checkbox][name=RentalDamaged]:checked").val();
    console.log(isChecked);
    var label = $('.DamagedLabel');

    if (isChecked) {
    label.text('Damages Incurred');
} else {
    label.text('Notes');
}
}

//log the var to see what is coming across
//work code one line at a time to see the T/F check of the box
