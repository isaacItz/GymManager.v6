var submitButton = document.getElementById("submit");
var inputBox = document.getElementById("gym-user");

function addModal(evt) {
    let modal = document.getElementById("text-message");
    let modalTitle = document.getElementById("mySmallModalLabel");
    let button = evt.currentTarget;
    let mensaje = "Member: ";
    modalTitle.innerHTML = button.getAttribute("name") + " registered";
    mensaje += inputBox.value;
    mensaje += " at: " + moment().format('MMMM Do YYYY, h:mm:ss a');
    modal.innerHTML = mensaje;

    $('#mensaje').modal("show");
    setTimeout(() => $("#mensaje").modal('hide'), 3000);
}

submitButton.addEventListener("click", addModal);
inputBox.addEventListener("submit", addModal);