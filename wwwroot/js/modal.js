function openModal() {
    var myDiv = document.getElementById("ModalBody");
    const announcementTitle = $("#Title").val();
    const announcementContent = $("#Content").val();
    if (announcementTitle != "" && announcementContent != "") {
        myDiv.innerHTML = `Are You sure you want to add announcement with title: ${announcementTitle}`;
        $("#Modal").modal("show");
        let closeButtons = document.querySelectorAll('[data-dismiss]');
        closeButtons[0].addEventListener('click', closeModal);
        closeButtons[1].addEventListener('click', closeModal);
    }
}

function closeModal() {
    $("#Modal").modal("hide");
}

document.querySelector("#AddAnnouncement").addEventListener("click", openModal);