using CIandTAPI.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CIandTAPI.ViewModels
{
    [ImplementPropertyChanged]
    public class CadastrarViewModel
    {
        public CadastrarViewModel()
        {

        }

        public string title { get; set; }

        public string body { get; set; }

        public ICommand CadastrarCmd => new Command(async () =>
        {
            var novoPost = new Post();
            novoPost.title = title;
            novoPost.body = body;
            novoPost.userId = 1;

            var apiCall = new Utils.RestFullAcess<Post>();

            var exec = await apiCall.Post(novoPost, "http://jsonplaceholder.typicode.com/", "posts");
            if (exec) {
                (App.Current.MainPage).DisplayAlert("Sucesso", "Cadastro efetuado", "OK");
            } else
            {
                (App.Current.MainPage).DisplayAlert("Erro", "Faio", "Serio!?!?!?!?");
            }
        });
    }


}
