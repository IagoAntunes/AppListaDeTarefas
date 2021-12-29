using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaDeTarefas.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }
        public void Finalizar(int Index,Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.RemoveAt(Index);
            Lista.Add(tarefa);

            salvarProperties(Lista);

        }
        public void Salvar(Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.Add(tarefa);
            salvarProperties(Lista);

        }
        public void Remover(Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.Remove(tarefa);

            salvarProperties(Lista);

        }
        public List<Tarefa> Listagem()
        {

            return ListagemNoProperties();
        }
        private void salvarProperties(List<Tarefa> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");

            }
            App.Current.Properties.Add("Tarefas", Lista);
        }
        private List<Tarefa> ListagemNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                return (List<Tarefa>)App.Current.Properties["Tarefas"];

            }
            return new List<Tarefa>();
        }

    }
}
