$("#depto").change(function () {

    var depto = $("#depto").val();
    alert(depto)

    $.ajax({
        url: "/Empleado/CargarMunicipios/" + depto,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            console.log(data);
            $("#emp_Municipio").empty();
            $("#emp_Municipio").append("<option value= '0' >Seleccione un Municipio</option>");

            $.each(data, function (i, value) {
                $("#emp_Municipio").append("<option value='" + value.mun_ID + "'>" + value.mun_Descripcion + "</option>");
            })
        }
    })
});