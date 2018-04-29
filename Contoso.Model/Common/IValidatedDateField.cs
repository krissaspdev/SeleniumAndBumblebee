using Bumblebee.Interfaces;

namespace Contoso.Model.Common
{
	public interface IValidatedDateField<out TResult> : IDateField<TResult> where TResult : IBlock
	{
		bool IsValid { get; }
	}
}