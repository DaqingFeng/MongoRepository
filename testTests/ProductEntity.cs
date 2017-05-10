using library;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    [Serializable]
    [CollectionName("Product")]
    public class ProductEntity : MongoEntity
    {
     
 
        /// <summary>
        /// 原料id
        /// </summary>
        public Guid ProductId { get; set; }
      


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

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }

}
