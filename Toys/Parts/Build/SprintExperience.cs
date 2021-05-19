using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class SprintExperience
    {
        SprintHub _hub;
        BetExperience _experience;

        public SprintExperience(
            SprintHub hub,
            BetExperience experience)
        {
            this._hub = hub;
            this._experience = experience;
        }
        public SprintHub Hub { get { return this._hub; } }
        public BetExperience Experience { get { return this._experience; } }
    }
}
