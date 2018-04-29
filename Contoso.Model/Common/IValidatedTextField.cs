using Bumblebee.Interfaces;

namespace Contoso.Model.Common
{
	public interface IValidatedTextField<out TResult> : ITextField<TResult> where TResult: IBlock
	{ 
		bool IsValid { get; }
	}
}