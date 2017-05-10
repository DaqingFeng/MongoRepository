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
using testTests;

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

        public void SaveProduct(ProductEntity product)
        {
            MongoNormalOldRepository<ProductEntity> repository = new MongoNormalOldRepository<ProductEntity>();
            repository.Collection.Insert(product);
        }


        public List<ProductQueryEntity> QueryEventHistoryByID(String WareHouse, Guid ID)
        {
            MongoNormalOldRepository<ProductQueryEntity> repository = new MongoNormalOldRepository<ProductQueryEntity>();
            List<IMongoQuery> queryandlist = new List<IMongoQuery>();

            if (WareHouse != null)
            {
                //queryandlist.Add(Query<ProductEntity>.Matches(u => u.WarehouseName, BsonRegularExpression.Create(new Regex(WareHouse))));
            }
            if (ID != null)
            {
                queryandlist.Add(Query<ProductQueryEntity>.EQ<Guid>(u => u.ProductId, ID));
            }
            var itemFromDb = repository.Collection.FindOneAs<ProductQueryEntity>(Query.EQ("ProductId", ID));

            List<ProductQueryEntity> productlist = new List<ProductQueryEntity>();
            var query = Query.And(queryandlist);
            var cursor = repository.Collection.FindAs<ProductQueryEntity>(query);
            cursor.SetSortOrder(SortBy.Ascending("CreateTime"));
            cursor.SetSkip(0); //pageindex*pagesize
            cursor.SetLimit(10); //pagesize
            foreach (var task in cursor)
            {
                productlist.Add(task);
            }
            return productlist;
        }

        public Task<List<ProductEntity>> QueryByFilter(int pageIndex, int pageSize, Expression<Func<ProductEntity, bool>> filter)
        {
            return Task.Run(() =>
            {
                return Repository.Collection.AsQueryable().Where(filter).OrderBy(p => p.ProductName).Skip(pageIndex).Take(pageSize).ToList();

            });
        }
    }
}
