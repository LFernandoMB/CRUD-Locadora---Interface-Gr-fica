using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Locadora
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            if (Movie.Id != "")
            {
                txtId.Text = Movie.Id;
                txtFilme.Text = Movie.Filme;
                txtDiretor.Text = Movie.Diretor;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                RegistrarFilme();
                LimparCampos();
                this.Close();
            }
            else
                MessageBox.Show("Ainda há Campos em Branco!");
        }

        private void RegistrarFilme()
        {
            Movie.Id = txtId.Text;
            Movie.Filme = txtFilme.Text;
            Movie.Diretor = txtDiretor.Text;
        }

        private void LimparCampos()
        {
            txtId.Text = "";
            txtFilme.Text = "";
            txtDiretor.Text = "";
            txtId.Focus();
        }

        private bool Validacao()
        {
            var FormOk = true;

            if (txtId.Text == "")
                FormOk = false;
            else if (txtFilme.Text == "")
                FormOk = false;
            else if (txtDiretor.Text == "")
                FormOk = false;
            else
                FormOk = true;

            return FormOk;
        }


    }
}
