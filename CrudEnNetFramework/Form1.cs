using CrudEnNetFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudEnNetFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CargaGrid()
        {
            var Usuarios = new Usuario();

            var ListaUsuarios = Usuarios.Leer();
            dataGridView1.DataMember = "";
            dataGridView1.DataSource = ListaUsuarios;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CargaGrid();

            CrearNuevoButtonXFila("Editar/Actualizar");
            CrearNuevoButtonXFila("Eliminar");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.Crear(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
            CargaGrid();
        }

        private void CrearNuevoButtonXFila(string Text)
        {
            DataGridViewButtonColumn NewButton = new DataGridViewButtonColumn();

            NewButton.FlatStyle = FlatStyle.Popup;
            NewButton.HeaderText = Text;
            NewButton.Name = Text;
            NewButton.UseColumnTextForButtonValue = true;
            NewButton.Text = Text;
            NewButton.Width = 80;

            dataGridView1.Columns.Add(NewButton);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Usuarios = new Usuario();

            if (e.ColumnIndex == 5) // Editar - Actualizar
            {
                Usuarios.Actualizar(
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()), //Id
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), // Nombre
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), // Usuario
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), // Correo
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()  // Contrasena
                    );
            }
            else if (e.ColumnIndex == 6) // Eliminar
            {
                Usuarios.Eliminar(
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) // Id
                    );
            }

            CargaGrid();
        }
    }
}
