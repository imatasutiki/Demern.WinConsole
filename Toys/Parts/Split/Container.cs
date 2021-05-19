using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Split
{
    class Container
    {
        ISchemaConcrete _schema;

        public Container(
            ISchemaConcrete schema )
        {
            this._schema = schema;
        }
        public ISchemaConcrete Schema { get { return this._schema; } }

        public Int32 Voters
        {
            get
            {
                return this._schema.Matches.First().Voters.Count();
            }
        }
        public Int32 Elements
        {
            get
            {
                return this._schema.Matches.Where(
                    item => !item.IsComingsoon).Count();
            }
        }
    }
}
