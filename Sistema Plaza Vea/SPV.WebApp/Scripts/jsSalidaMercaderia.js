$(document).ready(function () {
    Shadowbox.init({ title: 'PLAZA VEA', modal: true, enableKeys: false, handleOversize: "drag" });
});

function fr_ClosePopup() {
    Shadowbox.close();
};


function fn_PopupNuevaSalida() {

    var od = $('#ctl00_ContentPlaceHolder1_txtOrdenDespacho').val();
    if (od.length > 0) {
        var titulo = 'PLAZA VEA';
        var url = 'Popup/PopupSalidaMercaderia.aspx?param=' + od + '&Modo=N';
        Shadowbox.open({ player: "iframe", title: titulo, content: url, height: 580, width: 770 });
    }
    return false;
};

function fnPopupConsulta(param1) {

    var od = $('#ctl00_ContentPlaceHolder1_txtOrdenDespacho').val();
    if (od.length > 0) {
        var titulo = 'PLAZA VEA';
        var url = 'Popup/PopupSalidaMercaderia.aspx?param=' + od + '&Modo=C' + '&doc=' + param1;
        Shadowbox.open({ player: "iframe", title: titulo, content: url, height: 520, width: 770 });
    }
    return false;
};


function fr_ReturnValues(v) {
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
function fn_ValidarOd() {
    var nroOc = $('#ctl00_ContentPlaceHolder1_txtOrdenDespacho').val();

    if (nroOc.length > 0) {
    } else {
        alert('Ingrese una orden despacho');
        return false;
    }
    return true;
}