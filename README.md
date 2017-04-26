# MongoRepository

1. The package using "mongocsharpdriver" . When using nuget to add this package. it will be automaticlly to add the other mongodb ferences.

2. The library achieve to mongodb persistent and query fondation.

3. The new repository it refer of RobThree 'https://github.com/RobThree/MongoRepository' . 

4. The sample like .
  
      
 ```c#
         
   public class EventStoreRepository
      {
        IMongoRepository<EventHistory> Repository;

        public EventStoreRepository()
        {
            Repository = new MongoRepository<test.EventHistory>(MongoUtil<string>
            .GetDefaultConnectionString(),MongoDbMap.SerialEvents);
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
```
