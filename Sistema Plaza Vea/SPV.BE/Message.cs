using System;
using System.Collections.Generic;
using System.Text;


namespace SPV.BE
{
    public class Message
    {
        //General    
        public static String keyElimino = "mstrElimino";
        public static String keyNoElimino = "mstrNoElimino";
        public static String keyNoEliminoRelacionado = "mstrNoEliminoRelacionado";
        public static String keyNoRegistros = "mstrNoRegistros";
        public static String keySeleccioneUno = "mstrSeleccioneUno";
        public static String keySeguroGrabar = "mstrSeguroGrabar";

        public static String keySeguroEliminarUno = "mstrSeguroEliminarUno";
        public static String keyActualizar = "mstrActualizar";
        public static String keyErrorGrabar = "mstrErrorGrabar";
        public static String KeyErrorDocGrabar = "mstrErrorDocGrabar";
        public static String keyErrorRazSocGrabar = "keyErrorRazSocGrabar";
        public static String KeyErrorDuplicidad = "mstrErrorGrabarDuplicado";
        public static String KeyErrorDupModificar = "mstrErrorDupModificar";
        public static String keyErrorGrabarDuplicado = "mstrErrorGrabarDuplicado";
        public static String keyErrorGrabarNulo = "mstrErrorGrabarNulo";
        public static String keyErrorGrabarLlave = "mstrErrorGrabarLLave";
        public static String keyGrabar = "mstrGrabar";
        public static String KeyExiste = "mstrExiste";
        public static String KeyRUCExiste = "mstrRUCExiste";  //validacion solo para a nivel de pagina
        public static String KeyDNIExiste = "mstrDNIExiste";  //validacion solo para a nivel de pagina
        public static String KeyPartidaExiste = "mstrPartidaExiste";  //validacion solo para a nivel de pagina
        public static String KeyImprimirOK = "mstrImprimirOK";
        public static String KeySeguroImprimir = "mstrSeguroImprimir";
        public static String KeyDocExiste = "mstrDocYaExiste";
        public static String KeyStockInsuficiente = "mstrErrorSinStock";//Error, stock insuficiente
        public static String KeyInventarioInsuficiente = "mstrErrorSinInventario";//Error, inventario insuficiente
        public static String KeyErrorCierreOperacion = "mstrErrorCierreOperacion";//Error, Fecha de operaciones ya cerrada
        public static String KeyErrorPerfil = "mstrErrorPerfil";
        public static String keyErrorGrabarDuplicadoPlan = "mstrErrorGrabarDuplicadoPlan";
        public static String keyErrorGrabarDuplicadoPresupuesto = "mstrErrorGrabarDuplicadoPresupuesto";
        public static String keyExtraerExactus = "mstrExtraerExactus";
        public static String keyErrorExtraerExactus = "mstrErrorExtraerExactus";

        public static String keyAdjuntar = "mstrAdjuntar";
        public static String keyErrorAdjuntar = "mstrErrorAdjuntar";

        public static String keyCambioEstado = "mstrCambioEstado";
    }
}