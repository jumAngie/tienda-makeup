$(document).ready(function () {
    $.ajax({
        url: "/Venta/CargarDdl/",
        method: "POST",
        data: { cargar: 'Yes' },
        success: function (data) {
            console.log(data);
            $('#DdlClientes').empty();
            $('#DdlClientes').append("<option value='0' hidden selected>---Seleccione un cliente---</option>");
            $.each(data.DdlClientes, function (index, value) {
                $('#DdlClientes').append("<option value='" + value.Clie_Id + "'>" + value.Clie_Nombre + "</option>")
            })

            $.each(data.Ddlproductos, function (index, value) {
                $('#DdlProductos').append("<option value='" + value.pro_Id + "'>" + value.pro_Nombre + "</option>")
            })
        }
    })
});

setTimeout(function () {
    if (localStorage.getItem("IdCliente")) {
        let select = document.getElementById("DdlClientes");
        select.value = localStorage.getItem("IdCliente");

        $('#DdlClientes').attr("disabled", "");
        $('#btnGuardarVenta').attr("hidden", "");

        $('#divNuevoDetalleVenta').removeAttr("hidden");

        $('#txtIdVenta').val(localStorage.getItem("IdVenta"));
        $('#divTable').removeAttr("hidden");

        if ($('#tbDetallesVenta > tbody > tr').find('td').length > 1) {
            $("#btnPagarAhora").removeAttr("disabled");
        } else {
            $("#btnPagarAhora").attr("disabled", "");
        }

    } else {
        $('#btnGuardarVenta').removeAttr("hidden");
        $('#divNuevoDetalleVenta').attr("hidden", "");
        $('#DdlClientes').removeAttr("disabled");
        $('#divTable').attr("hidden");
    }
}, 800);

function NuevaVenta() {
    localStorage.removeItem("IdCliente");
    localStorage.removeItem("IdVenta");
    window.location.reload();
}

function GuardarVenta() {
    if (document.getElementById("DdlClientes").value == '0') {
        mostrarWarningToast("Debe seleccionar un cliente para crear una venta");
    } else {
        $.ajax({
            url: "/Venta/Guardar/",
            method: "POST",
            data: { clie_Id: document.getElementById("DdlClientes").value },
            success: function (data) {
                if (data.success) {
                    $('#btnGuardarVenta').attr("hidden", "");
                    $('#divNuevoDetalleVenta').removeAttr("hidden", "");
                    $('#DdlClientes').attr("disabled", "");

                    $('#txtIdVenta').val(data.IdUltimaVentaReciente);
                    localStorage.setItem("IdVenta", data.IdUltimaVentaReciente);

                    $('#DdlProductos').empty();
                    $.each(data.Ddlproductos, function (index, value) {
                        $('#DdlProductos').append("<option value='" + value.pro_Id + "'>" + value.pro_Nombre + "</option>")
                    })
                } else {
                    $('#btnGuardarVenta').removeAttr("hidden");
                    $('#divNuevoDetalleVenta').attr("hidden", "");
                    $('#DdlClientes').removeAttr("disabled");
                }
            }
        })
    }
}

function PagarAhora() {
    if ($("#txtDescuento").val() == "") {
        MostrarMensajeWarning("Por favor ingrese el descuento");
        $("#txtDescuento").focus();
    } else {
        if (/(^[0-9]{1,9}$)|(^[0-9]{1,9}\.[0-9]{1,2}$)/.test($('#txtDescuento').val())) {
            if (parseFloat($("#txtDescuento").val()) > parseFloat($("#txtSubtotal").val())) {
                mostrarWarningToast("El descuento no puede ser mayor al subtotal")
            } else {
                var subtotal = parseFloat($("#txtSubtotal").val()), isv = 0, total = 0, descuento = parseFloat($("#txtDescuento").val());

                isv = subtotal * 0.15;
                total = (subtotal + isv) - descuento;

                $('#txtIsv').val(isv.toFixed(2));
                $('#txtTotal').val(total.toFixed(2));

                $("#txtDescuentoInfo").val(descuento.toFixed(2));
                $("#txtDescuento").attr("readonly", "");
                $('#formDetalleVenta').attr("hidden", "");

                localStorage.removeItem("IdCliente");
                localStorage.removeItem("IdVenta");

                $('#btnPagarAhora').attr("disabled", "");
                $('.btnEditar').attr("disabled", "");
                $('.btnEliminar').attr("disabled", "");

                //$.ajax({
                //    url: "/Ventas/GuardarMontoFinal/",
                //    method: "POST",
                //    data: { Vent_Id: $('#txtIdVenta').val(), Vent_Descuento: descuento, Vent_MontoFinal: total },
                //    success: function (data) {

                //    }
                //})
            }
        } else {
            mostrarWarningToast("El descuento no es válido.\nDescuento solo acepta números positivos, con dos decimales opcionales.");
            $("#txtDescuento").focus();
        }
    }
}
