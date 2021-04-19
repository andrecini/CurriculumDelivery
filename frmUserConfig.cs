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

namespace CurriculumDelivery
{
    public partial class frmUserConfig : Form
    {
        
        public frmUserConfig()
        {
            InitializeComponent();

            User user = User.GetInstance();

            Criptografia crypt = new Criptografia();

            if (File.Exists("UserAccount.txt"))
            {
                txtName.Text = user.Name;
                txtEmail.Text = user.Email;
                txtPassword.Text = crypt.Decrypt(user.Password);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                User user = User.GetInstance();

                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;

                string txtContent = string.Format("name: {0};\nemail: {1};\npassword: {2};", user.Name, user.Email, user.Password);

                File.WriteAllText("UserAccount.txt", txtContent);

                MessageBox.Show("Dados salvos com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (VerifyTextBox())
                this.Close();
            else
                MessageBox.Show("ERRO: Todos os campos devem ser preenchidos!");
        }

        private void btnView_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.Parse("\u0000");
        }

        private void btnView_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.Parse("*");
        }

        private bool VerifyTextBox()
        {
            if (txtName.Text == string.Empty)
                return false;
            if (txtEmail.Text == string.Empty)
                return false;
            if (txtPassword.Text == string.Empty)
                return false;
            else
                return true;
        }
    }
}
