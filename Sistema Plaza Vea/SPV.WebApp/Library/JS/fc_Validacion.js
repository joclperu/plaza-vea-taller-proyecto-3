//EXPRESIONES REGULARES
var RE_ALAFANUMERICO = /^[\w\d áéíóúAÉÍÓÚÑñüÜ_.,/ \\ \-]+$/i;
var RE_ALAFANUMERICONOESP = /^[\w\dáéíóúAÉÍÓÚÑñ]+$/i;
var RE_SOLONRO = /^\d+$/i;
var RE_EMAIL = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/i;
var RE_WEB = /\w+([-+.']\w+)*\w+([-.]\w+)*\.\w+([-.]\w+)*/i;
var RE_COLORWEB = /^#?([a-f]|[A-F]|[0-9]){3}(([a-f]|[A-F]|[0-9]){3})?$/i;
var RE_PATH = /([A-Z]:\\[^/:\*\?<>\|]+\.\w{2,6})|(\\{2}[^/:\*\?<>\|]+\.\w{2,6})/i;
var RE_IP = /^(?:25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)(?:[.](?:25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)){3}$/i;
var RE_PRECIO = /^(-)?\d+(\.\d?\d?)?$/i;
var RE_NRO_DECIMAL = /^[\ \d ,.]+$/i;///^[\- \d ,.]+$/i;
var MASCARA_FECHA = '__/__/____';
var RE_CUENTA_CORRIENTE = /^[\d \- /]*$/i;
var RE_NUMERO_TELEFONO = /^[\d () \- /]*$/i;
var RE_PLACA = /^[\w\d\ñÑ\-]*$/i;
var RE_CODIGO = /^[\w\d\-_.]*$/i;
var RE_NRO_VERSION = /^[\d.]+$/i;

/******************************************************
Descripción :    Permite validar numero decimales con un PUNTO(decimal) y enteros y 3 decimales, tbn acepta solo enteros (positivos) - RE_NRO_DECIMALM
Autor 		:    Remy Yactayo Hinostroza
Fecha/hora	:    20/04/2010
******************************************************/

/******************************************************
Descripción :    Permite Redondear un numero con el numero de decimales q se desee
Autor 		:    Remy Yactayo Hinostroza
Fecha/hora	:    21/04/2010
******************************************************/
function fc_round(numero,nrodecimales){
    var div1='1'; //para poner antes de los ceros
    var div2=0; // resultado conlos ceros
    var ceros=''; // cantidad de ceros a agregar
    var ready=0; // listo para dividir y redondear
    var ndec=parseInt(nrodecimales);
    for(var i=0;i<ndec;i++)
    {
        ceros+='0';
    }
    div2 =div1+ceros;
    ready=parseInt(div2);
    var original=parseFloat(numero);
    var resultado=Math.round(original*ready)/ready;
return resultado;
}

function fc_ValidaUpload(clientIdEfectoLetra, region)
{
        var msjError = "";
        if(document.getElementById(clientIdEfectoLetra + "_lblArchivo")!= null)
        {
            if ( document.getElementById(clientIdEfectoLetra + "_fuArchivo").value == "" && document.getElementById(clientIdEfectoLetra + "_lblArchivo").innerHTML == "" )
                msjError = msjError + "- Debe ingresar el archivo de " + region + ".\n";
            else if (navigator.appName !="Netscape" && !document.getElementById(clientIdEfectoLetra + "_fuArchivo").value.match(RE_PATH) && document.getElementById(clientIdEfectoLetra + "_fuArchivo").value != "")
                msjError = msjError + "- La ruta del archivo de " + region + " contiene caracteres no válidos.\n";
        }
        else
        {
            if ( document.getElementById(clientIdEfectoLetra + "_fuArchivo").value == "")
                msjError = msjError + "- Debe ingresar el archivo de " + region + ".\n";
            else if (navigator.appName !="Netscape" && !document.getElementById(clientIdEfectoLetra + "_fuArchivo").value.match(RE_PATH) )
                msjError = msjError + "- La ruta del archivo de " + region + " contiene caracteres no válidos.\n";                
        }
        
        return msjError;
}

/*************************************************************************************
Descripción :    Permite compara dos fechas, en caso una este vacia no la cuenta
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
	  function fc_Compara_Fechas(pFecIni,pFecFin)
       {	
		if (pFecIni != "" && pFecFin != "" && pFecIni.length==10 && pFecFin.length==10)
			{	
				/*                        mm/dd/aaaa                                              */
				var ArrFechaIni = new Array();
				var ArrFechaFin = new Array();
				ArrFechaIni = pFecIni.split("/"); 
				ArrFechaFin = pFecFin.split("/"); 
				if(ArrFechaIni<3) return false;
				if(ArrFechaFin<3) return false;
				
				//agregar un cero a los dias o meses menores a 10
				if(ArrFechaIni[1].length==1)
				ArrFechaIni[1]="0"+ArrFechaIni[1];
				if(ArrFechaIni[2].length==1)
				ArrFechaIni[2]="0"+ArrFechaIni[2]; 
				if(ArrFechaFin[1].length==1)
				ArrFechaFin[1]="0"+ArrFechaFin[1];
				if(ArrFechaFin[2].length==1)
				ArrFechaFin[2]="0"+ArrFechaFin[2]; 

				
				 var mon1  = parseInt(ArrFechaIni[1],10);
				 var yr1   = parseInt(ArrFechaIni[2],10); 
				 var dt1   = parseInt(ArrFechaIni[0],10); 
                 var mon2  = parseInt(ArrFechaFin[1],10); 
                 var yr2   = parseInt(ArrFechaFin[2],10); 
                 var dt2   = parseInt(ArrFechaFin[0],10); 
                 
                 if(Number(yr2) > Number(yr1)) return false;
                 else if(Number(yr2) < Number(yr1)) return true;
                 else if((Number(yr2) == Number(yr1))&&(Number(mon2) > Number(mon1))) return false;
                 else if((Number(yr2) == Number(yr1))&&(Number(mon2) < Number(mon1))) return true;
                 else if((Number(yr2) == Number(yr1))&&(Number(mon2) == Number(mon1))&&(Number(dt2) > Number(dt1))) return false;
                 else if((Number(yr2) == Number(yr1))&&(Number(mon2) == Number(mon1))&&(Number(dt2) < Number(dt1))) return true;
                 else if((Number(yr2) == Number(yr1))&&(Number(mon2) == Number(mon1))&&(Number(dt2) == Number(dt1))) return true;
			}
			return false;			
   }  

