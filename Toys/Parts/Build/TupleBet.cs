using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Bafang.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class TupleBet
    {
        ModeBet _primarybet;
        ModeBet _secondarybet;

        public TupleBet(
            ModeBet primarybet,
            ModeBet secondarybet )
        {
            this._primarybet = primarybet;
            this._secondarybet = secondarybet;
        }
        public ModeBet PrimaryBet { get { return this._primarybet; } }
        public ModeBet SecondaryBet { get { return this._secondarybet; } }
    }
}
