using System.Collections.Generic;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Contoso.Model.Common
{
    public class Table<TRow> : Table, ITable<TRow> where TRow : Element
    {
        public Table(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public Table(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public new IEnumerable<TRow> Rows => RowsAs<TRow>();
    }
}
