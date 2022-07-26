function openSuccessModal(message) {
    var myDiv = document.getElementById("MyModalSuccessAlertBody");
    myDiv.innerHTML = message;
    $("#myModalSuccess").modal("show");
}

$(document).ready(() => {
    var msg = "@TempData["SuccessMessage"]";
    if (msg)
        openSuccessModal(msg);
})