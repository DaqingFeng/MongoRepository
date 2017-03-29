using library;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class EventStoreRepository
    {
        IMongoRepository<EventHistory> Repository;

        public EventStoreRepository()
        {
            Repository = new MongoRepository<test.EventHistory>(MongoUtil<string>.GetDefaultConnectionString(), MongoDbMap.SerialEvents);

        }

        public void SaveEvent(EventHistory @event)
        {
            Repository.Add(@event);
        }

        public long Update(EventHistory @event, EventHistory target)
        {
            return Repository.Update(@event, target).ModifiedCount;
        }

        public async Task<List<EventHistory>> QueryEventHistoryByID(string ID)
        {
            return await Repository.Collection.Find(i => i.ID == ID).ToListAsync();
        }

        public async Task<EventHistory> QueryMaxEventHistoryByID(string ID)
        {
            var eventhist = await Repository.Collection.Find(item => item.ID == ID).ToListAsync();
            return eventhist.OrderBy(item => item.Version).LastOrDefault();
        }

        public long Delete(EventHistory t)
        {
            return Repository.Delete((i) => i.Version == t.Version && i.ID == t.ID);
        }
    }
}
