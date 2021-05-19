using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Merge
{
    class Group
    {
        IDirectoryConcrete _directory;

        public Group(
            IDirectoryConcrete directory )
        {
            this._directory = directory;
        }
        public IDirectoryConcrete Directory { get { return this._directory; } }
        public IFileConcrete Single
        {
            get
            {
                var q = this._directory.RetrieveAllFiles( "*.xml", System.IO.SearchOption.TopDirectoryOnly );

                return q.Single();
            }
        }
    }
}
