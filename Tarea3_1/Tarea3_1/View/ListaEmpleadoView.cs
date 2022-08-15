using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tarea3_1.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Tarea3_1.View
{
   public class ListaEmpleadoView: ModelV
    {
        private ObservableCollection<Empleados> empleados;

        public ObservableCollection<Empleados> Empleados
        {
            get { return empleados; }
            set { empleados = value; OnPropertyChanged(); }
        }

        private Empleados _selectedProduct;

        public Empleados SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }
        public ICommand DetalleLista { private set; get; }
        public INavigation Navigation { get; set; }

        public ListaEmpleadoView(INavigation navigation)
        {
            Navigation = navigation;
            DetalleLista = new Command<Type>(async (pageType) => await GoToDetails(pageType));

            carga();
        }
        public async void carga()
        {
            Empleados = new ObservableCollection<Empleados>();

            List<Empleados> empleado = new List<Empleados>();
            empleado = await App.BaseDatos.ObtenerListaEmpleados();

            for (int i = 0; i < empleado.Count; i++)
            {
                Empleados.Add(new Empleados() {foto=empleado[i].foto, id = empleado[i].id, nombre = empleado[i].nombre, apellido = empleado[i].apellido, edad = empleado[i].edad, 
                direccion = empleado[i].direccion, puesto = empleado[i].puesto });
            }
        }
        async Task GoToDetails(Type pageType)
        {
            if (SelectedProduct != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new Empleado()
                {
                    ID = SelectedProduct.id,
                    Nombre = SelectedProduct.nombre,
                    Apellido = SelectedProduct.apellido,
                    Edad = SelectedProduct.edad,
                    Direccion = SelectedProduct.direccion,
                    Puesto = SelectedProduct.puesto,
                    Foto = SelectedProduct.foto
                };

                await Navigation.PushAsync(page);
            }
        }
    }
}
