using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restoreo.ViewModels
{
    internal class ResponseViewModel:ViewModelBase
    {
        private string text;
        private string img;
        public ResponseViewModel(string text, string img)
        {
            this.text = text;
            this.img = img;

            Close = new Command(ExecuteCloseCommand, CanExecuteCloseCommand);
        }



        public string Text
        {
            get { return text; }
        }

        public string Img
        {
            get { return img; }
        }

        public bool Colot
        {
            get
            {
                if (Img == "good")
                {
                    return true;
                }
                return false;
            }
        }

        #region Command
        public ICommand Close { get; }
        private bool CanExecuteCloseCommand(object arg)
        {
            return true;
        }

        private void ExecuteCloseCommand(object obj)
        {/////
            System.Windows.Application.Current.Windows[System.Windows.Application.Current.Windows.Count-1].Close();
        }

        #endregion
    }
}
