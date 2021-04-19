using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CurriculumDelivery
{
    class Curriculum
    {
        #region Singleton
        private static int numberOfInstances = 0;
        private static Curriculum _instance;

        private void Singleton()
        { }

        public static Curriculum GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Curriculum();
                numberOfInstances++;
            }

            return _instance;
        }
        #endregion

        private string path;

        public string Path
        {
            get => path;
            set
            {
                if (value is null || value == string.Empty)
                    throw new Exception("ERRO: É preciso selecionar o caminho do arquivo.");
                else 
                {
                    path = string.Format("{0}", value);
                    File.WriteAllText("PathShortcut.txt", value);
                }
            }
        }
    }
}
