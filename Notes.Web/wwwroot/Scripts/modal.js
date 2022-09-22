export function openModal() {
    let modal = getModalInstance();
    modal.show();
}

export function closeModal() {
    let modal = getModalInstance();
    modal.hide();
}


function getModalInstance() {
    return bootstrap.Modal.getOrCreateInstance(document.getElementById('myModal'))
}

