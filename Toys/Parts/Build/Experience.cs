using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Experience
    {
        Container _container;

        IExperienceConcrete _concrete;

        public Experience(
            Container container,
            IExperienceConcrete concrete )
        {
            this._container = container;
            this._concrete = concrete;
        }
        public IExperienceConcrete Concrete { get { return this._concrete; } }
        
        public Int32 HomeGoals
        {
            get
            {
                return this._concrete.FirstHalfHomeGoals + this._concrete.SecondHalfHomeGoals;
            }
        }
        public Int32 AwayGoals
        {
            get
            {
                return this._concrete.FirstHalfAwayGoals + this._concrete.SecondHalfAwayGoals;
            }
        }
        public Int32 FirstHalfGoals
        {
            get
            {
                return this._concrete.FirstHalfHomeGoals + this._concrete.FirstHalfAwayGoals;
            }
        }
        public Int32 SecondHalfGoals
        {
            get
            {
                return this._concrete.SecondHalfHomeGoals + this._concrete.SecondHalfAwayGoals;
            }
        }

        public Int32 Goals
        {
            get { return this.HomeGoals + this.AwayGoals; }
        }
    }
}
