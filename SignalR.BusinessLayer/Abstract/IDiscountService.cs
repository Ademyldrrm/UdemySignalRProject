using SignalR.EntityLayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService:IGenericService<Discount>
    {
        void TChanfeStatusToTrue(int id);
        void TChanfeStatusToFalse(int id);
        List<Discount> TGetListByStatusTrue();
    }
}