/*************************************************************************************
Descripción :    Permite validar el "maxlength" de un textarea
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaTextArea(strNameObj, lenMax) 
{              
	//strNameObj : Nombre de la caja de texto a validar.

	fc_ValidaTextoNumerico(strNameObj)

	if (strNameObj.value.length == lenMax) {
		window.event.keyCode = 0;
	}                          
}
/*************************************************************************************
Descripción :    Permite validar si la ruta del archivo ingresado es válida.
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_Validar_RutaArchivo(pstrNomControl)
{
     var lObjControl = document.getElementById(pstrNomControl);
     var lstrRuta = lObjControl.value;
	 var lstrPatron = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w ]*.*))+\.(\w+)$/;
	 
	 if(lstrPatron.test(lstrRuta))
		return true;
	 else
	 {
		alert("Debe ingresar una ruta de archivo valida");
		lObjControl.focus();
		return false;
	 }
}

/*************************************************************************************
Descripción :    Permite validar si el RUC es válido retornando true or false de acuerdo
				 al caso.
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/

		function ValidarRuc_Retorno(strNomRuc)
        {			
            var suma = 0;
            var Ruc = new String(document.all[strNomRuc].value);			
            var result = false;
            if (Ruc!='99999999999')
            {
				if (Ruc.length == 11)
				{
					Ruc = Ruc.split("");
					var strPar = new String("5,4,3,2,7,6,5,4,3,2,");
					var arrPar = new Array(10);
					arrPar = strPar.split(",");

					var caracter = parseFloat(Ruc[10]);
					for(var i=0; i<10; i++)
					{
						suma = parseFloat(suma) + parseFloat(arrPar[i]) * parseFloat(Ruc[i]);
					}
							
					var resto = suma % 11;
					var verificador = 11 - resto;
					if (verificador==11){
							verificador = 1;
					}
					else if (verificador==10){
							verificador = 0;
					}
					if (verificador!=caracter){
						alert("R.U.C. no valido.");
						document.all[strNomRuc].focus();
						result = false;
					}
					else {result = true;}
				}
				else
				{
					result = false;
					alert("Longitud de R.U.C. erronea.");
					document.all[strNomRuc].focus();
				}
            }
            else
            {result = true;}            
            
            return result;
		}
		
/*************************************************************************************
Descripción :    Permite poner 2 puntos a la hora ingresada en casos sus fechas 
				 hayan sigo ingresadas
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_DosPuntos(form,fec1,fec2,objeto,separador)
{		
	var obj,objfec1,objfec2;		
	objfec1= document.getElementById(fec1);
	objfec2= document.getElementById(fec2);	
	if (objfec1.value== "" || objfec2.value== "")
	{
		window.event.returnValue=0;
		alert("Antes de ingresar las horas, debe ingresar las fechas");		
		if (objfec1.value== "") objfec1.focus();
		else objfec2.focus();		
	} 
	else 
	{
		fc_PermiteNumeros();	
		obj= document.getElementById(objeto);
		if (obj.value.length == 2){obj.value = obj.value + separador;}
		if (obj.value.length = obj.maxlength-1){return;}	
	}	
}

/*************************************************************************************
Descripción :    Permite compara dos fechas, en caso una este vacia no la cuenta
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaFechaIniFechaFin(pFecIni,pFecFin)
   {	if (pFecIni != "" && pFecFin != "" && pFecIni.length==10 && pFecFin.length==10)
			{	
				var dFecIni = pFecIni.substr(6,4) + "/" + pFecIni.substr(3,2) + "/" + pFecIni.substr(0,2);  
				var dFecFin = pFecFin.substr(6,4) + "/" + pFecFin.substr(3,2) + "/" + pFecFin.substr(0,2); 
				if (dFecIni > dFecFin)
					return 1;
				else
					return 0;
			}
			else
				return 2;			
   }   
   /*************************************************************************************
Descripción :    Borra que la fecha de inicio sea menor a la de fin
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
 function fc_ValidaRangoFechas(strObj1,strObj2,mensaje1, mensaje2,num)
 {
   	var Obj1 = document.all[strObj1];
   	var Obj2 = document.all[strObj2];
   	var fec1 = Obj1.value;
   	var fec2 = Obj2.value;
   	
   	if (fc_ValidaFechaIniFechaFin(fec1,fec2)==1){
   		alert("La fecha de "+mensaje1+" es mayor que la fecha de "+mensaje2);
   		if (parseInt(num)==1){
   			Obj1.value="";
   			Obj1.focus();   			
   		}
   		else{
   			Obj2.value="";
   			Obj2.focus();   			
   		}
   		return false;
   	}
  	return true;   	
 }

 function fc_ValidaRangoFechasRev(strObj1,strObj2,mensaje1, mensaje2,num)
 {
   	var Obj1 = document.all[strObj1];
   	var Obj2 = document.all[strObj2];
   	var fec1 = Obj1.value;
   	var fec2 = Obj2.value;
   	
   	if (fc_ValidaFechaIniFechaFin(fec1,fec2)==1){
   		alert("La fecha de "+mensaje2+" debe ser mayor o igual que la fecha de "+mensaje1);
   		if (parseInt(num)==1){
   			Obj1.value="";
   			Obj1.focus();   				
   		}
   		else{
   			Obj2.value="";
   			Obj2.focus();   			
   		}
   		return false;
   	}
  	return true;   	
 }

/*************************************************************************************
Descripción :    Valida que la fecha final no sea menor o igual a la fecha de inicio
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaFechaIniFechaFin1(pFecIni,pFecFin)
   {	if (pFecIni != "" && pFecFin != "" && pFecIni.length==10 && pFecFin.length==10)
			{	
				var dFecIni = pFecIni.substr(6,4) + "/" + pFecIni.substr(3,2) + "/" + pFecIni.substr(0,2);  
				var dFecFin = pFecFin.substr(6,4) + "/" + pFecFin.substr(3,2) + "/" + pFecFin.substr(0,2); 
				if (dFecIni >= dFecFin)
					return 1;
				else
						return 0;
			}
			else
				return 2;			
   }   
/*************************************************************************************
Descripción :    Borra que la fecha de inicio sea menor o igual a la de fin
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
 function fc_ValidaRangoFechas1(strObj1,strObj2,mensaje1, mensaje2,num)
 {
   	var Obj1 = document.all[strObj1];
   	var Obj2 = document.all[strObj2];
   	var fec1 = Obj1.value;
   	var fec2 = Obj2.value;
   	
   	if (fc_ValidaFechaIniFechaFin1(fec1,fec2)==1){
   		alert("La fecha de " + mensaje2 + " debe de ser mayor a la fecha de " + mensaje1 +".");
   		if (parseInt(num)==1){
   			Obj1.value="";
   			Obj1.focus();   			
   		}
   		else{
   			Obj2.value="";
   			Obj2.focus();   			
   		}
   		return false;
   	}
  	return true;   	
 }


/*************************************************************************************
Descripción :    Permit verificar si es un numero decimal, y mandar un mensaje de error
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaDecimalOnBlur(strNameObj, NumEntero, NumDecimal)
{
	var Obj = document.all[strNameObj];
	if (Obj.value !="")
	{
		if (!fc_ValidaDecimal(Obj.value, NumEntero, NumDecimal)) {
			Obj.value="";
			alert('Debe ingresar un valor correcto.');
			Obj.focus();				
		}
		//le da formato al nro
		var num= Number(Obj.value)
		Obj.value = num.toFixed(NumDecimal)
	}
}
/*************************************************************************************
Descripción :    Permite verificar si es un numero entero
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumeroOnBlur(strNameObj)
{
	var Obj = document.all[strNameObj];
	if(!Obj.value.toString().match(/^\d+$/g) && Obj.value !=''){

		Obj.value="";
		alert('Debe ingresar un número correcto.');
		Obj.focus();
	}
}


function fc_ValidaNumerico1(strNameObj) {
/*************************************************************************************
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
	//strNameObj : Nombre de la caja de texto a validar.	
	var Obj = document.all[strNameObj];
	var ch_Caracter = String.fromCharCode(window.event.keyCode);
	var intEncontrado = "0123456789.".indexOf(ch_Caracter);
	if (intEncontrado == -1) {	
		window.event.keyCode = 0;		
	}
	else {
		window.event.keyCode = ch_Caracter.charCodeAt();
	}	
}
function fc_ValidaDecimal(fieldValue, NumEntero, NumDecimal) 
{
	decallowed = NumDecimal;  // Numero de Decimales
	intallowed = NumEntero;  // Numero de Enteros

	if (isNaN(fieldValue) || fieldValue == "") 
	{
		return false;
	}
	else 
	{
		if (fc_ValidaDecimalFinal(fieldValue)==false) {return false;}
		
		if (fieldValue.indexOf('.') == -1) fieldValue += ".";
		dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);
		inttext = fieldValue.substring(0,fieldValue.indexOf('.'));

		if (dectext.length > decallowed || inttext.length > intallowed)
		{
			return false;
		}
	}
	return true;
}

/*************************************************************************************
Descripción :    Permite Ingresar solo numeros
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumero(){	
	//strNameObj : Nombre de la caja de texto a validar.	
	var intEncontrado = "1234567890".indexOf(String.fromCharCode(window.event.keyCode));		
	//alert(intEncontrado)
	if (intEncontrado == -1) {
		window.event.keyCode = 0;		
	}		
}
/*************************************************************************************
Descripción :    Permite Ingresar solo numeros
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumeroGUION(){	
	//strNameObj : Nombre de la caja de texto a validar.	
	var intEncontrado = "1234567890-".indexOf(String.fromCharCode(window.event.keyCode));		
	//alert(intEncontrado)
	if (intEncontrado == -1) {
		window.event.keyCode = 0;		
	}		
}

function fc_ValidaNumeroGuion(){	
	//strNameObj : Nombre de la caja de texto a validar.
	
	var intEncontrado = "1234567890-".indexOf(String.fromCharCode(window.event.keyCode));		
	//alert(intEncontrado)
	if (intEncontrado == -1) {
		window.event.keyCode = 0;		
	}		
}

/*************************************************************************************
Descripción :    Permite Ingresar solo numeros
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumeroDecimal(){	
	//strNameObj : Nombre de la caja de texto a validar.
	
	var intEncontrado = "1234567890.".indexOf(String.fromCharCode(window.event.keyCode));		
	//alert(intEncontrado)
	if (intEncontrado == -1) {
		window.event.keyCode = 0;		
	}		
}
/*************************************************************************************
Descripción :    Permite Ingresar solo TEXTO
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaTexto() {                      
      if((window.event.keyCode == 209) || (window.event.keyCode == 241)){            
            var intEncontrado = 0;
            //convierte la ñ en Ñ
            window.event.keyCode = 209;
      }
      else{          
            var ch_Caracter = String.fromCharCode(window.event.keyCode).toUpperCase();
            var intEncontrado = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".indexOf(ch_Caracter);            
            if (intEncontrado == -1)
            {           
                 window.event.keyCode = 0;          
            }
            else
            {
                 window.event.keyCode = ch_Caracter.charCodeAt();
            }
      }
}

/*************************************************************************************
Descripción :    Permite Ingresar solo TEXTO
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaTextoParentesis() {                      
      if((window.event.keyCode == 209) || (window.event.keyCode == 241)){            
            var intEncontrado = 0;
            //convierte la ñ en Ñ
            window.event.keyCode = 209;
      }
      else{          
            var ch_Caracter = String.fromCharCode(window.event.keyCode).toUpperCase();
            var intEncontrado = " ABCDEFGHIJKLMNOPQRSTUVWXYZ()".indexOf(ch_Caracter);            
            if (intEncontrado == -1)
            {           
                 window.event.keyCode = 0;          
            }
            else
            {
                 window.event.keyCode = ch_Caracter.charCodeAt();
            }
      }
}
/*************************************************************************************
Descripción :    Permite Validar se hayan ingresado solo Numeros 
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/    
function fc_ValidaTextoNumerico() {      

      if(	(window.event.keyCode == 209) || 
			(window.event.keyCode == 241) ||
			(window.event.keyCode == 225) || 
			(window.event.keyCode == 233) || 
			(window.event.keyCode == 237) || 
			(window.event.keyCode == 243) || 
			(window.event.keyCode == 250) 
			)
	  {
            var intEncontrado = 0;
            //convierte la ñ en Ñ
            //window.event.keyCode = 209;
      }
      else{          
            var ch_Caracter = String.fromCharCode(window.event.keyCode);//.toUpperCase();
            var intEncontrado = " 1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_,.@&°/!·$%&/()=?¿*^¨Ç_:;¨{}[]".indexOf(ch_Caracter);            
            if (intEncontrado == -1)
            {          
                 window.event.keyCode = 0;          
            }
            /*else
            {
                 window.event.keyCode = ch_Caracter.charCodeAt();
            }*/
      }
}

