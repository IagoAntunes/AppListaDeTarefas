using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppListaDeTarefas.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }
        public void Finalizar(int Index,Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.RemoveAt(Index);
            tarefa.dataFinalizacao = DateTime.Now;
            Lista.Add(tarefa);

            salvarProperties(Lista);

        }
        public void Salvar(Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.Add(tarefa);
            salvarProperties(Lista);

        }
        public void Remover(int index)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);


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
            string JsonVal = JsonConvert.SerializeObject(Lista);

            App.Current.Properties.Add("Tarefas", JsonVal);
        }
        private List<Tarefa> ListagemNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                String JsonVal = (String)App.Current.Properties["Tarefas"];

                List<Tarefa> Lista = JsonConvert.DeserializeObject<List<Tarefa>>(JsonVal);

                return Lista;
            }
            return new List<Tarefa>();
        }

    }
}
