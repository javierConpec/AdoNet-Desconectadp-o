using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicativaa1
{
    public partial class Editar : Form
    {
        
        DataRow fila;
        public Editar(DataRow filaEditar = null)
        {
            InitializeComponent();
            if(filaEditar != null)
            {
                this.fila = filaEditar;
                this.Text = "Editar Datos";
                mostrardatos();
            }
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                e.Handled = true;*/

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                e.Handled = true;*/
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                e.Handled = true;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
           cbotipo.Items.Add("Platinium");
            cbotipo.Items.Add("Golden");
            cbotipo.Items.Add("Vip");
        }

     

        private void CargarDatos(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }
        private void mostrardatos()
        {
            txtapellido.Text = this.fila["Apellidos"].ToString();
            txtnombre.Text = this.fila["Nombres"].ToString();
            cbotipo.Text = this.fila["Tipo"].ToString();
            txtcredito.Text = this.fila["LimiteCredito"].ToString();
            txttelefono.Text = this.fila["Telefono"].ToString();
            txtemail.Text = this.fila["Email"].ToString();
            txtdireccion.Text = this.fila["Direccion"].ToString();

        }

        private void txtcredito_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Form1 Cancelar = new Form1();
            Cancelar.Show();
            this.Hide();
        }

        private void cbotipo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
