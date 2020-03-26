using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;

namespace C360_Services_NewOrder
{

    [DynamoDBTable("TransactionTable")]
    public class Order
    {
        [DynamoDBHashKey] //Partition key
        public string SerialNumber
        {
            get; set;
        }
        [DynamoDBRangeKey]
        public string OrderType
        {
            get; set;
        }
        [DynamoDBProperty]
        public string OrderStatus
        {
            get; set;
        }

    }
    public class TransactionsRecord
    {
        public AmazonDynamoDBClient client;
        public DynamoDBContext dbContext;

        string tableName = "TransactionTable";


        public TransactionsRecord(AWSCredentials awsCredentials)
        {
            try
            {
                client = new AmazonDynamoDBClient(awsCredentials);
                 dbContext = new DynamoDBContext(client);


            }
            catch (AmazonServiceException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public async Task InsertRecord<Order>(Order order)
        {
            await dbContext.SaveAsync<Order>(order);
        }

        public async Task DeleteRecord<Order>(Order order)
        {
            await dbContext.DeleteAsync<Order>(order);
        }

        public Order Load<Order>(Order keyValue)
        {
            return dbContext.LoadAsync<Order>(keyValue).Result;

        }

        public async Task<IList<Order>> GetRows<Order>(List<ScanCondition> scanConditions)
        {
            return await dbContext.ScanAsync<Order>(scanConditions).GetRemainingAsync();
        }

        public async Task<IList<Order>> GetRows<Order>(object keyValue, List<ScanCondition> scanConditions = null)
        {
            DynamoDBOperationConfig config = null;

            if (scanConditions != null && scanConditions.Count > 0)
            {
                config = new DynamoDBOperationConfig()
                {
                    QueryFilter = scanConditions
                };
            }
            return await dbContext.QueryAsync<Order>(keyValue, config).GetRemainingAsync();
        }

        public async Task<IList<Order>> GetAll<Order>()
        {
  
            List<ScanCondition> conditions = new List<ScanCondition>();
            return await dbContext.QueryAsync<Order>(conditions).GetRemainingAsync();
        }
    }
}