function fc_ValidaTextoAlfa1() {      

      if((window.event.keyCode == 209) || (window.event.keyCode == 241)){            
            var intEncontrado = 0;
            //convierte la ñ en Ñ
            window.event.keyCode = 209;
      }
      else{          
            var ch_Caracter = String.fromCharCode(window.event.keyCode).toUpperCase();
            var intEncontrado = " ABCDEFGHIJKLMNOPQRSTUVWXYZ-_,.@".indexOf(ch_Caracter);            
            if (intEncontrado == -1)
            {           
                 window.event.keyCode = 0;          
            }
            else
            {
                 window.event.keyCode = ch_Caracter.charCodeAt();
            }
      }
}


/*************************************************************************************
Descripcion :    Permite validar caracteres no validos (cortar/pegar)
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaDecimalFinal(strCad){
	var strCadena = new String(strCad);
	if(strCad == "")
		return true;
			
	var valido = "1234567890.";
			
	strCadena = strCadena;
	for (i = 0 ; i <= strCadena.length - 1; i++)
	{	
		if (valido.indexOf (strCadena.substring(i,i+1),0) == -1)
		{
			valido = strCadena.substring(i,i + 1);
			return false;
		} 
	}	
	return true;
}

/*************************************************************************************
Descripción :    Permite Validar se hayan ingresado solo Numeros 
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumeroFinal(strNameObj, strMensaje){
	var Obj = document.all[strNameObj];
	var strCadena = new String(strNameObj.value);
	if(strCadena == "")
		return true;

	var valido = "0123456789 ";
			
	strCadena = strCadena;
	for (i = 0 ; i <= strCadena.length - 1; i++)
	{	
		if (valido.indexOf (strCadena.substring(i,i+1),0) == -1)
		{
			valido = strCadena.substring(i,i + 1);
			alert ('El Campo ' + strMensaje + ' contiene caracteres no permitidos.' )
			strNameObj.focus();	
			return false;
		} 
	}	
	return true;
}

/*************************************************************************************
Descripcion : Permite validar caracteres no validos (cortar/pegar)
			  Muestra un mensaje de error en caso de que los 
			  caracteres sean no validos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaTextoGeneralFinal(strNameObj,strMensaje){
	var Obj = document.all[strNameObj];
	
	var strCadena = new String(strNameObj.value);


	if(strCadena == "")
		return true;

	var valido = "0123456789abcdefghijklmnopqrstuvwxyz_-ABCDEFGHIJKLMNOPQRSTUVWXYZ.,()@/:& ";
			
	strCadena = strCadena;
	for (i = 0 ; i <= strCadena.length - 1; i++)
	{	
		
		if(String.fromCharCode(241)== strCadena.substring(i,i+1).toLowerCase()) continue;
		if(String.fromCharCode(209)== strCadena.substring(i,i+1).toLowerCase()) continue;
		if(String.fromCharCode(225)== strCadena.substring(i,i+1).toLowerCase()) continue;
		if(String.fromCharCode(233)== strCadena.substring(i,i+1).toLowerCase()) continue;
		if(String.fromCharCode(237)== strCadena.substring(i,i+1).toLowerCase()) continue;
		if(String.fromCharCode(243)== strCadena.substring(i,i+1).toLowerCase()) continue;
		if(String.fromCharCode(250)== strCadena.substring(i,i+1).toLowerCase()) continue;
						 
		
		if (valido.indexOf (strCadena.substring(i,i+1),0) == -1 )
		{
			valido = strCadena.substring(i,i + 1);
			alert ('El Campo ' + strMensaje + ' contiene caracteres no permitidos.' )
			strNameObj.focus();	
			return false;
		} 
		
	}	
	return true; 
}
/*************************************************************************************
Descripcion : Permite validar caracteres no validos (cortar/pegar)
			  Muestra un mensaje de error en caso de que los 
			  caracteres sean no validos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumeroGeneralFinal(strNameObj,strMensaje){
	var Obj = document.all[strNameObj];
	var strCadena = new String(strNameObj.value);
	if(strCadena == "")
		return true;

	var valido = "0123456789_-.,/: ";
			
	strCadena = strCadena;
	for (i = 0 ; i <= strCadena.length - 1; i++)
	{	
		if (valido.indexOf (strCadena.substring(i,i+1),0) == -1)
		{
			valido = strCadena.substring(i,i + 1);
			alert ('El Campo ' + strMensaje + ' contiene caracteres no permitidos.' )
			strNameObj.focus();	
			return false;
		} 
	}	
	return true;
}

/*************************************************************************************
Descripcion : Permite validar caracteres no validos (cortar/pegar)
			  Muestra un mensaje de error en caso de que los 
			  caracteres sean no validos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaTextoGeneralEmail( strNameObj,strMensaje ){
	var Obj = document.all[strNameObj];
	var strCadena = new String(strNameObj.value);
	
	var s = strCadena;
	var filter=/^[A-Za-z][A-Za-z0-9_.]*@[A-Za-z0-9_]+\.[A-Za-z0-9_.]+[A-za-z]$/;
	if (s.length == 0 ) return true;
	if (filter.test(s))
	return true;
	else
	alert("Ingrese una dirección de correo valida");	
	//Obj.focus();
	return false;

}


/*************************************************************************************
Descripción :    Valida que el parametro sea una fecha 
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function isFecha(val,format)
{
	var date=getDateFromFormat(val,format);
	if (date==0) return false;
	
    if ( compareDates(val, format, '01/01/1900', format) == 0 ) return false;
    
	return true;
}


/*************************************************************************************
Descripción :    Valida fecha invocada desde evento onblur
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaFechaOnblur(strNameObj) 
{      
       //strNameObj : Nombre de la caja de texto a validar.
       var Obj = document.all[strNameObj];
       var error=false;
       if (Obj.value !="")
       {
			if(Obj.value.length == 8){
				var _anio = Obj.value.substring(6,8)
				Obj.value = Obj.value.substring(0,6)+'20'+_anio
			}
			
			if (!isFecha(Obj.value,"dd/MM/yyyy")) error=true;
			else{
				strAnho=Obj.value.split("/")[2];

				if (strAnho<'1900') error=true;                
			}
			if (error){
				Obj.value="";
				alert('Debe ingresar una fecha valida.');
				Obj.focus();                      
			}
       }            
}

function fc_PermiteNumeros()
{
	if ((window.event.keyCode<48) || (window.event.keyCode>57)) {
		window.event.returnValue =0;}
}

function fc_ValidaTexto1(strNameObj,strMensaje){
/*************************************************************************************
Descripcion : Permite validar caracteres invalidos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
	var obj = eval(strNameObj);
	var strCadena = obj.value;
	if(strCadena == "")
		return true;

	var valido = "0123456789abcdefghijklmnopqrstuvwxyz_-ABCDEFGHIJKLMNOPQRSTUVWXYZ.,()@/: ";
			
	strCadena = strCadena;
	for (i = 0 ; i <= strCadena.length - 1; i++)
	{	
		if (valido.indexOf(strCadena.substring(i,i+1),0) == -1)
		{
			valido = strCadena.substring(i,i + 1);
			alert ('El Campo ' + strMensaje + ' contiene caracteres no permitidos.' )
			obj.value="";
			obj.focus();	
			return false;
		} 
	}	
	return true;
}


/*************************************************************************************
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaFecha(strNameObj) 
{	
	//strNameObj : Nombre de la caja de texto a validar.
	var Obj = document.all[strNameObj];
	var intEncontrado = "1234567890/".indexOf(String.fromCharCode(window.event.keyCode));		
	if (intEncontrado == -1) {
		window.event.keyCode = 0;		
	}
	//agregado 
	if (document.all[strNameObj].value.length == 2 || document.all[strNameObj].value.length == 5)
	{
	document.all[strNameObj].value = document.all[strNameObj].value + "/";
	}		
}

function fc_PermiteNumeros()
{
	if ((window.event.keyCode<48) || (window.event.keyCode>57)) {
		window.event.returnValue =0;}
}

function fc_Slash(form,objeto,separador)
{var obj
	fc_PermiteNumeros();
	if (form != ''){obj= eval(form + '.'+ objeto)} 
	else {obj= eval(objeto)}
	if ((obj.value.length == 2)||(obj.value.length ==5)){obj.value = obj.value + separador;}
    if (obj.value.length = obj.maxlength-1){return;}
}

			

/*MouseOver*/
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

