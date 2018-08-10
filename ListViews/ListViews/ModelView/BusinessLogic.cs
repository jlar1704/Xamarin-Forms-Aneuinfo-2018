using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using  ListViews.ModelView;

namespace ListViews.ModelView
{
    public class BusinessLogic: BaseModel
    {
        private bool isrunning;
        private int NuevoEmp = 0;
        private ObservableCollection<Empleados> _empleado = new ObservableCollection<Empleados>(); 

       public BusinessLogic()
        {
            NuevoEmpleadoCommand = new Command(AgregarEmpleado);
            cargar();
        }

        public Command NuevoEmpleadoCommand { get; }
        public Command NavigateCommand { private set; get; }

        public void AgregarEmpleado(){
            NuevoEmp++;
            _empleado.Add(new Empleados()
            {
                Nombre = "Nuevo Empleado #" + NuevoEmp.ToString(),
                Profesion = "Chiripero",
                FechaNacimiento = DateTime.Now,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTm0jVBqYieUmni9QUvbh7wBn79dLEbKEli6RI2nTt1a6v1OiCj",
                Sueldo = 0
            });
        }

        public ObservableCollection<Empleados> GetEmpleados()
        {
            _empleado.Add(new Empleados()
            {
                Nombre = "Juan Luis Guerra",
                Profesion = "Cantante",
                FechaNacimiento = new DateTime(1957, 6, 7),
                Image = "https://i2.wp.com/apartadostereofm.com/wp-content/uploads/2017/06/Juan-Luis-Guerra.jpg?resize=350%2C350",
                Sueldo = 500000
            });

            _empleado.Add(new Empleados()
            {
                Nombre = "Pedro Martinez",
                Profesion = "Pelotero",
                FechaNacimiento = new DateTime(1971, 10, 25),
                Image = "https://c.o0bg.com/rf/image_960w/Boston/2011-2020/2015/07/22/BostonGlobe.com/Sports/Images/pedro_07_crop.jpg",
                Sueldo = 5000000
            });

            _empleado.Add(new Empleados()
            {
                Nombre = "Al Horford",
                Profesion = "Basketbolista",
                FechaNacimiento = new DateTime(1986, 6, 3),
                Image = "https://canchalatinablog.files.wordpress.com/2017/11/al_horford1.jpg",
                Sueldo = 3000000
            });

            return _empleado;
        }

       
    

        async void cargar(){
            IsRunning = true;
            await Task.Delay(3000);
            IsRunning = false;
        }

        public bool IsRunning
        {
            get { return isrunning; }
            set
            {
                isrunning = value;
                OnPropertyChanged(nameof(IsRunning));
                OnPropertyChanged(nameof(IsVisibleElements));
            }
        }

        public bool IsVisibleElements
        {
            get { return !isrunning; }
        }
       
    }
}
