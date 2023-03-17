$(document).ready(function () {

    var cli_ID = $("#cli_ID").val();

    $.ajax({
        url: "/Cliente/CargarInfo/" + cli_ID,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            console.log(data);
            $.each(data, function (i, value) {
                $("#cli_Municipio").val(value.cli_Municipio)
                $("#depto").val(value.dep_ID);
            })

        }
    })

});


$("#depto").change(function () {

    var depto = $("#depto").val();


    $.ajax({
        url: "/Cliente/CargarMunicipios/" + depto,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            console.log(data);
            $("#cli_Municipio").empty();
            $("#cli_Municipio").append("<option value= '0' >Seleccione un Municipio</option>");

            $.each(data, function (i, value) {
                $("#cli_Municipio").append("<option value='" + value.mun_ID + "'>" + value.mun_Descripcion + "</option>");
            })
        }
    })
});

