using CIandTAPI.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CIandTAPI.ViewModels
{
    //[ImplementPropertyChanged]
    public class LitPostViewModel : INotifyPropertyChanged
    {
        public LitPostViewModel()
        {
            var apiCall = new Utils.RestFullAcess<List<Post>>();

            apiCall.Get("http://jsonplaceholder.typicode.com/",
                "posts",
                "").ContinueWith((t) =>
                {
                    if (t.IsCanceled) { }
                    else if (t.IsFaulted) { }
                    else if (t.IsCompleted)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Posts = t.Result;
                        });
                    }
                });
        }

        private List<Post> _posts;

        public List<Post> Posts
        {
            get
            {
                return _posts;
            }
            set
            {
                if (value != _posts)
                {
                    _posts = value;
                    OnChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged([CallerMemberName]string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
