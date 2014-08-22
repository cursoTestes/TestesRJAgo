using NHibernate;

namespace DojoInterfaceApplication.Models
{
    public class Contexto
    {
        public static ISessionFactory SessionFactory { get; set; }
    }
}