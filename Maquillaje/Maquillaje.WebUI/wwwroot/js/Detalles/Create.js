$('#DdlProductos').change(function () {
    if (document.getElementById("DdlProductos").value != 0) {
        $.ajax({
            url: "/Venta/ObtenerPrecio/",
            method: "POST",
            data: { id: document.getElementById("DdlProductos").value },
            success: function (data) {
                if (data.success) {
                    $.each(data.producto, function (index, value) {
                        $('#txtPrecioVenta').val(value.pro_PrecioUnitario);
                    })
                }
            }
        })
    }
});

function GuardarDetalleVenta() {
    $('#divNuevaVenta').removeAttr("hidden");

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
                            mostrarWarningToast("La cantidad no puede ser mayor al stock disponible");
                        } else {
                            localStorage.setItem("IdCliente", document.getElementById("DdlClientes").value);

                            document.getElementsByTagName("form")[0].submit();

                            if ($("#divTable").hasAttribute("hidden")) {
                                $("#divTable").removeAttr("hidden");
                            }
                        }
                    })
                }
            }
        })
        /*
        $.ajax({
            url: "/Ventas/GuardarDetalle/",
            method: "POST",
            data: { Vent_Id: $('#txtIdVenta').val(), Prod_Id: document.getElementById("DdlProductos").value, Prod_PrecioVenta: $('#txtPrecioVenta').val(), Prod_Cantidad: $('#txtCantidad').val() },
            success: function (data) {
                if (data.success) {
                    $('#tbDetallesVenta > tbody').empty();
                    $.each(data.DetallesVentas, function (index, value) {
                        var btnEliminar = "<button class='btn btn-danger' onclick='preEliminar(" + value.DeVe_Id + ")'><div class='d-flex align-items-center'><span class='nav-link-icon'><span class='far fa-trash-alt'></span></span><span class='nav-link-text ps-1'>Eliminar</span></div></button>";
                        var btnEditar = "<button class='btn btn-warning' onclick='Editar(" + value.DeVe_Id + ")'><div class='d-flex align-items-center'><span class='nav-link-icon'><span class='fas fa-pencil-alt'></span></span><span class='nav-link-text ps-1'>Eliminar</span></div></button>";
                        $('#tbDetallesVenta > tbody').append("<tr><td>" + value.DeVe_Id + "</td><td>" + value.Vent_Id + "</td><td>" + value.Prod_CodigoProducto + "</td><td>" + value.Prod_Descripcion + "</td><td>" + value.DeVe_Cantidad + "</td><td>" + value.DeVe_PrecioVenta + "</td><td>" + value.DeVe_MontoTotal + "</td><td>" + btnEditar + "</td><td>" + btnEliminar + "</td></tr>")
                    })
                }
            }
        })
        */
    } else {
        $('#MensajeError').removeAttr("hidden");
    }
}

var subtotal = 0;

$('#tbDetallesVenta > tbody > tr').each(function (index, tr) {
    subtotal += parseFloat(tr.getElementsByTagName('td')[6].textContent);
});

$('#txtSubtotal').val(subtotal.toFixed(2));