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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            User user = User.GetInstance();
            Criptografia crypt = new Criptografia();

            if(File.Exists("UserAccount.txt"))
            {
                string[] userData = File.ReadAllLines("UserAccount.txt");

                user.Name = userData[0].Substring(5, userData[0].Length - 6).Trim();
                user.Email = userData[1].Substring(6, userData[1].Length - 7).Trim();
                user.Password = crypt.Decrypt(userData[2].Substring(9, userData[2].Length - 10).Trim());
            }
            else
            {
                MessageBox.Show("Nenhum dado foi cadastrado. Você será redirecionado para a tela de cadastros.");
                frmUserConfig screen = new frmUserConfig();
                screen.ShowDialog();
            }

            if (File.Exists("PathShortcut.txt"))
            {
                string[] curriculumPath = File.ReadAllLines("PathShortcut.txt");
                Curriculum curriculum = Curriculum.GetInstance();
                curriculum.Path = string.Format(@"{0}", curriculumPath[0]);
            }
            else
            {
                MessageBox.Show("Nenhum Arquivo foi encontrado. Você será redirecionado para a tela de registro de Currículo.");
                fmrCurriculumRegister screen = new fmrCurriculumRegister();
                screen.ShowDialog();
            }
        }

        private void userPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserConfig screen = new frmUserConfig();
            screen.ShowDialog();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            User user = User.GetInstance();
            Criptografia crypt = new Criptografia();
            Curriculum curriculum = Curriculum.GetInstance();            

            Email.Send(user.Email, txtEmailDest.Text, user.Name, txtTargetName.Text, txtSubject.Text, txtBody.Text, crypt.Decrypt(user.Password), curriculum.Path);
        }

        private void curriculumFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
