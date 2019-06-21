using System;
using System.Collections.Generic;
using System.Text;

namespace CarpoolApi.Domain.Enums
{
    public static class Enums
    {
        public enum Status
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2,
			Deleted = 3
        }
		public enum Action
		{
			Create = 0,
			Approve = 1,
			Reject = 2,
			Delete = 3
		}
	}
}
