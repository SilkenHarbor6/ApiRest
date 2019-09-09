namespace ApiRest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ClienteT")]
    public partial class ClienteT
    {
        [Key]
        public int id_Cliente { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string apellido { get; set; }

        [StringLength(50)]
        public string direccion { get; set; }

        public DateTime? fecha_nacimiento { get; set; }

        [StringLength(8)]
        public string telefono { get; set; }

        [StringLength(100)]
        public string email { get; set; }
    }
}
