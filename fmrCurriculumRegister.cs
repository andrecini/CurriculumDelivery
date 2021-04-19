using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurriculumDelivery
{
    public partial class fmrCurriculumRegister : Form
    {
        public fmrCurriculumRegister()
        {
            InitializeComponent();
        }

        private void bbtBrowser_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            openFileDialog.InitialDirectory = @"C:\Users";
            //filtra para exibir somente arquivos de imagens
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ReadOnlyChecked = true;
            openFileDialog.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = openFileDialog.FileName;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Curriculum curriculum = new Curriculum();
            curriculum.Path = txtPath.Text;

            MessageBox.Show("O Arquivo foi salvo com sucesso!!!");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (VerifyTextBox())
                this.Close();
            else
                MessageBox.Show("ERRO: Todos os campos devem ser preenchidos!");
        }

        private bool VerifyTextBox()
        {
            if (txtPath.Text == string.Empty)
                return false;
            else
                return true;
        }
    }
}
