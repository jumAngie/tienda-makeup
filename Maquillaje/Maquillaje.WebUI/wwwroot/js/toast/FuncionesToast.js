toastr.options = {
    progressBar: true
};


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

const mostrarSuccessToastEvent = new Event('mostrarSuccessToast');
const mostrarErrorToastEvent = new Event('mostrarErrorToast');
const mostrarWarningToastEvent = new Event('mostrarWarningToast');
const mostrarInfoToastEvent = new Event('mostrarInfoToast');

document.addEventListener('mostrarSuccessToast', function (event) {
    var mensaje = event.detail;
    mostrarSuccessToast(mensaje);
});

document.addEventListener('mostrarErrorToast', function (event) {
    var mensaje = event.detail;
    mostrarErrorToast(mensaje);
});

document.addEventListener('mostrarWarningToast', function (event) {
    var mensaje = event.detail;
    mostrarWarningToast(mensaje);
});

document.addEventListener('mostrarInfoToast', function (event) {
    var mensaje = event.detail;
    mostrarInfoToast(mensaje);
});



