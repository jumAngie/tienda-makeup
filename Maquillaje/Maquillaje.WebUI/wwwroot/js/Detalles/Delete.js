function preEliminar(id) {
    $("#lblIdDetalleVentaEliminar").text(id);
    showModalEliminar();
}

function Eliminar() {
    $.ajax({
        url: "/DetallesVentas/EliminarDetalle/",
        method: "POST",
        data: { DeVe_Id: $("#lblIdDetalleVentaEliminar").text(), Vent_Id: $('#txtIdVenta').val() },
        success: function (data) {

        }
    })
    closeModalEliminar();
    window.location.reload();
}

function showModalEliminar() {
    $('#myModalEliminar').modal('show');
};

function closeModalEliminar() {
    $('#myModalEliminar').modal('hide');
};