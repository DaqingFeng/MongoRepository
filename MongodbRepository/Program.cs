using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Program
    {
        public  void Main(string[] args)
        {
            EventStoreRepository store = new EventStoreRepository();

            EventHistory eventhis = new EventHistory();
            eventhis.ID = Guid.Parse("7c1dacc2-b429-4642-bba6-4e83ceb2a8bd");
            eventhis.Content = "Demo";
            eventhis.Version = 1;

            //Save
            //store.SaveEvent(eventhis);

            //Get
            EventHistory goteventhis = store.QueryMaxEventHistoryByID(eventhis.ID).Result;

            EventHistory updatehis = new EventHistory();
            updatehis.Id = goteventhis.Id;
            updatehis.ID = goteventhis.ID;
            updatehis.Content = "Updated Demo";
            updatehis.Version = 2;

            //Update
            long updated = store.Update(goteventhis, updatehis);

            //long deleteCount=  store.Delete(updatehis);

            //Get deleted
            EventHistory deletedeventhis = store.QueryMaxEventHistoryByID(eventhis.ID).Result;


            ProductRepository productrepository = new test.ProductRepository();
            ProductEntity product = new ProductEntity();
            product.ProductId = Guid.Parse("192b7207-359f-3d4f-86af-deeaf3fffced");
            product.ProductName = "上海仓Testing";
            //productrepository.SaveEvent(product);
 
            var rst = productrepository.QueryEventHistoryByID("上海",product.ProductId).Result;
        }
    }
}
