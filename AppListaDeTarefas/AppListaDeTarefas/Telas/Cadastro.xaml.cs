using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaDeTarefas.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }
        public void PrioridadeSelectAction(object sender,EventArgs args)
        {
            var Stacks = SLPrioridades.Children as List<StackLayout>;
            foreach (var Linha in Stacks)
            {
                Label lblPrioridade =  ((StackLayout)Linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }
            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
        }
    }
}