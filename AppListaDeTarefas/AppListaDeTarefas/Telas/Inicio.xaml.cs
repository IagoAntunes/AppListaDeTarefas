using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppListaDeTarefas.Modelos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaDeTarefas.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + "," + DateTime.Now.ToString("dd/MM");
        }
        public void ActionGoCadastro(object sender,EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }
        public void LinhaStackLayout(Tarefa tarefa)
        {

            Label txtTarefa = new Label()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = tarefa.Nome
            };

            Image Check = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("CheckOff.png")
            };

            if(Device.RuntimePlatform == Device.UWP)
            {
                Check.Source = ImageSource.FromFile("Resources/CheckOff.png");
            }

            StackLayout linha = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15
            };

            linha.Children.Add(Check);


        }
    }
}