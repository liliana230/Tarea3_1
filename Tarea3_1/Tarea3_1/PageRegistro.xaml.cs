using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Tarea3_1.View;

namespace Tarea3_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRegistro : ContentPage
    {
        public PageRegistro(string opcion ="Guardar")
        {
            InitializeComponent();

            if (opcion.Equals("Guardar"))
            {
               BindingContext = new Empleado(imagen, opcion);
            }
            else
            {
                BindingContext = new Empleado(imagen2, opcion);
            }
        }       
   }
}