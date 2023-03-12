const tabs = document.querySelector(".BlogAuthor-Details--TabContainerWrapper");
const tabButton = document.querySelectorAll(".BlogAuthor-Details--TabButton");
const contents = document.querySelectorAll(".BlogAuthor-Details--content");

tabs.onclick = e => {
    const id = e.target.dataset.id;
    if (id) {
        tabButton.forEach(btn => {
            btn.classList.remove("active");
        });

        e.target.classList.add("active");

        contents.forEach(content => {
            content.classList.remove("active");
        });

        const element = document.getElementById(id);
        element.classList.add("active");
    }
}
