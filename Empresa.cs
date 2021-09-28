using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace ConsoleApp1
{
    public class Empresa
    {
        List<Funcionario> funcionarios = new List<Funcionario>();
        List<Ponto> registros = new List<Ponto>();

        public void CadastrarFuncionario(string nome)
        {
            using (SqlConnection connection = new SqlConnection(Program.SqlCNN))
            {
                connection.Open();
                var sql = $"insert into Funcionarios(Nome) values(@nome);";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    command.ExecuteScalar();
                }

                connection.Close();
            }
                funcionarios.Add(new Funcionario() { Nome = nome, Id = funcionarios.Count + 1 });
            Funcionario funcionarioCadastrado = funcionarios[^1];
            Console.WriteLine($"Id: {funcionarioCadastrado.Id} Nome: {funcionarioCadastrado.Nome}");
        }

        public void ImprimirRelatorioFuncionario(int id)
        {
            var registrosFuncionario = from registro in registros
                                       where registro.Id == id 
                                       select registro;
            Console.WriteLine("Id funcionário - Entrada - Saída - Horas trabalhadas");
            foreach (Ponto ponto in registrosFuncionario.OrderBy(registro => registro.Entrada))
            {
                Console.WriteLine($"{ponto.Id} - {ponto.Entrada} - {ponto.Saida} - {ponto.TotalTrabalhado}");
            }
        }

        public void RegistrarPonto(int id, string data, string entrada, string saida)
        {
            Ponto ponto = new Ponto(id, data, entrada, saida);
            registros.Add(ponto);
            Console.WriteLine($"Id: {id} - {ponto.Entrada} - {ponto.Saida} - {ponto.TotalTrabalhado}");
        }
    }
}
