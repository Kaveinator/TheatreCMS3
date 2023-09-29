function toggleContent(contentID) {
    //hide all availabe content sections
    var hideElems = document.getElementsByClassName("content")
    for (let x = 0; x < hideElems.length; x++) {
        hideElems[x].style.display = 'none';
    };
    //get passed content seaction id and set display to visible
    var elem = document.getElementById(contentID);
    elem.style.display = 'block';
    }
