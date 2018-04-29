using System;

namespace Contoso.Tests
{
	public class Settings
	{
		private static readonly int _station = 7;
		private static readonly string _host = "10.0.0.122";

		private static readonly string _resetUrl = "api/reset";
		private static readonly string _protocol = "http";
		
		public static string HomeAddress => _protocol + "://" + _host + "/" + _station;

		public static string ResetAddress => HomeAddress + "/" + _resetUrl;

		public static TimeSpan Timeout => TimeSpan.FromSeconds(10);
	}
}