$("#vde_Producto").prop("disabled", true);
$("#vde_Cantidad").prop("disabled", true);
$("#precio_unitario").prop("disabled", true);
$("#cate").prop("disabled", true);
$("#btnContinuar").prop("disabled", true);
$("#btnFinalizar").prop("disabled", true);

$("#btnSiguiente").click(function () {

    if (!($("#ven_Cliente").val() > 0)) {
        $("#clie_IdValidation").prop("hidden", false);
        console.log($("#ven_Cliente").val());
    } else {
        $("#clie_IdValidation").prop("hidden", true);
    }

    if (!($("#ven_MetodoPago").val() > 0)) {
        $("#meto_IdValidation").prop("hidden", false);
        console.log("metodo");
    } else {
        $("#meto_IdValidation").prop("hidden", true);
    }

    if ($("#ven_MetodoPago").val() > 0 && $("#ven_Cliente").val() > 0) {

        sessionStorage.setItem("inserta", "jaja");
        sessionStorage.setItem("metodo", $("#ven_MetodoPago").val());
        sessionStorage.setItem("cliente", $("#ven_Cliente").val());

        $("#formCreate").submit();
    }
});

$(document).ready(function () {

    $('#menuMaquillaje').addClass('active');
    $('#facturasItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');

    console.log(sessionStorage.getItem("inserta"));

    if (sessionStorage.getItem("inserta") != null) {
        $("#ven_Cliente").prop("disabled", true);
        $("#ven_Cliente").val(sessionStorage.getItem("cliente"));
        $("#ven_MetodoPago").prop("disabled", true);
        $("#ven_MetodoPago").val(sessionStorage.getItem("metodo"));
        $("#ven_Empleado").prop("disabled", true);
        $("#btnSiguiente").prop("disabled", true);
        $("#vde_Producto").prop("disabled", false);

        $("#vde_Cantidad").prop("disabled", false);
        $("#cate").prop("disabled", false);
        $("#btnContinuar").prop("disabled", false);
        $("#btnFinalizar").prop("disabled", false);
    }

    $("#esEditar").val("no");
    $("#esEditar2").val("no");
})