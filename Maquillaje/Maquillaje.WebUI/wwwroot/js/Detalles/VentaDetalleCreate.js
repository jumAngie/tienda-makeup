$("#vde_VentaId").prop("hidden", true);

if ($("#vde_VentaId").val() > 0) {
    sessionStorage.setItem('id', $("#vde_VentaId").val());
}

$(document).ready(function () {
    $("#pro_PrecioUnitario").val("");
    $("#vde_Cantidad").val("");
})

$("#btnContinuar").click(function () {

    if (!($("#vde_Producto").val() > 0)) {
        $("#prod_IdValidation").prop("hidden", false);
    } else {
        $("#prod_IdValidation").prop("hidden", true);
    }

    if (!($("#vde_Cantidad").val() > 0)) {
        $("#factdeta_CantidadValidation").prop("hidden", false);
    } else {
        $("#factdeta_CantidadValidation").prop("hidden", true);
    }

    if ($("#vde_Producto").val() > 0 && $("#vde_Cantidad").val() > 0) {
        $("#vde_VentaId").val(sessionStorage.getItem('id'));

        $.getJSON('/Venta/RevisarStock', { id: $("#vde_Producto").val(), cantidad: $("#vde_Cantidad").val() })
            .done(function (stock) {
                if (stock == 0) {
                    MostrarMensajeWarning('Stock insuficiente');
                } else {
                    $("#formCreateDetalles").submit();
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
            });
    }
});

$("#cate").change(function () {
    var cate_Id = $("#cate").val();

    $.getJSON('/Venta/CargarProductos', { id: cate_Id })
        .done(function (productos) {
            var productosSelect = $('#vde_Producto');
            productosSelect.empty();
            productosSelect.append($('<option>', {
                value: '',
                text: '--Selecciona un producto--'
            }));
            $.each(productos, function (index, item) {
                productosSelect.append($('<option>', {
                    value: item.pro_Id,
                    text: item.pro_Nombre
                }));
            });
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
        });
})


$("#vde_Cantidad").on('input', function () {
    $.getJSON('/Venta/RevisarStock', { id: $("#vde_Producto").val(), cantidad: $("#vde_Cantidad").val() })
        .done(function (stock) {
            if (stock == 0) {
                console.log(stock);
                MostrarMensajeWarning('Stock insuficiente');
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
        });
})


$("#vde_Producto").change(function () {
    var prod_Id = $("#vde_Producto").val();

    $.getJSON('/Venta/PrecioProductos', { id: prod_Id })
        .done(function (productos) {
            $.each(productos, function (index, item) {
                $("#pro_PrecioUnitario").val(item.pro_PrecioUnitario);
                $("#pro_PrecioUnitarioShow").val(item.prod_PrecioUni);
            });
            console.log(productos);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
        });

})

$("#btnFinalizar").click(function () {

});