/*************************************************************************************
Descripción :    Valida la hora de formato (HH:MM)
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaHoraOnBlur(form,strNameObj,strMensaje)
{
	var obj = eval(form + '.'+strNameObj);
	var numHor,numMin,error;
	var strCadena = obj.value;
	error = 0;
	if(strCadena == ""){
		return true;}
	if (strCadena.length !=5){ error = 1;}		
	else{
		var arr=strCadena.split(":");	
		if (arr[0].charAt(0)=='0')
			numHor = parseInt(arr[0].charAt(1));
		else
			numHor = parseInt(arr[0]);
		if (arr[1].charAt(0)=='0')
			numMin = parseInt(arr[1].charAt(1));
		else
			numMin = parseInt(arr[1]);
		if ((numHor>24) || (numMin>59) || (numHor==24 & numMin!=0)){error = 1;}
	}
	if (error==1){
		alert('El Campo ' + strMensaje + ' es invalido. El formato de hora es HH:MM');
		obj.value="";
		obj.focus();
		return false;		
	}
	return true;
}


/*************************************************************************************
Descripción :    Valida si la hora de inicio es menor a la final de acuerdo a sus fechas
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaRangoHoraOnBlur(form,fec1,fec2,strNameObj1,strNameObj2,num)
{	
	var objFec1 = document.getElementById(fec1);
	var strFec1 = objFec1.value;
	var objFec2 = document.getElementById(fec2);
	var strFec2 = objFec2.value;
	var obj1 = document.getElementById(strNameObj1);
	var strCadena1 = obj1.value;
	var obj2 = document.getElementById(strNameObj2);
	var strCadena2 = obj2.value;	
	var numHor1,numMin1,numHor2,numMin2,arr1,arr2;	
	if (strCadena1!="" & strCadena2!=""){
		arr1=strCadena1.split(":");			
		if (arr1[0].charAt(0)=='0')
			numHor1 = parseInt(arr1[0].charAt(1));
		else
			numHor1 = parseInt(arr1[0]);
		if (arr1[1].charAt(0)=='0')
			numMin1 = parseInt(arr1[1].charAt(1));
		else
			numMin1 = parseInt(arr1[1]);
		arr2=strCadena2.split(":");	
		if (arr2[0].charAt(0)=='0')
			numHor2 = parseInt(arr2[0].charAt(1));
		else
			numHor2 = parseInt(arr2[0]);
		if (arr2[1].charAt(0)=='0')
			numMin2 = parseInt(arr2[1].charAt(1));
		else
			numMin2 = parseInt(arr2[1]);				
		if ((strFec1==strFec2) & ((numHor1>numHor2) || (numHor1==numHor2 & numMin1>=numMin2)))
		{
			alert("La horaInicial debe ser menor a la horaFinal");
			if (num==1){
				obj1.value="";
				obj1.focus();
			}
			else{
				obj2.value="";
				obj2.focus();
			}
		}
	}
}


/*************************************************************************************
Descripción :    Borra valores de controles
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_BorraValores(form,strNomb1,strNomb2){
	if (form!=""){
		if (strNomb1!=""){
			eval(form+"."+strNomb1).value="";
		}
		if (strNomb2!=""){
			eval(form+"."+strNomb2).value="";
		}	
	}
}
 
/*************************************************************************************
Descripción :    Valida que fecha ingresada sea menor o igual a la actual
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaFechaActualOnblur(strNameObj,num){
	var Obj = document.all[strNameObj];
	var strDia,strMes,strAnho;
	var today = new Date();
	strAnho= today.getYear();
	strMes = (today.getMonth()+1);
	strDia = today.getDate();
	if (parseInt(strMes)<=9)
		strMes = '0'+strMes;
	if (parseInt(strDia)<=9)
		strDia = '0'+strDia;	
	var strFechaActual = strDia+"/"+strMes+"/"+strAnho;
    if (Obj.value !=""){
		if ((num=='1') & (fc_ValidaFechaIniFechaFin(Obj.value,strFechaActual)!=1))
		{		
			alert("Debe ingresar una fecha mayor a la fecha actual");
			Obj.value="";
			Obj.focus();
		}   
		else if ((num=='2') & (fc_ValidaFechaIniFechaFin(strFechaActual,Obj.value)!=1))
		{
			alert("Debe ingresar una fecha menor a la actual");
			Obj.value="";
			Obj.focus();
		}    
    }
}

/*************************************************************************************
Descripción :    Valida la igualdad de dos campos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumerosOnblur(strObjNum1,strObjNum2,strCampo1,strCampo2,pos,operando)
{
	obj1 = document.getElementById(strObjNum1);
	obj2 = document.getElementById(strObjNum2);
	var num1= parseInt(obj1.value);
	var num2= parseInt(obj2.value);
	var mje;
	var error=false;
	if ((num1!="") && (num2!=""))
	{		
		if (operando=="MAYOR"){
			if (num1<=num2){
				mje="El campo "+strCampo1+" debe ser mayor que el campo "+strCampo2;				
				error=true;}
		}
		else if (operando=="MENOR"){
			if (num1>=num2){
				mje="El campo "+strCampo1+" debe ser menor que el campo "+strCampo2;				
				error=true;}
		}
		else if (operando=="MAYORIG"){
			if (num1<num2){
				mje="El campo "+strCampo1+" debe ser mayor o igual que el campo "+strCampo2;				
				error=true;}
		}
		else if (operando=="MENORIG"){
			if (num1>num2){
				mje="El campo "+strCampo1+" debe ser menor o igual que el campo "+strCampo2;				
				error=true;}
		}
		else if (operando=="IGUAL"){
			if (num1!=num2){
				mje="El campo "+strCampo1+" debe ser igual que el campo "+strCampo2;				
				error=true;}
		}
		if (error)
		{
			alert(mje);
			if (pos=="1"){ obj1.value="";obj1.focus();}
			else{ obj2.value="";obj2.focus();}		
		}	
	}
}

 
/*************************************************************************************
Descripción :    Permite validar la longitud de los valores ingresados en el campo.
				 Dicha longitud debe ser mayor igual que pintMin y menor igual que pintMax.
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaLongitud(pstrNombreControl, pstrMensaje, pstrComparacion, pintValor)
{
	var lobjControl = document.getElementById(pstrNombreControl);
	var lstrValor = lobjControl.value;
	var lintLongitud = lstrValor.length;
	
	switch(pstrComparacion)
	{
		case ">":
			if(Number(lintLongitud) > Number(pintValor))
				return true;
			else
			{
				lobjControl.focus();
				alert("La longitud de " + pstrMensaje + " debe ser mayor a " + pintValor + " caracteres" );
			}
			break;
		case ">=":
			if(Number(lintLongitud) >= Number(pintValor))
				return true;
			else
			{
				lobjControl.focus();
				alert("La longitud de " + pstrMensaje + " debe ser mayor igual a " + pintValor + " caracteres" );
			}
			break;
		case "<":
			if(Number(lintLongitud) < Number(pintValor))
				return true;
			else
			{
				lobjControl.focus();
				alert("La longitud de " + pstrMensaje + " debe ser menor a " + pintValor + " caracteres" );
			}
			break;
		case "<=":
			if(Number(lintLongitud) <= Number(intValor))
				return true;
			else
			{
				lobjControl.focus();
				alert("La longitud de " + pstrMensaje + " debe ser menor igual a " + pintValor + " caracteres" );
			}
			break;
		case "=":
			if(Number(lintLongitud) == Number(pintValor))
				return true;
			else
			{
				lobjControl.focus();
				alert("La longitud de " + pstrMensaje + " debe ser igual a " + pintValor + " caracteres" );
			}
			break;

	}
	return false;
}

/*************************************************************************************
Descripción :    Valida que fecha ingresada sea menor/mayor o igual a la actual
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaFechaActualRet(strNameObj,num){
	var Obj = document.all[strNameObj];
	var strDia,strMes,strAnho;
	var today = new Date();
	strAnho= today.getYear();
	strMes = (today.getMonth()+1);
	strDia = today.getDate();
	if (parseInt(strMes)<=9)
		strMes = '0'+strMes;
	if (parseInt(strDia)<=9)
		strDia = '0'+strDia;	
	var strFechaActual = strDia+"/"+strMes+"/"+strAnho;
	var dFec = Obj.value.substr(6,4) + "/" + Obj.value.substr(3,2) + "/" + Obj.value.substr(0,2);  
	var dActual = strFechaActual.substr(6,4) + "/" + strFechaActual.substr(3,2) + "/" + strFechaActual.substr(0,2); 
				
    if (Obj.value !="")
    {
		if ((num=='1') && (dFec < dActual))
		{		
			alert("Debe ingresar una fecha mayor o igual a la fecha actual");
			Obj.value="";
			Obj.focus();
			return false;
		}		   
		else if ((num=='2') & (dFec >= dActual))
		{
			alert("Debe ingresar una fecha menor a la actual");
			Obj.value="";
			Obj.focus();
			return false
		}
		else if ((num=='3') & (dFec > dActual))
		{
			alert("Debe ingresar una fecha menor o igual a la actual");
			Obj.value="";
			Obj.focus();
			return false
		}		
    }
    return true;
}

/*************************************************************************************
Descripción :    Valida que fecha ingresada sea menor o mayor x dias a la fecha actual 
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaFechaDeltaOnblur(strNameObj,x,delta,num){
	var Obj = document.all[strNameObj];
	var strDia,strMes,strAnho;
	var today = new Date();
	strAnho= today.getYear();
	strMes = (today.getMonth()+1);
	strDia = today.getDate();
	if (parseInt(strMes)<=9)
		strMes = '0'+strMes;
	if (parseInt(strDia)<=9)
		strDia = '0'+strDia;	
	var strFechaActual = strDia+"/"+strMes+"/"+strAnho;
	var operador;
	if (delta=='1'){
		operador="menos";
		y=x*-1;
	}
	else{ 
		operador="mas"
		y=x;
	}
	var strFechaDelta =fc_AgregaDias(strFechaActual,y);	
    if (Obj.value !=""){
		if ((num=='1') & (fc_ValidaFechaIniFechaFin(Obj.value,strFechaDelta)!=1))
		{		
			alert("Debe ingresar una fecha mayor a la fecha actual "+operador+" "+x+" dias");
			Obj.value="";
			Obj.focus();
		}   
		else if ((num=='2') & (fc_ValidaFechaIniFechaFin(strFechaDelta,Obj.value)!=1))
		{
			alert("Debe ingresar una fecha menor a la fecha actual "+operador+" "+x+" dias");
			Obj.value="";
			Obj.focus();
		}    
    }
}

/*************************************************************************************
Descripción :    Permite validar los campos de un formulario.
				 Recibe como parametro el nombre de la caja de texto a validar, 
				 el mensaje que se desea mostrar, un flag que indica el tipo de 
				 validacion que se desea realizar y un valor booleano que indica si
				 el campo es obligatorio o no.
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaCampos(pstrNombreControl, pstrMensaje, pstrTipoValidacion, pboolEsObligatorio)
{	
    var lobjControl = document.getElementById(pstrNombreControl);
	var pstrValor = lobjControl.value;
	
	if(fc_Trim(pstrValor).length > 0)
	{
		switch(pstrTipoValidacion)
		{
			case 'Texto':
				return fc_ValidaTextoGeneralFinal(pstrNombreControl, pstrMensaje);
				break;
			case 'Numero':
				return fc_ValidaNumeroFinal(lobjControl, pstrMensaje);
				break;
			case 'Decimal':
				return fc_ValidaDecimalFinal(pstrValor);
				break;
			case 'Fecha Mayor':
				return fc_ValidaFechaActualRet(pstrNombreControl, '1');
				break;
			case 'Fecha Menor':
				return fc_ValidaFechaActualRet(pstrNombreControl, '2');
				break;
			case 'Fecha Menor Igual':
				return fc_ValidaFechaActualRet(pstrNombreControl, '3');
				break;
			case 'Email':
			    return fc_ValidaTextoGeneralEmail(lobjControl, pstrMensaje);
			    break;
			default:
				return false;
				break;
		}
	}
	else
	{
	    if(pboolEsObligatorio)
	    {
			lobjControl.focus();
			alert("Debe ingresar el valor correspondiente en el campo " + pstrMensaje);
		}
		return !pboolEsObligatorio;
	}
}



function fc_ValidaSoloLetrasFinal(strNameObj,strMensaje){
/*************************************************************************************
Descripcion : Permite ingresar solo letras o espacio en blanco
			  Muestra un mensaje de error en caso de que los 
			  caracteres sean no validos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
	var Obj = document.all[strNameObj];
	
	var strCadena = new String(strNameObj.value);
	if(strCadena == "")
		return true;

	var valido = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ.";
			
	strCadena = strCadena;
	for (i = 0 ; i <= strCadena.length - 1; i++)
	{	
		if (valido.indexOf (strCadena.substring(i,i+1),0) == -1)
		{
			valido = strCadena.substring(i,i + 1);
			alert ('El Campo ' + strMensaje + ' contiene caracteres no permitidos.' )
			strNameObj.focus();	
			return false;
		} 
	}	
	return true;
}


function fc_Consisfec(xdia,xmes,xano) {
/*************************************************************************************
Descripción :    Funcion que consistencia la fecha 
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
  var meses=new Array(31,28,31,30,31,30,31,31,30,31,30,31);
  meses[1]=((xano % 4)==0) ? 29 : 28;
  return ((xdia<=meses[xmes-1]) ? true : false );  // true -> OK  false -> KO
 }
 

function fc_Trim(pstrInput) {
/*************************************************************************************
Descripción :    Función que quitar los espacios en blanco de del parametro string
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
	var i;
	var vstrTemp = '';
	var j = 0;
	var cadena = pstrInput;
	
	for(i=0; i<cadena.length; )
	    {
		    if(cadena.charAt(i)==" ")
			    cadena=cadena.substring(i+1, cadena.length);
		    else
			    break;
	    }

	    for(i=cadena.length-1; i>=0; i=cadena.length-1)
	    {
		    if(cadena.charAt(i)==" ")
			    cadena=cadena.substring(0,i);
		    else
			    break;
	    }
	return cadena;
}
 
function fc_ValidaLongitudRuc(strNameObj){
/*************************************************************************************
Descripcion : Valida que la longitud del Ruc sea 11 digitos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
	Obj = document.all[strNameObj];
	var cad = Obj.value;
		
	if (cad !=""){
		if (cad.length<11)
		{		
			alert("La longitud del Nro Ruc es menor a 11");
			Obj.value="";
			Obj.focus();
		}   		
	}
}

function fc_ValidaLongitudDNI(strNameObj){
/*************************************************************************************
Descripcion : Valida que la longitud del Ruc sea 11 digitos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
	
	Obj = document.all[strNameObj];
	var cad = Obj.value;
		
	if (cad !=""){
		if (cad.length<8 | cad.length>8 )
		{		
			alert("Longitud del Nro DNI erronea");
			Obj.value="";
			Obj.focus();
		}
	}
}
/*************************************************************************************
Descripción :    Establece el Formato de la Caja de texto
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_InputMask( toField, tcMask )
{
	var lcMaskChar, lcNewChar = String.fromCharCode(window.event.keyCode);
	var llRetVal = true;
	
	if (tcMask.length == 0)
		return true;
		
	if (toField.value.length >= tcMask.length)  
	{
		llRetVal = false;
	}
	else                                        
	{
		lcMaskChar = tcMask.charAt(toField.value.length);
		switch (lcMaskChar)
		{
			case '9':  
				llRetVal = (lcNewChar >= '0' && lcNewChar <= '9') ;
				break;
			case 'X':  
				break;
			case '!':  
				window.event.keyCode = lcNewChar.toUpperCase().charCodeAt(0);
				break;			         
			default:   
				toField.value += lcMaskChar;
				llRetVal = fc_InputMask(toField, tcMask);
		}
	}
	
	return llRetVal;

}
/*************************************************************************************
Descripción :    Valida la hora en formato de 24h
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function isHora(pstrHora, pstrFormato)
{
	if(!((Number(pstrHora.substring(0,2))>=0)&&(Number(pstrHora.substring(0,2))<24))){return false;}
	if(!((Number(pstrHora.substring(3,5))>=0)&&(Number(pstrHora.substring(3,5))<60))){return false;}
	return true;

}
function FP_ValidaHoraOnblur(strNameObj) 
{					
	var Obj = document.all[strNameObj];
	
	if (Obj.value !="")
	{ if (!isHora(Obj.value,"HH:mm") || Obj.value.replace(/ /g,'').length != 5) {
			alert('Debe ingresar una hora valida.\nEl formato de hora es: HH:mm.\n\nFormato de 24 horas.');
			Obj.value="";
			Obj.focus();
		}		
	}	
}
/*************************************************************************************
Descripción :   Establece el Formato de la Caja de texto
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumeroEntero(pstrValor)
{
	if(pstrValor.toString().match(/^\d+$/g))
		return true
		
	return false
}
/*************************************************************************************
Descripción :    Permite Ingresar solo numeros y un guion
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaPeriodoAnio(){	
	var intEncontrado = "1234567890-".indexOf(String.fromCharCode(window.event.keyCode));		
	if (intEncontrado == -1) {
		window.event.keyCode = 0;		
	}		
}

function fc_Guion(form,objeto,separador)
/*************************************************************************************
Descripción :    Permite Ingresar el guion como separador
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
{var obj
	fc_PermiteNumeros();
	if (form != ''){obj= eval(form + '.'+ objeto)} 
	else {obj= eval(objeto)}
	if (obj.value.length == 2){obj.value = obj.value + separador;}
    if (obj.value.length = obj.maxlength-1){return;}
}

/*************************************************************************************
Descripción :    Permite validar un objeto que tiene como valor un decimal
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaObjDecimalOnBlur(Obj, NumEntero, NumDecimal)
{
    alert(Obj.value);
	if (Obj.value !="")
	{
		if (!fc_ValidaDecimal(Obj.value, NumEntero, NumDecimal)) {
			Obj.value="";
			alert('Debe ingresar un valor correcto.');
							
		}
	}
}

/*************************************************************************************
Descripción :    Permite validar el ingreso de numeros o punto.
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNumerico() {
	var ch_Caracter = String.fromCharCode(window.event.keyCode);
	var intEncontrado = "0123456789.".indexOf(ch_Caracter);
	if (intEncontrado == -1) {	
		window.event.keyCode = 0;		
	}
	else {
		window.event.keyCode = ch_Caracter.charCodeAt();
	}	
}

/*************************************************************************************
Descripción :    Permite validar el ingreso de caracteres de un grupo sanguineo
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaGrupoSang() {
	var ch_Caracter = String.fromCharCode(window.event.keyCode);
	var intEncontrado = "ABCOH+-".indexOf(ch_Caracter);
	if (intEncontrado == -1) {	
		window.event.keyCode = 0;		
	}
	else {
		window.event.keyCode = ch_Caracter.charCodeAt();
	}	
}


/*************************************************************************************
Descripcion : Permite validar caracteres
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
 function fc_ValidaLetrasNumerosPunto() { 
	
	var valido = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.() ";                     
      if((window.event.keyCode == 209) || (window.event.keyCode == 241)){            
            var intEncontrado = 0;
            window.event.keyCode = 209;
      }
      else{          
            var ch_Caracter = String.fromCharCode(window.event.keyCode).toUpperCase();
            var intEncontrado = valido.indexOf(ch_Caracter);            
            if (intEncontrado == -1)
            {           
                 window.event.keyCode = 0;          
            }
            else
            {
                 window.event.keyCode = ch_Caracter.charCodeAt();
            }
      }
}

/*************************************************************************************
Descripcion : Permite validar NUMEROS Y GUION
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
 function fc_ValidaNumerosGuion() { 
	
	var valido = "0123456789- ";                     
      if((window.event.keyCode == 209) || (window.event.keyCode == 241)){            
            var intEncontrado = 0;
            window.event.keyCode = 209;
      }
      else{          
            var ch_Caracter = String.fromCharCode(window.event.keyCode).toUpperCase();
            var intEncontrado = valido.indexOf(ch_Caracter);            
            if (intEncontrado == -1)
            {           
                 window.event.keyCode = 0;          
            }
            else
            {
                 window.event.keyCode = ch_Caracter.charCodeAt();
            }
      }
}
function fc_ValidaNegativo(){	
	var intEncontrado = "1234567890-.".indexOf(String.fromCharCode(window.event.keyCode));		
	if (intEncontrado == -1) {
		window.event.keyCode = 0;		
	}		
}
/*************************************************************************************
Descripción :    Valida un onjeto con decimales negativos
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaNegOnBlur(strNombre)
{
	Obj = document.all[strNombre];
	if (Obj.value !="")
	{
		if (isNaN(Obj.value)) {
			Obj.value="";
			alert('Debe ingresar un valor correcto.');
			Obj.focus();				
		}
	}
}

/*************************************************************************************
Descripción :    Permite Ingresar solo caracteres "C / A" para el mantenimiento de 
				 Contabilidad-Cobranzas Mixtas vs. Ctas
Autor 		:    Eddy Dominguez Flores
Fecha/hora	:    28/12/2009
*************************************************************************************/
function fc_ValidaCaracter_CA() { 
	var intEncontrado = "acAC";
	
	var ch_Caracter = String.fromCharCode(window.event.keyCode).toUpperCase();
    var intEncontrado = intEncontrado.indexOf(ch_Caracter);            
    if (intEncontrado == -1) {           
		window.event.keyCode = 0;          
    }
    else {
		window.event.keyCode = ch_Caracter.charCodeAt();
    }
}

