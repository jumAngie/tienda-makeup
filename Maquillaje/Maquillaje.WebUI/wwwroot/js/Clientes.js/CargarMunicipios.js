$("#depto").change(function () {

    var depto = $("#depto").val();
    alert(depto);

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