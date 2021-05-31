// Blog Author Section Start

function btnAuthorDetails() {
    var details = document.getElementById("ContentAuthorDetails");
    var post = document.getElementById("ContentAuthorPost");
    if (details.style.display === "none") {
        details.style.display = "block";
        document.getElementById('BtnAuthorDetails').style.backgroundColor = 'green';

        post.style.display = "none";
        document.getElementById('BtnAuthorPost').style.backgroundColor = '#4a4a4a';
    }
}

function btnAuthorPost() {
    var details = document.getElementById("ContentAuthorDetails");
    var post = document.getElementById("ContentAuthorPost");
    if (post.style.display === "none") {
        post.style.display = "block";
        document.getElementById('BtnAuthorPost').style.backgroundColor = 'green';

        details.style.display = "none";
        document.getElementById('BtnAuthorDetails').style.backgroundColor = '#4a4a4a';
    }
}