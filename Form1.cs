using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aplicativaa1
{
    public partial class Form1 : Form
    {
        string cadenaConexion = @"Server=localhost\SqlExpress; DataBase=Comercial; Integrated Security = true";
        SqlDataAdapter adaptador;
        SqlConnection conexion;
        DataSet datos;
        public Form1()
        {
            InitializeComponent();

            dgvDatos.AutoGenerateColumns = false;

            // Creamos la instancia de la Conexion
            conexion = new SqlConnection(cadenaConexion);

            // Creamos la instancia del Adaptador
            adaptador = new SqlDataAdapter();

            // Creamos la instancia del DataSet
            datos = new DataSet();

            // Configurar métodos del adaptador
            adaptador.SelectCommand = new SqlCommand("SELECT * FROM Cliente", conexion);

            adaptador.InsertCommand = new SqlCommand("INSERT INTO Cliente(Apellidos) VALUES(@apellidos)", conexion);
            adaptador.InsertCommand.Parameters.Add("@apellidos", SqlDbType.VarChar, 50, "Apellidos");

            adaptador.InsertCommand = new SqlCommand("INSERT INTO Cliente(Nombres) VALUES(@nombres)", conexion);
            adaptador.InsertCommand.Parameters.Add("@nombres", SqlDbType.VarChar, 50, "Nombres");

            adaptador.InsertCommand = new SqlCommand("INSERT INTO Cliente(Direccion) VALUES(@direccion)", conexion);
            adaptador.InsertCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 80, "Direccion");

            adaptador.InsertCommand = new SqlCommand("INSERT INTO Cliente(Telefono) VALUES(@telefono)", conexion);
            adaptador.InsertCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 20, "Telefono");

            adaptador.InsertCommand = new SqlCommand("INSERT INTO Cliente(Email) VALUES(@email)", conexion);
            adaptador.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 40, "Email");

            adaptador.InsertCommand = new SqlCommand("INSERT INTO Cliente(Tipo) VALUES(@tipo)", conexion);
            adaptador.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 10, "Tipo");

            /*adaptador.UpdateCommand = new SqlCommand("UPDATE Cliente SET Tipo = @tipo WHERE LimiteCredito = @limitecredito", conexion);
             adaptador.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 10, "Tipo");
             adaptador.UpdateCommand.Parameters.Add("@limitecredito", SqlDbType.Decimal, 14, "LimiteCredito");*/
            adaptador.InsertCommand = new SqlCommand("INSERT INTO Cliente(LimiteCredito) VALUES(@limitecredito)", conexion);
            adaptador.InsertCommand.Parameters.Add("@limitecredito", SqlDbType.VarChar, 10, "LimiteCredito");

            adaptador.UpdateCommand = new SqlCommand("UPDATE Cliente SET Nombre = @nombre WHERE ID = @id", conexion);
            adaptador.UpdateCommand.Parameters.Add("@nombres", SqlDbType.VarChar, 50, "Nombres");
            adaptador.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 1, "ID");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }
        private void mostrarDatos()
        {
            // Llenar datos al DataSet (DataTable TipoCliente)
            adaptador.Fill(datos, "Cliente");

            //Enlazar datos al DataGridView
            dgvDatos.DataSource = datos.Tables["Cliente"];
        }

        private void AgregarNuevo(object sender, EventArgs e)
        {
            var frm = new Editar();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var nuevafila = datos.Tables["Cliente"].NewRow();
                nuevafila["Apellidos"] = frm.Controls["txtapellido"].Text;
                nuevafila["Nombres"] = frm.Controls["txtnombre"].Text;
                nuevafila["Direccion"] = frm.Controls["txtdireccion"].Text;
                nuevafila["Telefono"] = frm.Controls["txttelefono"].Text;
                nuevafila["Email"] = frm.Controls["txtemail"].Text;
                nuevafila["Tipo"] = frm.Controls["cbotipo"].Text;
                nuevafila["LimiteCredito"] = frm.Controls["txtcredito"].Text;


                datos.Tables["Cliente"].Rows.Add(nuevafila);
                adaptador.Update(datos.Tables["Cliente"]);
            }
        
          /*  Editar Agregar = new Editar();
            Agregar.Show();
            this.Hide();*/
        }

       

        private void EditarDatos(object sender, EventArgs e)
        {
            var filaActual = dgvDatos.CurrentRow;
            if (filaActual != null)
            {
                var ID = filaActual.Cells[0].Value.ToString();
                DataRow fila = datos.Tables["Cliente"].Select($"ID={ID}").FirstOrDefault();

                var frm = new Editar(fila);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    fila["Apellidos"] = frm.Controls["txtapellido"].Text;
                    fila["Nombres"] = frm.Controls["txtnombre"].Text;
                    fila["Direccion"] = frm.Controls["txtdireccion"].Text;
                    fila["Telefono"] = frm.Controls["txttelefono"].Text;
                    fila["Email"] = frm.Controls["txtemail"].Text;
                    fila["Tipo"] = frm.Controls["cbotipo"].Text;
                    fila["LimiteCredito"] = frm.Controls["txtcredito"].Text;
                    
               
                }
            }
        }
    }
}
