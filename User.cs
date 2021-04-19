using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumDelivery
{
    class User
    {
        #region Singleton
        private static int numberOfInstances = 0;
        private static User _instance;

        private void Singleton()
        { }

        public static User GetInstance()
        {
            if (_instance == null)
            {
                _instance = new User();
                numberOfInstances++;
            }

            return _instance;
        }
        #endregion

        private string name;
        private string email;
        private string password;

        private Criptografia cript = new Criptografia();

        public string Name
        {
            get => name;
            set
            {
                if (value is null || value == string.Empty)
                {
                    throw new Exception("ERRO: Campo 'Name' não foi preenchido corretamente.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if(value is null || value == string.Empty)
                {
                    throw new Exception("ERRO: Campo 'Email' não foi preenchido corretamente.");
                }
                else 
                {
                    email = value;
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (value is null || value == string.Empty)
                {
                    throw new Exception("ERRO: Campo User não foi preenchido corretamente.");
                }
                else if (value.Length < 8)
                {
                    throw new Exception("ERRO: A senha deve tem no mínimo 8 caracteres.");
                }
                else
                {
                    password = cript.Encrypt(value);
                }
            }
        }

    }
}
