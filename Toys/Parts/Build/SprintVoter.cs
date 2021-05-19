using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class SprintVoter
    {
        SprintMatch _match;
        BetVoter _voter;

        public SprintVoter(
            SprintMatch match,
            BetVoter voter)
        {
            this._match = match;
            this._voter = voter;
        }

        public SprintMatch Match { get { return this._match; } }
        public BetVoter BetVoter { get { return this._voter; } }

        public Double EffectivenessOutputPrimaryBetSuccessPrimaryBet
        {
            get
            {
                // 1. ¿Se puede escribir esto de otra manera?

                /*
                var q = this._match.Hub.Matches.Where(
                    item => item.BetMatch.EffectivenessOutputPrimaryBetSuccessPrimaryBet(this.BetVoter));
                    */

                var q = this._match.Hub.Matches.Where(
                    item => item.BetMatch[this.BetVoter.Voter].OutputPrimaryBet
                        & item.BetMatch.SuccessPrimaryBet);

                /*
                var q = this.FriendParent.Hub.Matches.Where(
                    item => item.BetMatch.SuccessPrimaryBet
                        & this.BetVoter.OutputPrimaryBet);
                        */

                // 2. Ten encuenta que en SprintComingsoon ya se filtro por OutputPrimaryBet

                /*
                var q = this._match.Hub.Matches.Where(
                    item => item.BetMatch.SuccessPrimaryBet);
                    */

                return q.Count() * 1.0 / this._match.Hub.Matches.Count();
            }
        }
        public Double EffectivenessOutputSecondaryBetSuccessSecondaryBet
        {
            get
            {
                /*
                var q = this._match.Hub.Matches.Where(
                    item => item.BetMatch.EffectivenessOutputSecondaryBetSuccessSecondaryBet(this.BetVoter));
                    */

                var q = this._match.Hub.Matches.Where(
                    item => item.BetMatch[this.BetVoter.Voter].OutputSecondaryBet
                        & item.BetMatch.SuccessSecondaryBet);

                /*
                var q = this.FriendParent.Hub.Matches.Where(
                    item => item.BetMatch.SuccessPrimaryBet
                        & this.BetVoter.OutputPrimaryBet);
                        */

                /*
                var q = this._match.Hub.Matches.Where(
                    item => item.BetMatch.SuccessSecondaryBet);
                    */

                return q.Count() * 1.0 / this._match.Hub.Matches.Count();
            }
        }
    }
}
