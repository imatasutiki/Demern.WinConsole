using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys
{
    class ToyTesting
    {
        Ambit _ambit;

        public ToyTesting(
            Ambit ambit )
        {
            this._ambit = ambit;
        }
        public void Play()
        {
            var sourcepath = @"C:\FILES\TEST\wangen\20210227160448\Merge\Merge20210225";
            var sourcedirectory = this._ambit.Urubamba.Atoms.OpenDirectory( sourcepath );

            var alldirectories = sourcedirectory.RetrieveAllDirectories();

            foreach( var item in alldirectories )
            {
                Console.WriteLine( item.Name );

                this.ProcessDirectory( item );
            }
        }
        void ProcessDirectory(
            IDirectoryConcrete directory )
        {
            var allfiles = directory.RetrieveAllFiles( "*.xml", System.IO.SearchOption.TopDirectoryOnly );

            foreach( var item in allfiles )
            {
                var schema = this._ambit.Demern.Atoms.OpenSchema( item );
            }
        }
    }
}
