using System.Collections.Generic;

namespace Contoso.Model.Common
{
    public interface ITable<out TRow>
    {
	    IEnumerable<TRow> Rows { get; }
    }
}