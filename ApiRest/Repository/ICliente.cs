namespace ApiRest.Repository
{
    using ApiRest.Models;
    using System.Collections.Generic;
    public interface ICliente
    {
        //Definicion de los metodos
        IEnumerable<ClienteT> GetAll();
        ClienteT GetById(int id);
        //ClienteT GetByName(string name);
        ClienteT Post(ClienteT item);
        bool Delete(int id);
        bool Put(int id, ClienteT item);
    }
}
