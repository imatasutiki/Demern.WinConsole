using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Selector
    {
        Int32 _index;
        String _name;

        Func<SprintMatch, Double> _orderby;

        public Selector(
            Int32 index,
            String name,
            Func<SprintMatch, Double> orderby )
        {
            this._index = index;
            this._name = name;

            this._orderby = orderby;
        }
        public Int32 Index { get { return this._index; } }
        public String Name { get { return this._name; } }

        public Func<SprintMatch, Double> OrderBy { get { return this._orderby; } }
    }
}
