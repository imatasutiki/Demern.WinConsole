using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Match
    {
        Container _container;
        IMatchConcrete _concrete;

        IList<Voter> _voters;

        public Match(
            Container container,
            IMatchConcrete concrete )
        {
            this._container = container;
            this._concrete = concrete;

            this._voters = new List<Voter>();

            this.Parse();
        }
        void Parse()
        {
            var q = this._concrete.Voters.Where(
                item => item.Loss < this._container.Play.Toy.Option.MaximumLoss);

            foreach( var item in q )
            {
                var voter = new Voter( this, item );

                this._voters.Add( voter );
            }
        }
        public Container Container { get { return this._container; } }
        public IMatchConcrete Concrete { get { return this._concrete; } }
        public IEnumerable<Voter> Voters { get { return this._voters; } }
        public Double AverageLoss
        {
            get
            {
                return this._voters.Average(
                    item => item.Concrete.Loss);
            }
        }
        public Double AverageEpochs
        {
            get
            {
                return this._voters.Average(
                    item => item.Concrete.Epochs);
            }
        }
        public Double MaximumLoss
        {
            get
            {
                return this._voters.Max(
                    item => item.Concrete.Loss);
            }
        }
    }
}
