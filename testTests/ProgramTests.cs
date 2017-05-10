using Microsoft.VisualStudio.TestTools.UnitTesting;
using test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
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
            product.ProductId = Guid.Parse("06d3ae6a-8b7a-4688-814f-571d3369ea65");

            product.ProductName = "上海仓";
           //productrepository.SaveEvent(product);

            var newrst = productrepository.QueryByFilter(0, 10, p => p.ProductId == product.ProductId).Result;

           // productrepository.SaveProduct(product);

            var rst = productrepository.QueryEventHistoryByID("上海", product.ProductId);


            var aa = productrepository.QueryByFilter(0, 10, p => p.ProductName.Contains("新疆特级阿克苏苹果")).Result;
        }
    }
}