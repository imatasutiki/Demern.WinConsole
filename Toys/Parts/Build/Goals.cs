using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Goals
    {
        Voter _voter;

        Byte _value;
        public Goals(
            Voter voter,
            IEnumerable<IOutputConcrete> output)
        {
            this._voter = voter;

            var boolvalues = output.Select(item => (item.Value > this._voter.Match.Container.Play.Toy.Option.MinimunPositive) ? true : false);

            if (!this._voter.Match.Container.Play.Toy.Option.Reverse)
            {
                boolvalues = boolvalues.Reverse();
            }

            this._value = voter.Match.Container.Play.Toy.Ambit.Binary.DecodeToByte(boolvalues);
        }
        public Byte Value { get { return this._value; } }
    }
}
