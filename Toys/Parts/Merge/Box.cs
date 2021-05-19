using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Merge
{
    class Box
    {
        Container _container;

        IMatchConcrete _match;

        public Box(
            Container container,
            IMatchConcrete match )
        {
            this._container = container;
            this._match = match;
        }
        public Container Container { get { return this._container; } }
        public IMatchConcrete Match { get { return this._match; } }
    }
}
