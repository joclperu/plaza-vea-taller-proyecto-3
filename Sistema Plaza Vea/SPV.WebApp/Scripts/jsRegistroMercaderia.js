$(document).ready(function () {
    Shadowbox.init({ title: 'PLAZA VEA', modal: true, enableKeys: false, handleOversize: "drag" });
});

function fr_ClosePopup() {
    Shadowbox.close();
};

function fn_PopupEliminarNota() {

    if (confirm('¿Está seguro de anular la Nota de Ingreso?') == true) {
        return true;
    } else {
        return false;
    }

};

function fn_PopupNuevoIngreso() {

    var oc = $('#ctl00_ContentPlaceHolder1_txtCodOC').val();
    if (oc.length > 0) {
        var titulo = 'PLAZA VEA';
        var url = 'Popup/PopupNuevoIngreso.aspx?param=' + oc + '&Modo=N';
        Shadowbox.open({ player: "iframe", title: titulo, content: url, height: 670, width: 800 });
    }
    return false;


};

function fn_PopupConsultaIngreso(param) {

    var oc = $('#ctl00_ContentPlaceHolder1_txtCodOC').val();
    if (oc.length > 0) {
        var titulo = 'PLAZA VEA';
        var url = 'Popup/PopupNuevoIngreso.aspx?param=' + oc + '&Modo=C' + '&Nro_guia=' + param;
        Shadowbox.open({ player: "iframe", title: titulo, content: url, height: 670, width: 800 });
    }
    return false;
};


function fr_ReturnValuesIngreso(v) {
    try {
        var result = v;
        Shadowbox.close();
        if (result == 1) {
            $('#ctl00_ContentPlaceHolder1_btnConsultar').click();
        }

    } catch (Error) { }
};



/*********************************************
Valida los campos obligatorios
*********************************************/
function fn_ValidarOc() {
    var nroOc = $('#ctl00_ContentPlaceHolder1_txtOrdenCompra').val();

    if (nroOc.length > 0) {
    } else {
        alert('Ingrese el número de la orden compra');
        return false;
    }
    return true;
}


function fn_LanzarModal() {
    //$('#modalEdit').modal();
    return false;
}