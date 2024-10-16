﻿using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface ICartRepository:IRepository<Cart>
	{
		public Cart GetCartByUserId(int userId);
	}
}
