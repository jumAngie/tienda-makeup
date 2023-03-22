


function Editar(sucu_ID) {
    $("#editar-modal").modal('show');
    alert(sucu_ID);
    var sucu_ID = sucu_ID

    $.ajax({
        url: "/Sucursal/CargarInfo/" + sucu_ID,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            console.log(data);
            $.each(data, function (i, value) {
                $("#ddlMuni2").val(value.suc_Municipio)
                $("#ddlDepto2").val(value.dep_ID);
                $("#txtSucursal2").val(value.suc_Descripcion);
            })

        }
    })
}


$("#ddlDepto2").change(function () {

    var depto = $("#ddlDepto2").val();


    $.ajax({
        url: "/Sucursal/CargarMunicipios/" + depto,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            console.log(data);
            $("#ddlMuni2").empty();
            $("#ddlMuni2").append("<option value= '0' >Seleccione un Municipio</option>");

            $.each(data, function (i, value) {
                $("#ddlMuni2").append("<option value='" + value.mun_ID + "'>" + value.mun_Descripcion + "</option>");
            })
        }
    })
});