function fc_ValidaSoloTextoNumero(){	
	var valido = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";                     
      if((window.event.keyCode == 209) || (window.event.keyCode == 241)){            
            var intEncontrado = 0;
            window.event.keyCode = 209;
      }
      else{          
            var ch_Caracter = String.fromCharCode(window.event.keyCode).toUpperCase();
            var intEncontrado = valido.indexOf(ch_Caracter);            
            if (intEncontrado == -1)
            {           
                 window.event.keyCode = 0;          
            }
            else
            {
                 window.event.keyCode = ch_Caracter.charCodeAt();
            }
      }	
}

function fc_ValidaDecimalNegativoOnBlur(strNameObj, NumEntero, NumDecimal)
{
	var Obj = document.all[strNameObj];
	if (Obj.value !="")
	{
		if (!fc_ValidaDecimalNegativo(Obj.value, NumEntero, NumDecimal)) {
			Obj.value="";
			alert('Debe ingresar un valor correcto.');
			Obj.focus();				
		}
		var num= Number(Obj.value)
		Obj.value = num.toFixed(NumDecimal)
	}
}

function fc_ValidaDecimalNegativo(fieldValue, NumEntero, NumDecimal) 
{
	decallowed = NumDecimal;  // Numero de Decimales
	intallowed = NumEntero;  // Numero de Enteros

	if (isNaN(fieldValue) || fieldValue == "") 
	{
		return false;
	}
	else 
	{
		if (fc_ValidaDecimalFinalNegativo(fieldValue)==false) {return false;}
		
		if (fieldValue.indexOf('.') == -1) fieldValue += ".";
		dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);
		inttext = fieldValue.substring(0,fieldValue.indexOf('.'));

		if (dectext.length > decallowed || inttext.length > intallowed)
		{
			return false;
		}
	}
	return true;
}

