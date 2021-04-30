using GestFrigo.Models.Global.Entities;
using System;
using System.Data;

namespace GestFrigo.Models.Global.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User()
            {
                Id = (int)dataRecord["Id"],
                LastName = (string)dataRecord["LastName"],
                FirstName = (string)dataRecord["FirstName"],
                Email = (string)dataRecord["Email"]
            };
        }

        internal static Product ToProduct(this IDataRecord dataRecord)
        {
            return new Product()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"],
                UserId = (int)dataRecord["UserId"]
            };
        }

        internal static Content ToContent(this IDataRecord dataRecord)
        {
            return new Content()
            {
                Id = (long)dataRecord["Id"],
                ProductId = (int)dataRecord["ProductId"],
                Name = (string)dataRecord["Name"],
                AddedDate = (DateTime)dataRecord["AddedDate"],
                ExpirationDate = (DateTime)dataRecord["ExpirationDate"],
                UserId = (int)dataRecord["UserId"]
            };
        }
    }
}
