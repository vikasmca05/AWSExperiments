﻿using System;
namespace C360_Services_NewOrder.Models
{

		public class AppConfig
		{


			public string AwsRegion { get; set; }
			public string AwsAccessKey { get; set; }
			public string AwsSecretKey { get; set; }
			public string AwsQueueURL { get; set; }

			public int AwsQueueLongPollTimeSeconds { get; set; }
		}
	
}
