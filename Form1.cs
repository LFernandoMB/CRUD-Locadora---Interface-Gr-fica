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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader csv = new StreamReader("BD.csv"))
            {
                string linha;
                string[] campo;

                while ((linha = csv.ReadLine()) != null)
                {
                    campo = linha.Split(';');
                    dataGridView1.Rows.Add(campo);
                }
            }
        }

       private void btnEditar_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();

            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value = Movie.Id;
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["FILME"].Value = Movie.Filme;
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["DIRETOR"].Value = Movie.Diretor;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Movie.Id = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
            Movie.Filme = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["FILME"].Value.ToString();
            Movie.Diretor = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["DIRETOR"].Value.ToString();
        }

        private void SalvarGrid()
        {
                using (StreamWriter csv = new StreamWriter("BD.csv"))
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        var linha = dataGridView1.Rows[i].Cells["ID"].Value + ";" +
                            dataGridView1.Rows[i].Cells["FILME"].Value + ";" +
                            dataGridView1.Rows[i].Cells["DIRETOR"].Value;

                        csv.WriteLine(linha);
                    }
                }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                MessageBox.Show("Não há linhas na grade");
            else if (MessageBox.Show("Deseja realmente excluir esse item?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            SalvarGrid();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarGrid();
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            Movie.Id = "";
            Form2 frm = new Form2();
            frm.ShowDialog();

            dataGridView1.Rows.Add(Movie.Id, Movie.Filme, Movie.Diretor);
        }
    }
}
