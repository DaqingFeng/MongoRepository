# MongoRepository

1. The package using "mongocsharpdriver" . When using nuget to add this package. it will be automaticlly to add the other mongodb ferences.

2. The library achieve to mongodb persistent and query fondation.

3. The new repository it refer of RobThree 'https://github.com/RobThree/MongoRepository' . 

4. The sample like .
  
      
            
            EventStoreRepository store = new EventStoreRepository();
            EventHistory eventhis = new EventHistory();
            eventhis.ID = Guid.NewGuid().ToString();
            eventhis.Content = "Demo";
            eventhis.Version = 1;

            //Save
            store.SaveEvent(eventhis);

            //Get
            EventHistory goteventhis = store.QueryMaxEventHistoryByID(eventhis.ID).Result;

            EventHistory updatehis = new EventHistory();
            updatehis.Id = goteventhis.Id;
            updatehis.ID = goteventhis.ID;
            updatehis.Content = "Updated Demo";
            updatehis.Version = 2;

            //Update
           long updated= store.Update(goteventhis, updatehis);

           long deleteCount=  store.Delete(updatehis);

            //Get deleted
            EventHistory deletedeventhis = store.QueryMaxEventHistoryByID(eventhis.ID).Result;
