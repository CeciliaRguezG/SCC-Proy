//Se declaran las variables de validación
//Esta validación sollo acepta letras
var expLetras = /^[a-zA-Z áéíóúÁÉÍÓÚñÑ\s]+$/;
//Esta validación sollo acepta letras y puntos
var expLetrasPuntos = /^[a-zA-Z áéíóúÁÉÍÓÚñÑ\s\.&\,]+$/;
//Acepta solo números
var expNumeros = /^[1-9]{1}[0-9]*$/;
//No acepta apostrofes
var expMotivo = /^[\']*$/;
//Acepta números y letras
var expNumerosLetras = /^[1-9]{1}[0-9]*^[a-bA-B]$/;

$(document).ready(function () {
    function verListado() {
        $.ajax({
            url: "ListaClientes.aspx/ConstruirListado", //este es le metodo que se invoca del cSS
            data: "{}",
            dataType: "json",
            type: "post",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                $("#lblListado").val(data.d);
                $("#ListadoCliente").dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers",
                    "iDisplayLength": 10,
                    "iDisplayStart": 0,
                    "bSort": true,
                    "bLengthChange": true,
                    "bSort": false, //true
                    "bPaginate": true,
                    "bAutoWidth": true,
                    "aLengthMenu": [[1, 10, 100, 1000, -1], [1, 10, 100, 1000, "Todos"]],
                    "bProcessing": false,
                    "bServerSide": false,
                    "sServerMethod": "POST"


                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Error al traer el historial")
            }
        });
    };

    $("#ListadoCliente").dataTable({
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "iDisplayLength": 10,
        "iDisplayStart": 0,
        "bSort": true,
        "bLengthChange": true,
        "bSort": false, //true
        "bPaginate": true,
        "bAutoWidth": true,
        "aLengthMenu": [[1, 10, 100, 1000, -1], [1, 10, 100, 1000, "Todos"]],
        "bProcessing": false,
        "bServerSide": false,
        "sServerMethod": "POST"


    });




/***************************************************************************************************/
    $("#MainContent$btn_Agregar").click(function () {
        //Se manda llamar la función validar campos
        val_cam();
    });

    //Verifica la validación donde solo introducira letras
    $("#txt_Nombre").keyup(function () {
        //Si el valor actual a buscar es diferente de vacío
        if ($(this).val() != "" && !expLetras.test($(this).val())) {
            //Manda un mensaje
            alert("Se busca por nombre");
        }

    });

    //Verifica la validación donde solo introducira letras 
    $("#txt_name").keyup(function () {
        //Si el valor actual del nombre es diferente de vacío
        if ($(this).val() != "" && !expLetras.test($(this).val())) {
            //Manda un mensaje
            alert("El nombre del cliente solo acepta letras");
        }
    });

    //Verifica la validación donde solo introducira letras
    $("#txt_app").keyup(function () {
        //Si el valor actual del apellido paterno es diferente de vacío
        if ($(this).val() != "" && !expLetras.test($(this).val())) {
            //Manda un mensaje
            alert("El apellido paterno del cliente solo acepta letras");
        }

    });

    //Verifica la validación donde solo introducira letras
    $("#txt_apm").keyup(function () {
        //Si el valor actual del apellido materno es diferente de vacío
        if ($(this).val() != "" && !expLetras.test($(this).val())) {
            //Manda un mensaje
            alert("El apellido materno del cliente solo acepta letras");
        }

    });

    //Verifica la validación donde solo introducira letras
    $("#txt_Dom").keyup(function () {
        //Si el valor actual del domicilio es diferente de vacío
        if ($(this).val() != "" && !expLetras.test($(this).val())) {
            //Manda un mensaje
            alert("El domicilio del cliente solo acepta letras");
        }

    });

    //Verifica la validación donde solo introducira números
    $("#txt_IFE").keyup(function () {
        //Si el valor actual de la IFE es diferente de vacío
        if ($(this).val() != "" && !expNumeros.test($(this).val())) {
            //Manda un mensaje
            alert("El valor de la IFE solo acepta números");
        }
    });

    //Verifica la validación donde solo introducira letras y números
    $("#txt_Num").keyup(function () {
        //Si el valor actual del numero de domicilio es diferente de vacío
        if ($(this).val() != "" && !expNumerosLetras.test($(this).val())) {
            //Manda un mensaje
            alert("El número de la casa solo acepta números y letras");
        }
    });

    //Verifica la validación donde solo introducira letras y números
    $("#txt_casa").keyup(function () {
        //Si el valor actual de las señas particulares del domicilio es diferente de vacío
        if ($(this).val() != "" && !expNumerosLetras.test($(this).val())) {
            //Manda un mensaje
            alert("Las señas particulares de la casa solo acepta números y letras");
        }
    });

    //Verifica la validación donde solo introducira números
    $("#txt_tel").keyup(function () {
        //Si el valor actual del número télefonico es diferente de vacío
        if ($(this).val() != "" && !expNumeros.test($(this).val())) {
            //Manda un mensaje
            alert("El valor del número teléfonico solo acepta números");
        }
    });

    //Verifica la validación donde solo introducira números
    $("#txt_tela").keyup(function () {
        //Si el valor actual del número télefonico alterno es diferente de vacío
        if ($(this).val() != "" && !expNumeros.test($(this).val())) {
            //Manda un mensaje
            alert("El valor del número télefonico alterno solo acepta números");
        }
    });
});

