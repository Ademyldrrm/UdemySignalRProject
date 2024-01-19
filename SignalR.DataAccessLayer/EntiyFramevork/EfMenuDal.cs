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
	public class EfMenuDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		public EfMenuDal(SignalRContext context) : base(context)
		{
		}

		public int MenuTableCount()
		{
			using var context=new SignalRContext();
			return context.MenuTables.Count();
		}
	}
}
