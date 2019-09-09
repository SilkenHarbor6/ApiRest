namespace ApiRest.Controllers
{
    using ApiRest.Models;
    using ApiRest.Repository;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class ClientesController : ApiController
    {
        //objeto de lectura para acceder al repositorio
        static readonly ICliente c = new RCliente();

        //Metodo Post
        public HttpResponseMessage Post(ClienteT item)
        {
            item = c.Post(item);
            if (item == null)
            {
                //Construyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable,"Los datos del cliente no pueden ser nulos");
            }
            return Request.CreateResponse(HttpStatusCode.Created,item);
        }
        //Metodo Get
        public HttpResponseMessage GetAll()
        {
            var items = c.GetAll();
            if (items == null)
            {
                //Construyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registros de cliente");
            }
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }
        //Metodo GetById
        public HttpResponseMessage GetById(int id)
        {
            ClienteT items = c.GetById(id);
            if (items == null)
            {
                //Construyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay ningun cliente con el id "+id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }
        ////Metodo GetByName
        //public HttpResponseMessage GetByName(string name)
        //{
        //    ClienteT items = c.GetByName(name);
        //    if (items == null)
        //    {
        //        //Construyendo respuesta del servidor
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay ningun cliente con el nombre "+name);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, items);
        //}
        //Metodo Delete
        public HttpResponseMessage Delete(int id)
        {
            var item = c.GetById(id);
            if (item == null)
            {
                //Construyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay ningun cliente con el id "+id+" para eliminar");
            }
            c.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "El registro ha sido eliminado");
        }
        //Metodo Put
        public HttpResponseMessage Put(int id,ClienteT cliente)
        {
            var item = c.GetById(id);
            if (item == null)
            {
                //Construyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay ningun cliente con el id "+id+" para actualizar");
            }
            var isPut = c.Put(id,cliente);
            if (!isPut)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, "No ha sido posible la actualizacion");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "El registro ha sido actualizado");
        }
    }
}
