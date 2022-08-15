using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Tarea3_1.View;
using System.Windows.Input;
using Plugin.Media;
using System.IO;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;
using Tarea3_1.Models;
using Xamarin.Essentials;

namespace Tarea3_1.View
{
   public class Empleado : ModelV
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _edad;
        private string _direccion;
        private string _puesto;
        private string _foto;
        Image imagen;
        private string opcion;
        private bool _IsImageDefault;
        private bool _IsImageEdit;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(); }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }

        public string Edad
        {
            get { return _edad; }
            set { _edad = value; OnPropertyChanged(); }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChanged(); }
        }

        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; OnPropertyChanged(); }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        public string Foto
        {
            get { return _foto; }
            set { _foto = value; OnPropertyChanged(); }
        }
        public bool IsImageDefault
        {
            get { return _IsImageDefault; }
            set
            {
                _IsImageDefault = value;
                OnPropertyChanged();
            }
        }

        public bool IsImageEdit
        {
            get { return _IsImageEdit; }
            set
            {
                _IsImageEdit = value;
                OnPropertyChanged();
            }
        }

        //Comandos
        public ICommand Lista { get; set; }
        public ICommand Guardar { get; set; }
        public ICommand Actualizar { get; set; }
        public ICommand Eliminar { get; set; }
        public ICommand EliminarR { get; set; }
        public ICommand TomaFoto { get; set; }
        public async void lista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListaEmpleado());
        }


        public Empleado(Image img, string OpcionR)
        {
            imagen = img;
           // Models = Emplead;
            opcion = OpcionR;

            if (opcion.Equals("Actualizar"))
            {
                IsImageDefault = false;
                IsImageEdit = true;
            }
            else
            {
                IsImageDefault = true;
                IsImageEdit = false;
            }

            TomaFoto = new Command(async () => await TomarFoto());
            Guardar = new Command(() => Gemple());
            Lista = new Command(() => lista());
        }

        

        public async void actualiza()
        {
                if (String.IsNullOrEmpty(Nombre))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Completar campo NOMBRE", "Salir");
                }
                else if (String.IsNullOrEmpty(Apellido))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Completar campo APELLIDO", "Salir");
                }
                else if (String.IsNullOrEmpty(Edad))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Completar campo EDAD", "Salir");
                }
                else if (String.IsNullOrEmpty(Direccion))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Completar campo DIRECCION", "Salir");
                }
                else if (String.IsNullOrEmpty(Puesto))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Completar campo PUESTO", "Salir");
                }
            else
                {
                    var emp = new Models.Empleados
                    {
                        id = ID,
                        nombre = Nombre,
                        apellido = Apellido,
                        edad = Edad,
                        direccion = Direccion,
                        puesto = Puesto,
                        foto=Foto
                    };

                    var resultado = await App.BaseDatos.AggEmpleado(emp);

                    if (resultado == 1)
                    {
                        await Application.Current.MainPage.DisplayAlert("Advertencia", "Empleado Actualizado", "Salir");

                        await Application.Current.MainPage.Navigation.PushAsync(new ListaEmpleado());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Advertencia", "No se pudo Actualizar el Empleado", "Salir");
                    }
                }
            }

        public async void EliminarC()
        {
            eliminardatos();
        }

        void eliminardatos()
        {
            Nombre = String.Empty;
            Apellido = String.Empty;
            Edad = String.Empty;
            Direccion = String.Empty;
            Puesto = String.Empty;
            Foto = String.Empty;
        }
        public async void elimina()
        {
            var emple = new Models.Empleados
            {
                id = ID,
                nombre = Nombre,
                apellido = Apellido,
                edad = Edad,
                direccion = Direccion,
                puesto = Puesto,
                foto= Foto
            };

            var resultado = await App.BaseDatos.EliminarEmpleado(emple);

            if (resultado == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "Empleado Eliminado", "Salir");

                await Application.Current.MainPage.Navigation.PushAsync(new ListaEmpleado());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "NO se elimino el Empleado", "Salir");
            }
        }

        public async void Gemple()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Completar campo NOMBRE", "Salir");
            }
            else if (String.IsNullOrEmpty(Apellido))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Completar campo APELLIDO", "Salir");
            }
            else if (String.IsNullOrEmpty(Edad))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Completar campo EDAD", "Salir");
            }
            else if (String.IsNullOrEmpty(Direccion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Completar campo DIRECCION", "Salir");
            }
            else if (String.IsNullOrEmpty(Puesto))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Completar campo PUESTO", "Salir");
            }
            else if (String.IsNullOrEmpty(Foto))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Completar campo FOTO", "Salir");
            }
            else
            {
                var emp = new Models.Empleados
                {
                    nombre = Nombre,
                    apellido = Apellido,
                    edad = Edad,
                    direccion = Direccion,
                    puesto = Puesto,
                    foto=Foto
                };

                var resultado = await App.BaseDatos.AggEmpleado(emp);

                if (resultado == 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Mensaje", "Empleado Guardado", "Cerrar");
                    Nombre = String.Empty;
                    Edad = String.Empty;
                    Apellido = String.Empty;
                    Direccion = String.Empty;
                    Puesto = String.Empty;
                    Foto = String.Empty;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se Pudo Guardar el Empleado", "Cerrar");

                }
            }
        }
        public Empleado ()
        {
            Lista = new Command(() => lista());
            Guardar = new Command(() => Gemple());
            Actualizar = new Command(() => actualiza());
            Eliminar = new Command(() => elimina());
            EliminarR = new Command(() => EliminarC());
            TomaFoto= new Command(() => TomarFoto());
        }

        ///Sobre CAMARA
        private async Task TomarFoto()
        {
            bool opcion = await Application.Current.MainPage.DisplayAlert("Aviso", "Seleccione Opción", "Galeria", "Camara");

            if (opcion)
                GetImageFromGallery();
            else
                GetImageFromCamera();
        }

        private async void GetImageFromGallery()
        {
            try
            {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                    {
                        PhotoSize = PhotoSize.Medium,
                    });

                    if (file == null)
                        return;

                    imagen.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                    byte[] byteArray = File.ReadAllBytes(file.Path);
                    Foto = System.Convert.ToBase64String(byteArray);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "Error al seleccionar Imagen.", "Ok");
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "Error al seleccionar Imagen.", "Ok");
            }

        }

        private async void GetImageFromCamera()
        {
            try
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                });

                if (file == null)
                    return;

                imagen.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                byte[] byteArray = File.ReadAllBytes(file.Path);
                Foto = System.Convert.ToBase64String(byteArray);
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "Error al Tomar la Totografia.", "Ok");
            }
        }
    }


}
