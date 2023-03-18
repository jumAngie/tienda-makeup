$(document).ready(function () {

    var emp_ID = $("#emp_ID").val();

    $.ajax({
        url: "/Empleado/CargarInfo/" + emp_ID,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            console.log(data);
            $.each(data, function (i, value) {
                $("#emp_Municipio").val(value.emp_Municipio)
                $("#depto").val(value.dep_ID);
            })

        }
    })

});


$("#depto").change(function () {

    var depto = $("#depto").val();


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