function fc_ValidaDecimalFinalNegativo(strCad){
	var strCadena = new String(strCad);
	if(strCad == "")
		return true;
			
	var valido = "1234567890.-";
			
	strCadena = strCadena;
	for (i = 0 ; i <= strCadena.length - 1; i++)
	{	
		if (valido.indexOf (strCadena.substring(i,i+1),0) == -1)
		{
			valido = strCadena.substring(i,i + 1);
			return false;
		} 
	}	
	return true;
}

function fc_ValidarRuc(strNomRuc)
        {			
            var suma = "0";
            var Ruc = new String(document.getElementById(strNomRuc).value);			
            var result = false;
            var cadena = "";
            if (Ruc!="99999999999")
            {
         		if (Ruc.length == 11)
				{
					Ruc = Ruc.split("");
					var strPar = new String("5,4,3,2,7,6,5,4,3,2,");
					var arrPar = new Array(10);
					arrPar = strPar.split(",");

					var caracter = parseFloat(Ruc[10]);
					for(var i=0; i<10; i++)
					{
						suma = parseFloat(suma) + parseFloat(arrPar[i]) * parseFloat(Ruc[i]);
					}
							
					var resto = suma % 11;
					var verificador = 11 - resto;
					if (verificador==11){
							verificador = 1;
					}
					else if (verificador==10){
							verificador = 0;
					}
					if (verificador!=caracter){						
						cadena = mstrRUCInvalido;
						document.getElementById(strNomRuc).focus();
						result = false;
					}
					else {result = true;}
				}
				else
				{
					result = false;					
					cadena = mstrLongitudRUC;
					document.getElementById(strNomRuc).focus();
				}
            }
            else
            {
            result = true;}            
            
            return cadena;
		}