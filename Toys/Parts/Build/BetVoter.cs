using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class BetVoter
    {
        BetMatch _match;
        Voter _voter;

        public BetVoter(
            BetMatch match,
            Voter voter)
        {
            this._match = match;
            this._voter = voter;
        }
        public Voter Voter { get { return this._voter; } }
        public Boolean OutputPrimaryBet
        {
            get
            {
                switch (this._match.Repository.Tuple.PrimaryBet)
                {
                    case Bafang.Atoms.All.ModeBet.HomeGoals25Non:

                        return this._voter.OutputHomeDecodeGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.HomeGoals05Yes:

                        return this._voter.OutputHomeDecodeGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals25Non:

                        return this._voter.OutputAwayDecodeGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals05Yes:

                        return this._voter.OutputAwayDecodeGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals25Non:

                        return this._voter.OutputFirstHalfDecodeGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals05Yes:

                        return this._voter.OutputFirstHalfDecodeGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals25Non:

                        return this._voter.OutputSecondHalfDecodeGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals05Yes:

                        return this._voter.OutputSecondHalfDecodeGoals > 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals15Non:

                        return this._voter.HomeFirst.Value < 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals05Yes:

                        return this._voter.HomeFirst.Value > 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals15Non:

                        return this._voter.HomeSecond.Value < 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals05Yes:

                        return this._voter.HomeSecond.Value > 0.5;

                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals15Non:

                        return this._voter.AwayFirst.Value < 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals05Yes:

                        return this._voter.AwayFirst.Value > 0.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals15Non:

                        return this._voter.AwaySecond.Value < 1.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals05Yes:

                        return this._voter.AwaySecond.Value > 0.5;

                    case Bafang.Atoms.All.ModeBet.Goals35Non:

                        return this._voter.OutputDecodeGoals < 3.5;

                    case Bafang.Atoms.All.ModeBet.Goals15Yes:

                        return this._voter.OutputDecodeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.DouWinHomeDraw:

                        return this._voter.OutputHomeDecodeGoals >= this._voter.OutputAwayDecodeGoals;

                    case Bafang.Atoms.All.ModeBet.DouWinAwayDraw:

                        return this._voter.OutputAwayDecodeGoals >= this._voter.OutputHomeDecodeGoals;

                    case Bafang.Atoms.All.ModeBet.DouFirstHalfWinHomeDraw:

                        return this._voter.HomeFirst.Value >= this._voter.AwayFirst.Value;

                    case Bafang.Atoms.All.ModeBet.DouFirstHalfWinAwayDraw:

                        return this._voter.AwayFirst.Value >= this._voter.AwaySecond.Value;

                    case Bafang.Atoms.All.ModeBet.DouSecondHalfWinHomeDraw:

                        return this._voter.HomeSecond.Value >= this._voter.AwaySecond.Value;

                    case Bafang.Atoms.All.ModeBet.DouSecondHalfWinAwayDraw:

                        return this._voter.AwaySecond.Value >= this._voter.HomeSecond.Value;

                    default:

                        var message = String.Format("Bet: {0}", this._match.Repository.Tuple.PrimaryBet);
                        throw new NotSupportedException(message);
                }
            }
        }
        public Boolean OutputSecondaryBet
        {
            get
            {
                switch (this._match.Repository.Tuple.SecondaryBet)
                {
                    case Bafang.Atoms.All.ModeBet.HomeGoals15Non:

                        return this._voter.OutputHomeDecodeGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeGoals15Yes:

                        return this._voter.OutputHomeDecodeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals15Non:

                        return this._voter.OutputAwayDecodeGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayGoals15Yes:

                        return this._voter.OutputAwayDecodeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals15Non:

                        return this._voter.OutputFirstHalfDecodeGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.FirstHalfGoals15Yes:

                        return this._voter.OutputFirstHalfDecodeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals15Non:

                        return this._voter.OutputSecondHalfDecodeGoals < 1.5;

                    case Bafang.Atoms.All.ModeBet.SecondHalfGoals15Yes:

                        return this._voter.OutputSecondHalfDecodeGoals > 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals05Non:

                        return this._voter.HomeFirst.Value < 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeFirstHalfGoals15Yes:

                        return this._voter.HomeFirst.Value > 1.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals05Non:

                        return this._voter.HomeSecond.Value < 0.5;

                    case Bafang.Atoms.All.ModeBet.HomeSecondHalfGoals15Yes:

                        return this._voter.HomeSecond.Value > 1.5;

                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals05Non:

                        return this._voter.AwayFirst.Value < 0.5;
                        
                    case Bafang.Atoms.All.ModeBet.AwayFirstHalfGoals15Yes:

                        return this._voter.AwayFirst.Value > 1.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals05Non:

                        return this._voter.AwaySecond.Value < 0.5;

                    case Bafang.Atoms.All.ModeBet.AwaySecondHalfGoals15Yes:

                        return this._voter.AwaySecond.Value > 1.5;

                    case Bafang.Atoms.All.ModeBet.Goals25Non:

                        return this._voter.OutputDecodeGoals < 2.5;

                    case Bafang.Atoms.All.ModeBet.Goals25Yes:

                        return this._voter.OutputDecodeGoals > 2.5;

                    case Bafang.Atoms.All.ModeBet.FullWinHome:

                        return this._voter.OutputHomeDecodeGoals > this._voter.OutputAwayDecodeGoals;

                    case Bafang.Atoms.All.ModeBet.FullWinAway:

                        return this._voter.OutputAwayDecodeGoals > this._voter.OutputHomeDecodeGoals;

                    case Bafang.Atoms.All.ModeBet.FirstHalfWinHome:

                        return this._voter.HomeFirst.Value > this._voter.AwayFirst.Value;

                    case Bafang.Atoms.All.ModeBet.FirstHalfWinAway:

                        return this._voter.AwayFirst.Value > this._voter.HomeFirst.Value;

                    case Bafang.Atoms.All.ModeBet.SecondHalfWinHome:

                        return this._voter.HomeSecond.Value > this._voter.AwaySecond.Value;

                    case Bafang.Atoms.All.ModeBet.SecondHalfWinAway:

                        return this._voter.AwaySecond.Value > this._voter.HomeSecond.Value;

                    default:

                        var message = String.Format("Bet: {0}", this._match.Repository.Tuple.PrimaryBet);
                        throw new NotSupportedException(message);
                }
            }
        }
    }
}
