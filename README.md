# AWSExperiments
Sample Order Application

Problem Statement - To process New Order for provisioing request. Decouple the new order creation from the order processing services.

Solution Approach - Create a docker contianer which produces New Order records to SQS standard queue. Microservice "New Proviosning Order" will read the records and update the entry in Dynamo DB table. Once data has been succesfullt entered then record will be deleted from SQS standard queue.

![alt text](https://github.com/vikasmca05/AWSExperiments/blob/master/C360-Services_NewOrder/SampleOrderApplication.png)


Technology Stack - 
 Messaging Platform - SQS
 Database - Dynamo DB Table
 Deployment - Docker based containers
 Platform - DotNet Core
 
Implementation Details - 

1. Run docker engine on your machine.
2. Create new SQS standard queue.
3. Create sample table in Dynamo DB with Partition Key and Sort Key.
4. Create sample DotNet Core application with Docker support to Produce New order messages and add it to SQS queue.
5. Create sample DotNet Core applicaiton with Docker support to read these New order messahes.
6. Enter the record in DynamoDB table.
7. Delete the record from SQS queue.




