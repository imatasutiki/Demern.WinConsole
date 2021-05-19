using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Toys.Atoms.All;

using Nibiru.Urubamba.Contracts.Atoms.All;

using Nibiru.Comalapa.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys
{
    class ToyBuild : ToyAbstract<Ambit>
    {
        IOptionBuildConcrete _option;
        IDirectoryConcrete _optiondirectory;

        public ToyBuild(
            Ambit ambit,
            IDirectoryConcrete directory ) : base( ambit, "Build", directory )
        {
            this._option = (IOptionBuildConcrete)this.Ambit.Menu.Selected;

            this.CurrentDirectory.CreateDirectory( this._option.Name );
            this._optiondirectory = this.CurrentDirectory.RetrieveDirectory( this._option.Name );
        }
        public IOptionBuildConcrete Option { get { return this._option; } }
        public IDirectoryConcrete OptionDirectory { get { return this._optiondirectory; } }
        protected override void innerPlay()
        {
            var play = new Parts.Build.Play( this );
            play.Start();
        }
    }
}
