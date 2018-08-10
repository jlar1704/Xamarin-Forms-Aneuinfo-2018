using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContarBotonPresionado
{
    public partial class MainPage : ContentPage
    {
        int Presionado = 0;

        public MainPage()
        {
            InitializeComponent();

        }

        void PresionameEvento(object sender, System.EventArgs e)
        {
            Presionado++;
            Label1.Rotation += 30;

           if (Presionado==1){
                Label1.Text = Nombre.Text + " Me ha presionado " + Presionado.ToString();
            }
            else 
                if (Presionado<3){
                    Label1.Text = Nombre.Text + " Me ha presionado " + Presionado.ToString() + " Veces! Creo que es Suficiente!"; 
                }
                else{
                DisplayAlert("Mensaje del Label", "Me estas enojando! el dia " + Fecha.Date.ToString() + " me has presionado " + Presionado.ToString(), "OK");
                    Label1.Text = Nombre.Text + " Van " + Presionado.ToString() + " Presiones! Estoy muy presionado! ya me estas cansando!";   
                }
        }

        void CambiandoTamano(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            Label1.FontSize = e.NewValue;
        }
    }
}
