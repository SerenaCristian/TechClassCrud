﻿








using CrudCliente.Entidades;
using CrudCliente.Servico;
using System;
using System.Collections.Generic;

namespace CrudCliente.Controllers
{
    internal class ClienteController
    {
        private ClienteService _clienteService;

        public void AddCliente(string nome, string email, DateTime nascimento)
        {
            _clienteService = new ClienteService();
            Cliente cliente = new Cliente() { Nome = nome, Email = email, DataNascimento = nascimento };
            _clienteService.Add(cliente);
        }

        public List<Cliente> GetClientes()
        {
            _clienteService = new ClienteService();
            return _clienteService.GetAll();
        }

        public void EditarCliente(int clienteId, string novoNome, string novoEmail, DateTime novaDataNascimento)
        {
            _clienteService = new ClienteService();
            _clienteService.EditarCliente(clienteId, novoNome, novoEmail, novaDataNascimento);
        }

        public void DeleteClienteFisico(int clienteId)
        {
            _clienteService = new ClienteService();
            _clienteService.DeleteClienteFisico(clienteId);
        }
    }
}