//Se crea la función de validar campos(val_cam)
function val_cam() {

    //Se declaran las variables de usuario y contrasenia recuperando los valores introducidos
    var nombreCliente = $("#txt_name").val();
    var apellidoPCliente = $("#txt_app").val();
    var apellidoMCliente = $("#txt_apm").val();
    var numIFE = $("#txt_IFE").val();
    var domicilio = $("#txt_Dom").val();
    var numDomicilio = $("#txt_Num").val();
    var seniasParticulares = $("#txt_casa").val();
    var telefono = $("#txt_tel").val();
    var telefonoAlterno = $("#txt_tela").val();

    var valNombreCliente = 0;
    var valApellidoPCliente = 0;
    var valApellidoMCliente = 0;
    var valNumIFE = 0;
    var valDomicilio = 0;
    var valNumDomicilio = 0;
    var valSeniasParticulares = 0;
    var valTelefono = 0;
    var valTelefonoAlterno = 0;

    //Verifica que el campo de nombre no este vacío
    if (nombreCliente != "") {
        //Si no esta vacío, mandará el borde color verde
        $("#txt_name").css({ "border": "solid 1px", "border-color": "green" });
        valNombreCliente = 0;
        }
        //Si no cumple
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_name").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errorcliente").text("El nombre del cliente solo acepta letras");
            $("#mensaje_errorcliente").show();
            valNombreCliente = 1;
        }

        //Verifica que el campo de apellido paterno no este vacío
        if (apellidoPCliente != "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_app").css({ "border": "solid 1px", "border-color": "green" });
            valApellidoPCliente = 0;
        }
        //Si no cumple
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_app").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errorcliente").text("El apellido paterno del cliente solo acepta letras");
            $("#mensaje_errorcliente").show();
            valApellidoPCliente = 1;
        }

        //Verifica que el campo de apellido materno no este vacío
        if (apellidoMCliente!= "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_apm").css({ "border": "solid 1px", "border-color": "green" });
            valApellidoMCliente = 0;
        }
        //Si no cumple
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_apm").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errorcliente").text("El apellido paterno del cliente solo acepta letras");
            $("#mensaje_errorcliente").show();
            valApellidoMCliente = 1;
        }

        //Si el numero de IFE es diferente de vacío
        if (numIFE != "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_IFE").css({ "border": "solid 1px", "border-color": "green" });
            valNumIFE = 0;
        }
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_IFE").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errorrazon").text("El valor de la IFE solo acepta números");
            $("#mensaje_errorrazon").show();
            valNumIFE = 1;
        }

        //Si el domicilio es diferente de vacío
        if (domicilio != "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_Dom").css({ "border": "solid 1px", "border-color": "green" });
            valDomicilio = 0;
        }
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_Dom").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errorsolicitante").text("El domicilio del cliente solo acepta letras");
            $("#mensaje_errorsolicitante").show();
            valDomicilio = 1;
        }

        //Si el número del domicilio es diferente de vacío
        if (numDomicilio != "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_Num").css({ "border": "solid 1px", "border-color": "green" });
            valNumDomicilio = 0;
        }
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_Num").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errorcantidad").text("El número de la casa solo acepta números y letras");
            $("#mensaje_errorcantidad").show();
            valNumDomicilio = 1;
        }

        //Si las señas particulares es diferente de vacío
        if (seniasParticulares != "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_casa").css({ "border": "solid 1px", "border-color": "green" });
            valSeniasParticulares = 0;
        }
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_casa").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errormotivo").text("Las señas particulares de la casa solo acepta números y letras");
            $("#mensaje_errormotivo").show();
            valSeniasParticulares = 1;
        }

        //Si el número teléfonico es diferente de vacío
        if (telefono != "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_tel").css({ "border": "solid 1px", "border-color": "green" });
            valTelefono = 0;
        }
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_tel").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errormotivo").text("El valor del número télefonico solo acepta números");
            $("#mensaje_errormotivo").show();
            valTelefono = 1;
        }

        //Si el número teléfonico alterno es diferente de vacío
        if (telefonoAlterno != "") {
            //Si no esta vacío, mandará el borde color verde
            $("#txt_tela").css({ "border": "solid 1px", "border-color": "green" });
            valTelefonoAlterno = 0;
        }
        else {
            //El borde de la caja de texto se pondrá de color rojo y mandara un mensaje de error
            $("#txt_tela").css({ "border": "solid 1px", "border-color": "red" });
            $("#mensaje_errormotivo").text("El valor del número télefonico solo acepta números");
            $("#mensaje_errormotivo").show();
            valTelefonoAlterno = 1;
        }

        //Se realiza una condición la cual te verifica que ningun campo este vacío 
        if (valNombreCliente == 0 && valApellidoPCliente == 0 && valApellidoMCliente == 0 && valNumIFE == 0 && valDomicilio == 0 && valNumDomicilio == 0 && valSeniasParticulares == 0 && valTelefono == 0 && valTelefonoAlterno == 0) {
            $("#pnlComGas").dialog('open');
            $("#lblNom").text(nombreCliente);
            $("#lblApp").text(apellidoPCliente);
            $("#lblApm").text(apellidoMCliente);
            $("#lblIFE").text(numIFE);
            $("#lblDom").text(domicilio);
            $("#lblNum").text(numDomicilio);
            $("#lblCasa").text(seniasParticulares);
            $("#lblTel").text(telefono);
            $("#lblTela").text(telefonoAlterno);
        }
        else
        {
            alert("Todos los campos son obligatorios").show();
        }
    }
