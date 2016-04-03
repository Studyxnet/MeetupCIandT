using CIandTAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CIandTAPI.Views
{
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
            BindingContext = new CadastrarViewModel();
        }

        void openList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ListPost());
        }
    }
}
