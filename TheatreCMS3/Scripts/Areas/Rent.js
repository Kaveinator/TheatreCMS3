﻿$   //Function for changing the lable between notes and damage incurred
    (document).ready(function () {
    
    if ($('.check-box').is(':checked')) {
        $('.label-id').text('Damages Incurred');
    } else {
        $('.label-id').text('Notes');
    }

    $('.check-box').change(function () {
        console.log('Hello');
        if ($(this).is(':checked')) {
            $('.label-id').text('Damages Incurred');
        } else {
            $('.label-id').text('Notes');
        }
    });
});


//Funcitons for showing and hiding the dropdown button
$('.dropdown').find('.dropdown-btn').hide();                      //hide the dropdown button on load

$(document).ready(function () {
    $('.rental-item').hover(
        function () {
            $(this).find('.dropdown-btn').show();                 //on hover show the dropdown button for that row
        },
        function () {
            $(this).find('.dropdown-btn').hide();                //on un-hover hide the dropdown button for that row
        }
    );
});

//Function for sorting the table
$(document).ready(function () {
    $('#DropDownList').change(                                                   //On the change of the dropdown
        function () {
            if ($('#DropDownList option:selected').val() == "A-Z") {
                //console.log("A-Z");
                var $table = $('.rental-items');     // In the rental-items table
                var rows = $table.find('li').get();            //get all of the tr elements

                rows.sort(function (a, b) {
                    var KeyA = $(a).attr('name');              //sort the tr elements based on the name attribute
                    var KeyB = $(b).attr('name');
                    if (KeyA > KeyB) return 1;
                    if (KeyA < KeyB) return -1;
                    return 0;
                });

                $.each(rows, function (index, row) {          //rewrite the table-items in the sorted order
                    $table.children('.tbody').append(row);
                });
            } else if ($('#DropDownList option:selected').val() == "Z-A") {
                //console.log("Z-A");
                var $table = $('.rental-items');
                var rows = $table.find('li').get();

                rows.sort(function (a, b) {
                    var KeyA = $(a).attr('name');                //sort the tr elements based on the name attribute
                    var KeyB = $(b).attr('name');
                    if (KeyA < KeyB) return 1;
                    if (KeyA > KeyB) return -1;
                    return 0;
                });

                $.each(rows, function (index, row) {
                    $table.children('.tbody').append(row);
                });
            } else if ($('#DropDownList option:selected').val() == "Damaged") {
                //console.log("Damaged");
                var $table = $('.rental-items');
                var rows = $table.find('li').get();

                rows.sort(function (a, b) {
                    var KeyA = $(a).attr('damaged');                //sort the tr elements based on the name attribute
                    var KeyB = $(b).attr('damaged');
                    if (KeyA < KeyB)
                    {
                        //console.log(KeyA + " is less then " + KeyB);
                        return 1;
                    }
                    if (KeyA > KeyB)
                    {
                        //console.log(KeyA + " is greater then " + KeyB);
                        return -1;
                    }
                    //console.log("Same");
                    return 0;
                });

                $.each(rows, function (index, row) {
                    $table.children('.tbody').append(row);
                });
            } else if ($('#DropDownList option:selected').val() == "Undamaged") {
                //console.log("Undamaged");
                var $table = $('.rental-items');
                var rows = $table.find('li').get();

                rows.sort(function (a, b) {
                    var KeyA = $(a).attr('damaged');                //sort the tr elements based on the name attribute
                    var KeyB = $(b).attr('damaged');
                    if (KeyA < KeyB) return -1;         //sort the tr elements based on the damaged attribute
                    if (KeyA < KeyB) return 1;
                    return 0;
                });

                $.each(rows, function (index, row) {
                    $table.children('.tbody').append(row);
                });
            } else {
                //console.log("First to Last");
                var $table = $('.rental-items');
                var rows = $table.find('li').get();

                rows.sort(function (a, b) {
                    var KeyA = $(a).attr('sortId');                  //sort the tr elements based on the sortId attribute
                    var KeyB = $(b).attr('sortId');
                    if (KeyA > KeyB) return 1;
                    if (KeyA < KeyB) return -1;
                    return 0;
                });

                $.each(rows, function (index, row) {
                    $table.children('.tbody').append(row);
                });
            }
            
        }
    );
});

//function for hover showing details

$('.rental-card').find('.rental-card-edit').hide();

$(document).ready(function () {
    $('.rental-card').hover(
        function () {
            $(this).find('.rental-card-edit').show();
            $(this).find('.card-img-top').animate({ 'opacity': '0.5' }, 200);
        },
        function () {
            $(this).find('.rental-card-edit').hide();
            $(this).find('.card-img-top').animate({ 'opacity': '1' }, 200);
        }
    );
});
