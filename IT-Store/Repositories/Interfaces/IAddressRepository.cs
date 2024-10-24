﻿using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
    public interface IAddressRepository:IRepository<Address>
    {
        public IEnumerable<Address> GetByUserId(int userId);
    }
}
