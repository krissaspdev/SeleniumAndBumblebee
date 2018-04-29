using System;
using Bumblebee.Interfaces;

namespace Contoso.Tests.Tools
{
	public static class IDateFieldExtensions
	{
		public static DateTime DateTime(this IDateField field)
		{
			return System.DateTime.Parse(field.Text);
		}
	}
}