using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class SprintMatch
    {
        SprintHub _hub;
        BetMatch _match;

        IList<SprintVoter> _voters;

        HashSprintMatchRatios _ratios;

        public SprintMatch(
            SprintHub hub,
            BetMatch match)
        {
            this._hub = hub;
            this._match = match;

            this._voters = new List<SprintVoter>();

            this._ratios = new HashSprintMatchRatios();

            this.Parse();
        }
        void Parse()
        {
            foreach( var item in this._match.Voters )
            {
                var child = new SprintVoter( this, item );

                this._voters.Add( child );
            }
        }
        public SprintHub Hub { get { return this._hub; } }
        public BetMatch BetMatch { get { return this._match; } }
        public IEnumerable<SprintVoter> Voters { get { return this._voters; } }

        public Int32 CountHomeExperiences
        {
            get
            {
                return this._hub.Experiences.Count(
                    item => item.Experience.Experience.Concrete.HomeID == this._match.Match.Concrete.HomeID);
            }
        }
        public Int32 CountAwayExperiences
        {
            get
            {
                return this._hub.Experiences.Count(
                    item => item.Experience.Experience.Concrete.AwayID == this._match.Match.Concrete.AwayID);
            }
        }

        public Double AverageHomePrimaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.HomeID == this._match.Match.Concrete.HomeID);

                var count = q.Count(
                    item => item.Experience.SuccessPrimaryBet);

                return count * 1.0 / q.Count();
            }
        }
        public Double AverageModifyHomePrimaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.HomeID == this._match.Match.Concrete.HomeID);

                var count = q.Count(
                    item => item.Experience.SuccessPrimaryBet);

                return count * 1.0 / (q.Count() + 1);
            }
        }
        public Double AverageHomeSecondaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.HomeID == this._match.Match.Concrete.HomeID);

                var count = q.Count(
                    item => item.Experience.SuccessSecondaryBet);

                return count * 1.0 / q.Count();
            }
        }
        public Double AverageModifyHomeSecondaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.HomeID == this._match.Match.Concrete.HomeID);

                var count = q.Count(
                    item => item.Experience.SuccessSecondaryBet);

                return count * 1.0 / (q.Count() + 1);
            }
        }
        public Double AverageModifyTotalHome
        {
            get
            {
                return (this.AverageModifyHomePrimaryBet
                    + this.AverageModifyHomeSecondaryBet) / 2;
            }
        }


        public Double AverageAwayPrimaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.AwayID == this._match.Match.Concrete.AwayID);

                var count = q.Count(
                    item => item.Experience.SuccessPrimaryBet);

                return count * 1.0 / q.Count();
            }
        }
        public Double AverageModifyAwayPrimaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.AwayID == this._match.Match.Concrete.AwayID);

                var count = q.Count(
                    item => item.Experience.SuccessPrimaryBet);

                return count * 1.0 / (q.Count() + 1);
            }
        }
        public Double AverageAwaySecondaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.AwayID == this._match.Match.Concrete.AwayID);

                var count = q.Count(
                    item => item.Experience.SuccessSecondaryBet);

                return count * 1.0 / q.Count();
            }
        }
        public Double AverageModifyAwaySecondaryBet
        {
            get
            {
                var q = this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.AwayID == this._match.Match.Concrete.AwayID);

                var count = q.Count(
                    item => item.Experience.SuccessSecondaryBet);

                return count * 1.0 / (q.Count() + 1);
            }
        }
        public Double AverageModifyTotalAway
        {
            get
            {
                return (this.AverageModifyAwayPrimaryBet
                    + this.AverageModifyAwaySecondaryBet) / 2;
            }
        }
        public Double AverageModifyTotal
        {
            get
            {
                return (this.AverageModifyTotalHome
                    + this.AverageModifyTotalAway) / 2;
            }
        }
        public IEnumerable<SprintExperience> HomeExperiences
        {
            get
            {
                return this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.HomeID == this._match.Match.Concrete.HomeID); ;
            }
        }
        public IEnumerable<SprintExperience> AwayExperiences
        {
            get
            {
                return this._hub.Experiences.Where(
                    item => item.Experience.Experience.Concrete.AwayID == this._match.Match.Concrete.AwayID); ;
            }
        }

        #region Output

        public Double AverageOutputPrimaryBet
        {
            get
            {
                var count = this._match.Voters.Count(
                    item => item.OutputPrimaryBet);

                return count * 1.0 / this._match.Voters.Count();
            }
        }
        public Double AverageOutputSecondaryBet
        {
            get
            {
                var count = this._match.Voters.Count(
                    item => item.OutputSecondaryBet);

                return count * 1.0 / this._match.Voters.Count();
            }
        }
        public Double AverageOutput
        {
            get
            {
                return (this.AverageOutputPrimaryBet
                    + this.AverageOutputSecondaryBet)
                    / 2;

            }
        }

        #endregion

        #region DiffLossOutput

        public Double AverageDiffLossOutputPrimaryBet
        {
            get
            {
                var q = this._match.Voters.Where(
                    item => item.OutputPrimaryBet);

                var numerator = q.Sum(
                    item => item.Voter.DiffLoss);

                var denominator = this._match.Voters.Sum(
                    item => item.Voter.DiffLoss);

                return numerator / denominator;
            }
        }
        public Double AverageDiffLossOutputSecondaryBet
        {
            get
            {
                var q = this._match.Voters.Where(
                    item => item.OutputSecondaryBet);

                var numerator = q.Sum(
                    item => item.Voter.DiffLoss);

                var denominator = this._match.Voters.Sum(
                    item => item.Voter.DiffLoss);

                return numerator / denominator;
            }
        }
        public Double AverageDiffLossOutput
        {
            get
            {
                return (this.AverageDiffLossOutputPrimaryBet
                    + this.AverageDiffLossOutputSecondaryBet)
                    / 2;

            }
        }

        #endregion

        #region Effectiveness

        public Double AverageEffectivenessOutputPrimaryBet
        {
            get
            {
                var ratio = EnumSprintMatchRatios.AverageEffectivenessPowerLossOutputPrimaryBet;

                if (!this._ratios.Contains(ratio))
                {
                    // 1. Aqui ya tengo a todos los VOTER con OutputPrimaryBet en TRUE 
                    //    por lo que solo falta pregutnar por SuccessPrimaryBet

                    var q = this._voters.Where(
                    item => item.BetVoter.OutputPrimaryBet);

                    // 1. Aqui ya necesitamos Efecctiveness que es una propiedad de SprintVoterComingsoon

                    var numerator = q.Sum(
                        item => item.EffectivenessOutputPrimaryBetSuccessPrimaryBet);

                    var denominator = this._voters.Count();

                    var value = numerator / denominator;

                    this._ratios.Add( ratio, value );
                }
                
                return this._ratios [ratio];
            }
        }
        public Double AverageEffectivenessOutputSecondaryBet
        {
            get
            {
                var ratio = EnumSprintMatchRatios.AverageEffectivenessPowerLossOutputSecondaryBet;

                if (!this._ratios.Contains(ratio))
                {

                    var q = this._voters.Where(
                        item => item.BetVoter.OutputSecondaryBet);

                    var numerator = q.Sum(
                        item => item.EffectivenessOutputSecondaryBetSuccessSecondaryBet);

                    var denominator = this._voters.Count();

                    var value = numerator / denominator;

                    this._ratios.Add( ratio, value );
                }

                return this._ratios[ratio];
            }
        }

        public Double AverageEffectivenessOutput
        {
            get
            {
                return (this.AverageEffectivenessOutputPrimaryBet
                    + this.AverageEffectivenessOutputSecondaryBet) / 2;
            }
        }

        #endregion

        #region EffectivenessPowerLoss

        public Double AverageEffectivenessPowerLossOutputPrimaryBet
        {
            get
            {
                var ratio = EnumSprintMatchRatios.AverageEffectivenessPowerLossOutputPrimaryBet;

                if (!this._ratios.Contains(ratio))
                {
                    var q = this._voters.Where(
                        item => item.BetVoter.OutputPrimaryBet);

                    var numerator = q.Sum(
                        item => item.EffectivenessOutputPrimaryBetSuccessPrimaryBet * item.BetVoter.Voter.PowerLoss);

                    var denominator = this._voters.Count();

                    var value = numerator / denominator;

                    this._ratios.Add(ratio, value);
                }

                return this._ratios[ratio];
            }
        }
        public Double AverageEffectivenessPowerLossOutputSecondaryBet
        {
            get
            {
                var ratio = EnumSprintMatchRatios.AverageEffectivenessPowerLossOutputSecondaryBet;

                if (!this._ratios.Contains(ratio))
                {
                    var q = this._voters.Where(
                    item => item.BetVoter.OutputSecondaryBet);

                    var numerator = q.Sum(
                        item => item.EffectivenessOutputSecondaryBetSuccessSecondaryBet * item.BetVoter.Voter.PowerLoss);

                    var denominator = this._voters.Count();

                    var value = numerator / denominator;

                    this._ratios.Add( ratio, value );
                }

                return this._ratios[ratio];
            }
        }

        public Double AverageEffectivenessPowerLossOutput
        {
            get
            {
                return (this.AverageEffectivenessPowerLossOutputPrimaryBet
                    + this.AverageEffectivenessPowerLossOutputSecondaryBet) / 2;
            }
        }

        #endregion

        #region PowerLossOutput

        public Double AveragePowerLossOutputPrimaryBet
        {
            get
            {
                var q = this._match.Voters.Where(
                    item => item.OutputPrimaryBet);

                var numerator = q.Sum(
                    item => item.Voter.PowerLoss);

                var denominator = this._match.Voters.Count();

                return numerator / denominator;
            }
        }
        public Double AveragePowerLossOutputSecondaryBet
        {
            get
            {
                var q = this._match.Voters.Where(
                    item => item.OutputSecondaryBet);

                var numerator = q.Sum(
                    item => item.Voter.PowerLoss);

                var denominator = this._match.Voters.Count();

                return numerator / denominator;
            }
        }
        public Double AveragePowerLossOutput
        {
            get
            {
                return (this.AveragePowerLossOutputPrimaryBet
                    + this.AveragePowerLossOutputSecondaryBet)
                    / 2;

            }
        }

        #endregion


        public Double AverageHomeExperiencesTargetGoals
        {
            get
            {
                return this.HomeExperiences.Average(
                    item => item.Experience.Experience.HomeGoals);
            }
        }
        public Double AverageAwayExperiencesTargetGoals
        {
            get
            {
                return this.AwayExperiences.Average(
                    item => item.Experience.Experience.HomeGoals);
            }
        }

        public Double AverageHomeExperiencesFirstHalfHomeGoals
        {
            get
            {
                return this.HomeExperiences.Average(
                    item => item.Experience.Experience.Concrete.FirstHalfHomeGoals);
            }
        }
        public Double AverageAwayExperiencesFirstHalfHomeGoals
        {
            get
            {
                return this.AwayExperiences.Average(
                    item => item.Experience.Experience.Concrete.FirstHalfHomeGoals);
            }
        }
        public Double AverageHomeExperiencesFirstHalfAwayGoals
        {
            get
            {
                return this.HomeExperiences.Average(
                    item => item.Experience.Experience.Concrete.FirstHalfAwayGoals);
            }
        }
        public Double AverageAwayExperiencesFirstHalfAwayGoals
        {
            get
            {
                return this.AwayExperiences.Average(
                    item => item.Experience.Experience.Concrete.FirstHalfAwayGoals);
            }
        }

        public Double AverageHomeExperiencesSecondHalfHomeGoals
        {
            get
            {
                return this.HomeExperiences.Average(
                    item => item.Experience.Experience.Concrete.SecondHalfHomeGoals);
            }
        }
        public Double AverageAwayExperiencesSecondHalfHomeGoals
        {
            get
            {
                return this.AwayExperiences.Average(
                    item => item.Experience.Experience.Concrete.SecondHalfHomeGoals);
            }
        }
        public Double AverageHomeExperiencesSecondHalfAwayGoals
        {
            get
            {
                return this.HomeExperiences.Average(
                    item => item.Experience.Experience.Concrete.SecondHalfAwayGoals);
            }
        }
        public Double AverageAwayExperiencesSecondHalfAwayGoals
        {
            get
            {
                return this.AwayExperiences.Average(
                    item => item.Experience.Experience.Concrete.SecondHalfAwayGoals);
            }
        }
    }
}
