using FluentNHibernate.Mapping;

namespace DojoInterfaceApplication.Models
{
    public class VendaMap : ClassMap<VendaModel>
    {
        public VendaMap()
        {
            Id(x => x.idVenda).GeneratedBy.Identity();
            Map(x => x.Vendedor);
            Map(x => x.DataVenda);
            Map(x => x.Valor);
        }
    }
}