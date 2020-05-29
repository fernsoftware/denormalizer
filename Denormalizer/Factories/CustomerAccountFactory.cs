using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Denormalizer.Entities;

namespace Denormalizer.Factories
{
    public sealed class CustomerAccountFactory : ICustomerAccountFactory
    {
        public CustomerAccount Create(DbDataReader reader)
        {
            CustomerAccount entity = null;

            while (reader.Read())
            {
                entity = Read(reader);
            }

            return entity;
        }

        public IEnumerable<CustomerAccount> CreateMany(DbDataReader reader)
        {
            var entities = new List<CustomerAccount>();

            while (reader.Read())
            {
                entities.Add(Read(reader));
            }

            return entities;
        }

        private static CustomerAccount Read(IDataRecord data)
        {
            return new CustomerAccount
            {
                CUAccountID = int.Parse(data["CUAccountID"].ToString())
            };
        }
    }
}