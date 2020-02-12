using System.Collections.Generic;

namespace ERPForServiceActivity.Common {
	public class CommonConstants {
		public const int MinLengthServiceName = 3;
		public const string ErrorMessageWrongLength = "Enter at least 3 symbols";
		public const string ErrorMessageIncorrectLicense = "You entered incorrect license";
		public const string EnteredInvalidEmailAddress = "You entered wrong email address";

		public static List<string> Statuses = new List<string>() {
			"Created repair",
			"Only part ordered",
			"First Visit Arranged",
			"Customer request reschedule",
			"Customer cancel repair",
			"Received",
			"Repair at home",
			"Started repair",
			"Repair canceled – OOW (out of warranty)",
			"Offer to customer – OOW",
			"Part has been ordered",
			"Second Part has been ordered",
			"Parts received",
			"Part not available",
			"Waiting for credit note",
			"Repair completed",
			"Customer informed",
			"Awaiting payment",
			"Returned by courier",
			"Repair completed / Awaiting customer",
			"Transported to customer"
		};

		public static List<string> Checkups = new List<string>() {
			"Technician labor",
			"Service orders",
			"Labor OOW",
			"Used parts in repairs"
		};
	}
}