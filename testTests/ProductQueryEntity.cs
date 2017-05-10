using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTests
{
    [Serializable]
    [CollectionName("Product")]
    public class ProductQueryEntity: MongoEntity
    {

        /// <summary>
        /// 原料名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 仓库id
        /// </summary>
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 业务编号
        /// </summary>
        public string BusinessCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }


        public Guid ProductId { get;   set; }
    }
}
