using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Voter
    {
        Match _match;

        IVoterConcrete _concrete;

        Goals _homefirst;
        Goals _awayfirst;
        Goals _homesecond;
        Goals _awaysecond;

        public Voter(
            Match match,
            IVoterConcrete concrete)
        {
            this._match = match;
            this._concrete = concrete;

            this.Parse();
        }
        void Parse()
        {
            this.ParseOutputFirstHalfHomeDecodeGoals();
            this.ParseOutputFirstHalfAwayDecodeGoals();
            this.ParseOutputSecondHalfHomeDecodeGoals();
            this.ParseOutputSecondHalfAwayDecodeGoals();
        }

        internal Match Match { get { return this._match; } }

        public IVoterConcrete Concrete { get { return this._concrete; } }

        internal Goals HomeFirst { get { return this._homefirst; } }
        internal Goals AwayFirst { get { return this._awayfirst; } }
        internal Goals HomeSecond { get { return this._homesecond; } }
        internal Goals AwaySecond { get { return this._awaysecond; } }

        public Double DiffLoss { get { return this._match.Container.Play.Toy.Option.MaximumLoss - this._concrete.Loss; } }
        public Double PowerLoss { get { return 1.0 - this._concrete.Loss / this._match.Container.Play.Toy.Option.MaximumLoss; } }

        #region Goals
        

        public void ParseOutputFirstHalfHomeDecodeGoals()
        {
            var output = this._concrete.Output;

            if (output.Count() < 3)
            {
                var message = String.Format("Count: {0}", output.Count());
                throw new NotSupportedException(message);
            }

            if (this._match.Container.Play.Toy.Option.Reverse)
            {
                output = output.Reverse();
            }

            var values = output.Skip(0).Take(3);

            this._homefirst = new Goals( this, values );
        }

        public void ParseOutputFirstHalfAwayDecodeGoals()
        {
            var output = this._concrete.Output;

            if (output.Count() < 6)
            {
                var message = String.Format("Count: {0}", output.Count());
                throw new NotSupportedException(message);
            }

            if (this._match.Container.Play.Toy.Option.Reverse)
            {
                output = output.Reverse();
            }

            var values = output.Skip(3).Take(3);

            this._awayfirst = new Goals( this, values );
        }

        public void ParseOutputSecondHalfHomeDecodeGoals()
        {
            var output = this._concrete.Output;
            
            if (output.Count() < 9)
            {
                var message = String.Format("Count: {0}", output.Count());
                throw new NotSupportedException(message);
            }

            if (this._match.Container.Play.Toy.Option.Reverse)
            {
                output = output.Reverse();
            }

            var values = output.Skip(6).Take(3);

            this._homesecond = new Goals( this, values );
        }

        public void ParseOutputSecondHalfAwayDecodeGoals()
        {
            var output = this._concrete.Output;
            
            if (output.Count() < 12)
            {
                var message = String.Format("Count: {0}", output.Count());
                throw new NotSupportedException(message);
            }

            if (this._match.Container.Play.Toy.Option.Reverse)
            {
                output = output.Reverse();
            }

            var values = this._concrete.Output.Skip(9).Take(3);

            this._awaysecond = new Goals( this, output );
        }


        #endregion

        public Int32 OutputHomeDecodeGoals
        {
            get { return this._homefirst.Value + this._homesecond.Value; }
        }
        public Int32 OutputAwayDecodeGoals
        {
            get { return this._awayfirst.Value + this._awaysecond.Value; }
        }
        public Int32 OutputFirstHalfDecodeGoals
        {
            get { return this._homefirst.Value + this._awayfirst.Value; }
        }
        public Int32 OutputSecondHalfDecodeGoals
        {
            get { return this._homesecond.Value + this._awaysecond.Value; }
        }

        public Int32 OutputDecodeGoals
        {
            get { return this.OutputHomeDecodeGoals + this.OutputAwayDecodeGoals; }
        }
    }
}
