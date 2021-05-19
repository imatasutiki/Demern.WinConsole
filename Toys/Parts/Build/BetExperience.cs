using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class BetExperience
    {
        BetRepository _repository;
        Experience _experience;

        public BetExperience(
            BetRepository repository,
            Experience experience)
        {
            this._repository = repository;
            this._experience = experience;
        }
        public BetRepository Repository { get { return this._repository; } }
        public Experience Experience { get { return this._experience; } }

        public Boolean SuccessPrimaryBet
        {
            get
            {
                switch( this._repository.Tuple.PrimaryBet )
                {
                    case Bafang.Atoms.All.ModeBet.HomeGoals25Non:

                        return this._experience.HomeGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.HomeGoals05Yes:

                        return this._experience.HomeGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals25Non:

                        return this._experience.AwayGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals05Yes:

                        return this._experience.AwayGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals25Non:

                        return this._experience.FirstHalfGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals05Yes:

                        return this._experience.FirstHalfGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals25Non:

                        return this._experience.SecondHalfGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals05Yes:

                        return this._experience.SecondHalfGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals15Non:

                        return this._experience.Concrete.FirstHalfHomeGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals05Yes:

                        return this._experience.Concrete.FirstHalfHomeGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals15Non:

                        return this._experience.Concrete.SecondHalfHomeGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals05Yes:

                        return this._experience.Concrete.SecondHalfHomeGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals15Non:

                        return this._experience.Concrete.FirstHalfAwayGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals05Yes:

                        return this._experience.Concrete.FirstHalfAwayGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals15Non:

                        return this._experience.Concrete.SecondHalfAwayGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals05Yes:

                        return this._experience.Concrete.SecondHalfAwayGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.Goals35Non:

                        return this._experience.Goals < 3.5;

                    case Bafang.Atoms.All.ModeBet.Goals15Yes:

                        return this._experience.Goals > 1.5;

                    case Bafang.Atoms.All.ModeBet.DouWinHomeDraw:

                        return this._experience.HomeGoals >= this._experience.AwayGoals;

                    case Bafang.Atoms.All.ModeBet.DouWinAwayDraw:

                        return this._experience.AwayGoals >= this._experience.HomeGoals;

                    case Bafang.Atoms.All.ModeBet.DouFirstHalfWinHomeDraw:

                        return this._experience.Concrete.FirstHalfHomeGoals >= this._experience.Concrete.FirstHalfAwayGoals;

                    case Bafang.Atoms.All.ModeBet.DouFirstHalfWinAwayDraw:

                        return this._experience.Concrete.FirstHalfAwayGoals >= this._experience.Concrete.FirstHalfHomeGoals;

                    case Bafang.Atoms.All.ModeBet.DouSecondHalfWinHomeDraw:

                        return this._experience.Concrete.SecondHalfHomeGoals >= this._experience.Concrete.SecondHalfAwayGoals;

                    case Bafang.Atoms.All.ModeBet.DouSecondHalfWinAwayDraw:

                        return this._experience.Concrete.SecondHalfAwayGoals >= this._experience.Concrete.SecondHalfHomeGoals;

                    default:

                        var message = String.Format( "Bet: {0}", this._repository.Tuple.PrimaryBet );
                        throw new NotSupportedException( message );
                }
            }
        }
        public Boolean SuccessSecondaryBet
        {
            get
            {
                switch (this._repository.Tuple.SecondaryBet)
                {
                    case Bafang.Atoms.All.ModeBet.HomeGoals15Non:

                        return this._experience.HomeGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeGoals15Yes:

                        return this._experience.HomeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals15Non:

                        return this._experience.AwayGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals15Yes:

                        return this._experience.AwayGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals15Non:

                        return this._experience.FirstHalfGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals15Yes:

                        return this._experience.FirstHalfGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals15Non:

                        return this._experience.SecondHalfGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals15Yes:

                        return this._experience.SecondHalfGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals05Non:

                        return this._experience.Concrete.FirstHalfHomeGoals < 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals15Yes:

                        return this._experience.Concrete.FirstHalfHomeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals05Non:

                        return this._experience.Concrete.SecondHalfHomeGoals < 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals15Yes:

                        return this._experience.Concrete.SecondHalfHomeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals05Non:

                        return this._experience.Concrete.FirstHalfAwayGoals < 0.5;

                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals15Yes:

                        return this._experience.Concrete.FirstHalfAwayGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals05Non:

                        return this._experience.Concrete.SecondHalfAwayGoals < 0.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals15Yes:

                        return this._experience.Concrete.SecondHalfAwayGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.Goals25Non:

                        return this._experience.Goals < 2.5;

                    case Bafang.Atoms.All.ModeBet.Goals25Yes:

                        return this._experience.Goals > 2.5;

                    case Bafang.Atoms.All.ModeBet.FullWinHome:

                        return this._experience.HomeGoals > this._experience.AwayGoals;

                    case Bafang.Atoms.All.ModeBet.FullWinAway:

                        return this._experience.AwayGoals > this._experience.HomeGoals;

                    case Bafang.Atoms.All.ModeBet.FirstHalfWinHome:

                        return this._experience.Concrete.FirstHalfHomeGoals > this._experience.Concrete.FirstHalfAwayGoals;

                    case Bafang.Atoms.All.ModeBet.FirstHalfWinAway:

                        return this._experience.Concrete.FirstHalfAwayGoals > this._experience.Concrete.FirstHalfHomeGoals;

                    case Bafang.Atoms.All.ModeBet.SecondHalfWinHome:

                        return this._experience.Concrete.SecondHalfHomeGoals > this._experience.Concrete.SecondHalfAwayGoals;

                    case Bafang.Atoms.All.ModeBet.SecondHalfWinAway:

                        return this._experience.Concrete.SecondHalfAwayGoals > this._experience.Concrete.SecondHalfHomeGoals;
                        
                    default:

                        var message = String.Format("Bet: {0}", this._repository.Tuple.PrimaryBet);
                        throw new NotSupportedException(message);
                }
            }
        }
    }
}
