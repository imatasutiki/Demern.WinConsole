using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Merge
{
    class Repository
    {
        IDirectoryConcrete _directory;

        public Repository(
            IDirectoryConcrete directory )
        {
            this._directory = directory;
        }
        public IDirectoryConcrete Directory { get { return this._directory; } }
    }
}
