using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea3_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaEmpleado : ContentPage
    {
       
        public ListaEmpleado()
        {
            InitializeComponent();
           BindingContext = new View.ListaEmpleadoView(Navigation);
        }
    }
}