using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiRest.Models;

namespace ApiRest.Repository
{
    public class RCliente : ICliente
    {
        //Objeto de tipo Model1 para acceder a la DB
        private Model1 conn = new Model1();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var item = conn.ClienteT.Find(id);
            if (item==null)
            {
                return false;
            }
            conn.ClienteT.Remove(item);
            conn.SaveChanges();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClienteT> GetAll()
        {
            using (var db=new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.ClienteT.ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteT GetById(int id)
        {
            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.ClienteT.Find(id);
            }
        }

        //public ClienteT GetByName(string name)
        //{
        //    using(var db = new Model1())
        //    {
        //        db.Configuration.ProxyCreationEnabled = false;
        //        return db.ClienteT.Find(name);
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ClienteT Post(ClienteT item)
        {
            if (item==null)
            {
                return null;
            }
            try
            {
                conn.ClienteT.Add(item);
                conn.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Put(int id, ClienteT item)
        {
            var cliente = conn.ClienteT.Find(id);
            if (cliente == null)
            {
                return false;
            }
            cliente.nombre = item.nombre;
            cliente.apellido = item.apellido;
            cliente.telefono = item.telefono;
            cliente.direccion = item.direccion;
            cliente.fecha_nacimiento = item.fecha_nacimiento;
            cliente.email = item.email;
            conn.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            conn.SaveChanges();
            return true;
        }
    }
}