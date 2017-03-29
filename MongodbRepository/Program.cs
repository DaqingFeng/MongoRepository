using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
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

        }
    }
}
