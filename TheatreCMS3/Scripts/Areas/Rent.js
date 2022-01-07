
$("#damaged").on("click",function () {

    if (damaged.checked) {
        ($("#trigger").text("Damages Incurred"));
    }
    else { $("#trigger").text("Notes");
    }

});

