﻿using System;
using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;

namespace Hangfire.Mongo.StateHandlers
{
	public class ProcessingStateHandler : IStateHandler
	{
		public void Apply(ApplyStateContext context, IWriteOnlyTransaction transaction)
		{
			transaction.AddToSet("processing", context.JobId, JobHelper.ToTimestamp(DateTime.UtcNow));
		}

		public void Unapply(ApplyStateContext context, IWriteOnlyTransaction transaction)
		{
			transaction.RemoveFromSet("processing", context.JobId);
		}

		public string StateName
		{
			get { return ProcessingState.StateName; }
		}
	}
}