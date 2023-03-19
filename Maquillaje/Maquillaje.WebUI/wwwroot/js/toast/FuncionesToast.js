
function mostrarSuccessToast(mensaje) {
    toastr.success(mensaje, 'Exitoso')
}

function mostrarErrorToast(mensaje) {
    toastr.error(mensaje, 'Error')
}

function mostrarWarningToast(mensaje) {
    toastr.warning(mensaje, 'Advertencia')
}

function mostrarInfoToast(mensaje) {
    toastr.info(mensaje, 'Información')
}

function MostrarMensajeSuccess(bodymessage) {
    toastr.success(bodymessage, 'Exitoso')
}

function MostrarMensajeWarning(bodymessage) {
    toastr.warning(bodymessage, 'Advertencia')
}

function MostrarMensajeDanger(bodymessage) {
    toastr.error(bodymessage, 'Error')
}

function MostrarMensajeInfo(bodymessage) {
    toastr.info(bodymessage, 'Info')
}

toastr.options = {
    closeButton: true,
    progressBar: true
};

function CerrarSesion() {
    localStorage.removeItem("Session");
}

if (!localStorage.getItem("Session")) {
    setTimeout(function () {
        window.location.reload();
    }, 20)
}



