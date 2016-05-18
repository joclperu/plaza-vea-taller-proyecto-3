function fn_Validar() {

    
    var estadoOrden = $('#ctl00_ContentPlaceHolder1_hdEstadoOrden').val();
    if (estadoOrden.length > 0 && estadoOrden == '2') {
        alert('La Orden de compra está completada.');
        return false;
    }


    var nroGuia = $('#ctl00_ContentPlaceHolder1_txtNroGuiaRemis').val();
    var nroPlaca = $('#ctl00_ContentPlaceHolder1_txtNroPlaca').val();
    var transportista = $('#ctl00_ContentPlaceHolder1_txtTransportista').val();
    var observaciones = $('#ctl00_ContentPlaceHolder1_txtObservaciones').val();

    var grilla = $("#ctl00_ContentPlaceHolder1_gvProductos tr").length;

    if (nroGuia.length > 0) {
    } else {
        alert('Debe ingresar el N° Guía');
        $('#ctl00_ContentPlaceHolder1_txtNroGuiaRemis').focus();
        return false;
    }

    if (nroPlaca.length > 0) {
    } else {
        alert('Debe ingresar el N° Placa');
        $('#ctl00_ContentPlaceHolder1_txtNroPlaca').focus();
        return false;
    }

    if (transportista.length > 0) {
    } else {
        alert('Debe ingresar el Transportista');
        $('#ctl00_ContentPlaceHolder1_txtTransportista').focus();
        return false;
    }

    if (observaciones.length > 0) {
    } else {
        alert('Debe ingresar alguna observación');
        $('#ctl00_ContentPlaceHolder1_txtObservaciones').focus();
        return false;
    }

    if (grilla == 1) {
        alert('Debe agregar algún Producto');
        $('#ctl00_ContentPlaceHolder1_txtCantidad').focus();
        return false;
    }
    return true;

};

function fn_ValidarMonto() {

    var montoPermitido = $('#ctl00_ContentPlaceHolder1_hdMontoPermitido').val();
    if (montoPermitido != '-1') {
        if (montoPermitido > 0) {

            var cantidad = $('#ctl00_ContentPlaceHolder1_txtCantidad').val().length > 0 ? $('#ctl00_ContentPlaceHolder1_txtCantidad').val() : "0";
            if (cantidad > 0 && cantidad.length > 0) {
                if (parseInt(cantidad) <= parseInt(montoPermitido)) {
                    return true;
                } else {
                    alert('La cantidad máxima a ingresar es : ' + montoPermitido);
                    return false;
                }
            } else {
                alert('Cantidad inconsistente con la diferencia para completar la O.C.');
                return false;
            }
        } else {
            alert('Este producto está sin pendientes');
            return false;
        }

    } else {

        return false;
    }

};