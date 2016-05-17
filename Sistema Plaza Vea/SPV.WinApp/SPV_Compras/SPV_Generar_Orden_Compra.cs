using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPV.BL.SPV_Compras;

namespace SPV.WinApp.SPV_Compras
{
    public partial class SPV_Generar_Orden_Compra : Form
    {
        public String hora_ejecucion = String.Empty;

        private void SPV_Generar_Orden_Compra_Load(object sender, EventArgs e)
        {
            hora_ejecucion = txtHora.Text.Trim().ToString();
        }

        public SPV_Generar_Orden_Compra()
        {
            InitializeComponent();
        }

        #region Métodos
        private void GenerarOrdenCompra() { 
            
        }
        #endregion

        #region Botones
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            hora_ejecucion = txtHora.Text.Trim().ToString();
        }

        private void BtnDetener_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            String Hora_sistema = DateTime.Now.Hour.ToString() + ":" +DateTime.Now.Minute.ToString();
            if (Hora_sistema.Equals(hora_ejecucion))
            {
                MessageBox.Show("hola: " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
            }
        }
        #endregion
    }
}
