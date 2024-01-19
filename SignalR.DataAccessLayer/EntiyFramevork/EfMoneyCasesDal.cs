using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntiyFramevork
{
	public class EfMoneyCasesDal : GenericRepository<MoneyCase>, IMoneyCasesDal
	{
		public EfMoneyCasesDal(SignalRContext context) : base(context)
		{
		}

		public decimal TotalMoneyCasesAmount()
		{
			using var context = new SignalRContext();
			return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
		}
	}
}
