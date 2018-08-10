using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContarClickDataBinding.MVVM
{
    public class FieldContector: INotifyPropertyChanged
    {
        int cantidad = 0;
        int rotationvalue = 0;
        bool presionado = false;

        public FieldContector()
        {
            PresionarBotonCommand = new Command(PresionarBoton);
        }

        public Command PresionarBotonCommand { get; }

        async void PresionarBoton(){
            Presionado = true;
            await Task.Delay(3000);
            Cantidad++;
            Presionado = false;
       }

        public bool Presionado
        {
            get { return presionado; }
            set { 
                  presionado = value; 
                  OnPropertyChanged(nameof(Presionado));
                 }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { 
                cantidad = value; 
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public int RotationValue{
            get { return rotationvalue; }
            set { 
                if (rotationvalue != value)
                {
                    rotationvalue = value;
                    OnPropertyChanged(nameof(RotationValue));
                }
            }
        }

        public string DisplayMessage
        {
            get { return $"Me has pesionado {cantidad} Veces"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
