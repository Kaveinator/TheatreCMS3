function toggleContent(contentID) {
    //hide all availabe content sections
    for (x in getElementsByClassName("content")) {
        x.style.display = 'none';
    };
    //get passed content seaction id and set display to visible
    var elem = document.getElementById(contentID);
        elem.style.display = 'block';
    }
