﻿using CrudCliente.Entidades;
using CrudCliente.Infra.Repositorio;
using CRUDCLiente.Infra.Repositorio;
using System;
using System.Collections.Generic;

namespace CrudCliente.Servico
{
    internal class ClienteService
    {
        private ClienteRepositorio _clienteRepositorio;

        public void Add(Cliente cliente)
        {
            if (!ValidarCliente(cliente))
            {
                Console.WriteLine("Erro ao adicionar cliente");
                return;
            }
            _clienteRepositorio = new ClienteRepositorio();
            _clienteRepositorio.Add(cliente);
            Console.WriteLine("Cliente inserido no sistema");
        }

        public List<Cliente> GetAll()
        {
            _clienteRepositorio = new ClienteRepositorio();
            Console.WriteLine("Lista de Clientes Ativos");
            return _clienteRepositorio.GetClientes();
        }

        public void EditarCliente(int clienteId, string novoNome, string novoEmail, DateTime novaDataNascimento)
        {
            _clienteRepositorio = new ClienteRepositorio();
            var cliente = _clienteRepositorio.GetClientes().FirstOrDefault(c => c.Id == clienteId);
            if (cliente != null)
            {
                cliente.Nome = novoNome;
                cliente.Email = novoEmail;
                cliente.DataNascimento = novaDataNascimento;
                _clienteRepositorio.Update(cliente);
                Console.WriteLine("Cliente atualizado com sucesso");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }

        public void DeleteClienteFisico(int clienteId)
        {
            _clienteRepositorio = new ClienteRepositorio();
            var cliente = _clienteRepositorio.GetClientes().FirstOrDefault(c => c.Id == clienteId);
            if (cliente != null)
            {
                _clienteRepositorio.DeleteFisico(cliente);
                Console.WriteLine("Cliente excluído com sucesso");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }

        private bool ValidarCliente(Cliente cliente)
        {
            if (cliente == null) return false;
            if (string.IsNullOrWhiteSpace(cliente.Nome) || string.IsNullOrWhiteSpace(cliente.Email) || cliente.DataNascimento == DateTime.MinValue) return false;
            return true;
        }
    }
}
