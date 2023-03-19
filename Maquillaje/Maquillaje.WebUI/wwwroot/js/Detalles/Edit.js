function Editar(id) {
    $.ajax({
        url: "/Venta/preEditarDetalle/",
        method: "POST",
        data: { DeVe_Id: id },
        success: function (data) {
            if (data.success) {

                $('#btnGuardarEdicion').removeAttr("hidden");
                $('#btnGuardarDetalle').attr("hidden", "");

                $.each(data.DetalleVenta, function (index, value) {
                    $('#txtIdDetalleVenta').val(value.vde_Id);
                    $('#txtIdVenta').val(value.vde_VentaId);
                    document.getElementById("DdlProductos").value = value.vde_Producto;
                    $('#txtPrecioVenta').val(value.pro_PrecioUnitario);
                    $('#txtCantidad').val(value.vde_Cantidad);
                })
            }
        }
    })
}

function GuardarEdicion() {
    var productoValido = false, precioVentaValido = false, cantidadValida = false

    if (document.getElementById("DdlProductos").value == '0') {
        $('#MensajeError').removeAttr("hidden");
        $('#lblProductoError').removeAttr("hidden");
    } else if (document.getElementById("DdlProductos").value != '0') {
        $('#MensajeError').attr("hidden", "");
        $('#lblProductoError').attr("hidden", "");
        productoValido = true;
    }

    if ($('#txtPrecioVenta').val() == "") {
        $('#MensajeError').removeAttr("hidden");
        $('#lblPrecioVentaError').removeAttr("hidden");
    } else if ($('#txtPrecioVenta').val() != "") {
        if (!/(^[0-9]{1,9}$)|(^[0-9]{1,9}\.[0-9]{1,2}$)/.test($('#txtPrecioVenta').val())) {
            $('#lblPrecioVentaError').removeAttr("hidden");
            $('#lblPrecioVentaError').text("posee un formato no válido");
        } else {
            $('#MensajeError').attr("hidden", "");
            $('#lblPrecioVentaError').text("*");
            $('#lblPrecioVentaError').attr("hidden", "");
            precioVentaValido = true;
        }
        $('#MensajeError').attr("hidden", "");
    }

    if ($('#txtCantidad').val() == "") {
        $('#MensajeError').removeAttr("hidden");
        $('#lblCantidadError').removeAttr("hidden");
    } else if ($('#txtCantidad').val() != "") {
        if (!/(^[0-9]{1,9}$)/.test($('#txtCantidad').val())) {
            $('#lblCantidadError').removeAttr("hidden");
            $('#lblCantidadError').text("posee un formato no válido");
        } else {
            $('#MensajeError').attr("hidden", "");
            $('#lblCantidadError').text("*");
            $('#lblCantidadError').attr("hidden", "");
            cantidadValida = true;
        }
        $('#MensajeError').attr("hidden", "");
    }

    if (productoValido && precioVentaValido && cantidadValida) {

        $.ajax({
            url: "/Venta/CargarStock/",
            method: "POST",
            data: { id: document.getElementById("DdlProductos").value },
            success: function (data) {
                if (data.success) {
                    $.each(data.stock, function (index, value) {
                        if (value < $('#txtCantidad').val()) {
                            MostrarMensajeWarning("La cantidad no puede ser mayor al stock disponible");
                        } else {
                            $.ajax({
                                url: "/DetallesVentas/GuardarEdicionDetalle/",
                                method: "POST",
                                data: { DeVe_Id: $('#txtIdDetalleVenta').val(), Vent_Id: $('#txtIdVenta').val(), Prod_Id: document.getElementById("DdlProductos").value, Prod_PrecioVenta: $('#txtPrecioVenta').val(), Prod_Cantidad: $('#txtCantidad').val() },
                                success: function (data) {

                                }
                            })
                            window.location.reload();
                        }
                    })
                }
            }
        })
    } else {
        $('#MensajeError').removeAttr("hidden");
    }
}