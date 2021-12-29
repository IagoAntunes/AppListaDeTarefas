using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppListaDeTarefas.Modelos;

namespace AppListaDeTarefas.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }
        private byte Prioridade { get; set; }
        public void PrioridadeSelectAction(object sender,EventArgs args)
        {
            var Stacks = SLPrioridades.Children;
            foreach (var Linha in Stacks)
            {
                Label lblPrioridade =  ((StackLayout)Linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }
            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.White;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            string Prioridade = Source.File.ToString().Replace("Resources/p","").Replace(".png","");
         
            this.Prioridade = byte.Parse(Prioridade);

        }
        public void SalvarAction(object sender,EventArgs args)
        {
            bool ErroExiste = false;
            if (TxtNome.Text == null || TxtNome.Text.Trim().Length <= 0)
            {
                ErroExiste = true;
                DisplayAlert("Erro", "Tarefa não digitada", "Okay");
            }

            //Já, para a prioridade, 
            if (Prioridade <= 0)
            {
                ErroExiste = true;
                DisplayAlert("Erro", "Prioridade não escolhida", "Okay");
            }

            if (ErroExiste == false)
            {//Salva os dados
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = TxtNome.Text.Trim();
                tarefa.Prioridade = this.Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);

                //TxtNome.Text = new GerenciadorTarefa().Listagem().Count.ToString();

                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
    }
}