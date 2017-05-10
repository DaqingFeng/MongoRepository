using library;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test
{
    public class ProductRepository
    {
        public IMongoRepository<ProductEntity> Repository;

        public ProductRepository()
        {
            Repository = new MongoRepository<ProductEntity>(MongoUtil<string>.GetDefaultConnectionString());

        }

        public void SaveEvent(ProductEntity @event)
        {
            Repository.Add(@event);
        }

        public long Update(ProductEntity @event, ProductEntity target)
        {
            return Repository.Update(@event, target).ModifiedCount;
        }

        public Task<List<ProductEntity>> QueryEventHistoryByID(string WareHouse, Guid ID)
        {
            return Task.Run(() =>
            {
                MongoNormalOldRepository<ProductEntity> repository = new MongoNormalOldRepository<ProductEntity>();
                List<IMongoQuery> queryandlist = new List<IMongoQuery>();

                if (WareHouse != null)
                {
                    queryandlist.Add(Query<ProductEntity>.Matches(u => u.WarehouseName, BsonRegularExpression.Create(new Regex(WareHouse))));
                }
                if (ID != null)
                {
                    queryandlist.Add(Query<ProductEntity>.EQ<Guid>(u => u.ProductId, (Guid)ID));
                }

                List<ProductEntity> productlist = new List<ProductEntity>();

                var query = Query.And(queryandlist);
                var cursor = repository.Collection.FindAs<ProductEntity>(query);
                cursor.SetSortOrder(SortBy.Ascending("CreateTime"));
                cursor.SetSkip(6); //pageindex*pagesize
                cursor.SetLimit(3); //pagesize
                foreach (var task in cursor)
                {
                    productlist.Add(task);
                }
                return productlist;
            });
        }
    }
}
