using CrudCliente.Controllers;
using CrudCliente.Enumeradores;
using CRUDCLiente.Controllers;
using System;

namespace CrudCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Opcao opcao = 0;
            do
            {
                Console.WriteLine("Escolha uma opção:\n" +
                    "1) Cadastrar cliente\n" +
                    "2) Listar todos\n" +
                    "3) Editar Cliente\n" +
                    "4) Apagar um Cliente");
                Menu menu = (Menu)Enum.Parse(typeof(Menu), Console.ReadLine());
                ClienteController clienteController = new ClienteController();

                switch (menu)
                {
                    case Menu.Adicionar:
                        {
                            Console.WriteLine("Insira o nome do cliente");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o e-mail do cliente");
                            string email = Console.ReadLine();
                            Console.WriteLine("Informar a data de nascimento");
                            DateTime nascimento = DateTime.Parse(Console.ReadLine());
                            clienteController.AddCliente(nome, email, nascimento);
                        }
                        break;
                    case Menu.ListarTodos:
                        {
                            var clientes = clienteController.GetClientes();
                            foreach (var cliente in clientes)
                            {
                                Console.WriteLine($"ID: {cliente.Id}");
                                Console.WriteLine($"Cliente: {cliente.Nome}");
                                Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToString("dd-MM-yyyy")}");
                                Console.WriteLine($"E-mail: {cliente.Email}");
                                Console.WriteLine();
                            }
                        }
                        break;
                    case Menu.EditarCliente:
                        {
                            Console.WriteLine("Informar o ID do cliente a ser editado");
                            int clienteId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insira o novo nome do cliente");
                            string novoNome = Console.ReadLine();
                            Console.WriteLine("Insira o novo e-mail do cliente");
                            string novoEmail = Console.ReadLine();
                            Console.WriteLine("Informe a nova data de nascimento");
                            DateTime novaDataNascimento = DateTime.Parse(Console.ReadLine());
                            clienteController.EditarCliente(clienteId, novoNome, novoEmail, novaDataNascimento);
                        }
                        break;
                    case Menu.DeletarClienteFisico:
                        {
                            Console.WriteLine("Informe o ID do cliente a ser excluído");
                            int clienteId = int.Parse(Console.ReadLine());
                            clienteController.DeleteClienteFisico(clienteId);
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Deseja realizar outra operação?\n1) Sim\n2) Não");
                opcao = (Opcao)Enum.Parse(typeof(Opcao), Console.ReadLine());
                Console.Clear();
            } while (opcao != Opcao.Nao);
        }
    }
}