using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea3_1.Controller;
using System.IO;

namespace Tarea3_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        static DataBase basedatos;
        public static DataBase BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BaseDatos.db3"));
                }
                return basedatos;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
