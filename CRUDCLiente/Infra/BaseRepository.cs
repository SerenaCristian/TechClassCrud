using System.Collections.Generic;
using CRUDCLiente.Dominio.Entidades;

namespace CRUDCLiente.Infra
{
    internal abstract class BaseRepository
    {

        public abstract void Add(Cliente cliente);
        public abstract void Update(Cliente cliente);
        public abstract void Delete(Cliente cliente);
        public abstract List<Cliente> ListarClientes();
    }
}
