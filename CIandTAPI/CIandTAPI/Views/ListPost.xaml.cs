using CIandTAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CIandTAPI.Views
{
    public partial class ListPost : ContentPage
    {
        public ListPost()
        {
            InitializeComponent();

            BindingContext = new LitPostViewModel();
        }
    }
}
