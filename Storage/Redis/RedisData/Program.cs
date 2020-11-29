using System;
using ServiceStack.Redis;

namespace RedisData
{
    class Program
    {
        static string redisConnectionString = "Ii63U86qaJOPWEy+2e2Ixay8g1c9HthH52th7IpTR7A=@mynewredis.redis.cache.windows.net:6380?ssl=true";
        static void Main(string[] args)
        {
            bool transactionResult = false;

            using (RedisClient redisClient = new RedisClient(redisConnectionString))
            using (var transaction = redisClient.CreateTransaction())
            {
                //Add multiple operations to the transaction
                transaction.QueueCommand(c => c.Set("MyKey1", "MyValue3"));
                transaction.QueueCommand(c => c.Set("MyKey2", "MyValue4"));

                //Add an expiration time
                transaction.QueueCommand(c => ((RedisNativeClient)c).Expire("MyKey1", 15));
                transaction.QueueCommand(c => ((RedisNativeClient)c).Expire("MyKey2", 15));

                //Commit and get result of transaction
                transactionResult = transaction.Commit();
            }

            if (transactionResult)
            {
                Console.WriteLine("Transaction committed");
            }
            else
            {
                Console.WriteLine("Transaction failed to commit");
            }
        }
    }
}
