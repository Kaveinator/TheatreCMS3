var indexNum = top.location.pathname.substring(top.location.pathname.lastIndexOf('/') + 1);
if (top.location.pathname === "/Prod/ProductionPhotoes/Create" || top.location.pathname === "/Prod/ProductionPhotoes/Edit/" + indexNum)
    {
    window.onload = function () {
        const windowWidth = $(window).width();
        if (windowWidth > 767) {
            $('#productionphoto-createedit--formSide').addClass('col-6');
        } else {
            $('#productionphoto-createedit--formSide').addClass('col-12');
        }
    }
}

$(window).on('resize', function () {
    if ($(window).width() > 767) {
        $('#productionphoto-createedit--formSide').addClass('col-6');
        $('#productionphoto-createedit--formSide').removeClass('col-12');
    } else {
        $('#productionphoto-createedit--formSide').addClass('col-12');
        $('#productionphoto-createedit--formSide').removeClass('col-6');
    }
})