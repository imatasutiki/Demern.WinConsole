using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Bafang.Atoms.All;

using Nibiru.Urubamba.Contracts.Atoms.All;

using Nibiru.Pulan.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Play
    {
        ToyBuild _toy;

        public Play(
            ToyBuild toy )
        {
            this._toy = toy;
        }
        public ToyBuild Toy { get { return this._toy; } }
        public void Start()
        {
            this.WriteExecutes();

            Console.WriteLine( this._toy.Option.SourcePath );
            var sourcedirectory = this._toy.Ambit.Urubamba.Atoms.OpenDirectory( this._toy.Option.SourcePath );

            var alldirectories = sourcedirectory.RetrieveAllDirectories();

            var count = alldirectories.Count;
            var i = 0;
            
            foreach (var item in alldirectories)
            {
                Console.WriteLine( "{0} / {1}", ++i, count );

                this.ProcessDirectory( item );
            }
        }
        void ProcessDirectory(
            IDirectoryConcrete directory)
        {
            this._toy.OptionDirectory.CreateDirectory( directory.Name );
            var writerdirectory = this._toy.OptionDirectory.RetrieveDirectory( directory.Name );

            var allfiles = directory.RetrieveAllFiles( "*.xml", System.IO.SearchOption.TopDirectoryOnly );

            var single = allfiles.Single();

            var schema = this._toy.Ambit.Demern.Atoms.OpenSchema(single);

            var container = new Container(this, schema);
            
            var alltuples = this.RetrieveAllTuples();

            var allselectors = this.RetrieveAllSelectors();

            foreach (var tuple in alltuples)
            {
                var repository = new BetRepository(container, tuple);

                var scope = new Scope(this, repository);

                foreach( var item in allselectors )
                {
                    this.WriteScope(scope, item, writerdirectory);
                }
            }
        }
        IEnumerable<Selector> RetrieveAllSelectors()
        {
            var allselectors = new List<Selector>();

            var index = 1000;

            switch ( this._toy.Option.SelectorMode )
            {
                case "AverageOutput":

                    index = 2000;

                    allselectors.Add(
                        new Selector(++index,
                        "AverageOutput",
                        item => item.AverageOutput));

                    break;

                case "AverageDiffLossOutput":

                    index = 3000;

                    allselectors.Add(
                        new Selector(++index,
                        "AverageDiffLossOutput",
                        item => item.AverageDiffLossOutput));

                    break;

                case "AveragePowerLossOutput":

                    index = 4000;

                    allselectors.Add(
                        new Selector(++index,
                        "AveragePowerLossOutput",
                        item => item.AveragePowerLossOutput));

                    break;

                case "AverageEffectivenessOutput":

                    index = 5000;

                    allselectors.Add(
                        new Selector(++index,
                        "AverageEffectivenessOutput",
                        item => item.AverageEffectivenessOutput));

                    break;

                case "AverageEffectivenessOutputPrimaryBet":

                    index = 5100;

                    allselectors.Add(
                        new Selector(++index,
                        "AverageEffectivenessOutputPrimaryBet",
                        item => item.AverageEffectivenessPowerLossOutputPrimaryBet));

                    break;

                case "AverageEffectivenessPowerLossOutput":

                    index = 6000;

                    allselectors.Add(
                        new Selector(++index,
                        "AverageEffectivenessPowerLossOutput",
                        item => item.AverageEffectivenessPowerLossOutput));

                    break;

                case "AverageEffectivenessPowerLossOutputPrimaryBet":

                    index = 6100;

                    allselectors.Add(
                        new Selector(++index,
                        "AverageEffectivenessPowerLossOutputPrimaryBet",
                        item => item.AverageEffectivenessPowerLossOutputPrimaryBet));

                    break;

                default:

                    var message = String.Format( "SelectorMode: '{0}'", this._toy.Option.SelectorMode );
                    throw new NotSupportedException( message );
            }


            return allselectors;
            

            /*

            allselectors.Add(
                new Selector(++index,
                "AverageModifyTotalHome",
                item => item.AverageModifyTotalHome));

            allselectors.Add(
                new Selector(++index,
                "AverageModifyTotalAway",
                item => item.AverageModifyTotalAway));

            allselectors.Add(
                new Selector(++index,
                "AverageModifyTotal",
                item => item.AverageModifyTotal));

    */

            
        }
        IEnumerable<TupleBet> RetrieveAllTuples()
        {
            switch( this._toy.Option.GoalsMode )
            {
                case "HomeGoals":

                    return new List<TupleBet>
                    {
                        new TupleBet( ModeBet.HomeGoals05Yes, ModeBet.HomeGoals15Yes )
                    };

                case "AllGoals":

                    if( this._toy.Option.Sense == "Positive" )
                    {
                        return new List<TupleBet>()
                        {
                            new TupleBet( ModeBet.HomeGoals05Yes, ModeBet.HomeGoals15Yes ),

                            new TupleBet( ModeBet.AwayGoals05Yes, ModeBet.AwayGoals15Yes ),

                            new TupleBet( ModeBet.FirstHalfGoals05Yes, ModeBet.FirstHalfGoals15Yes ),

                            new TupleBet( ModeBet.SecondHalfGoals05Yes, ModeBet.SecondHalfGoals15Yes ),
                            
                            new TupleBet( ModeBet.Goals15Yes, ModeBet.Goals25Yes ),

                            /*
                            new TupleBet( ModeBet.DouWinHomeDraw, ModeBet.FullWinHome ),
                            new TupleBet( ModeBet.DouWinAwayDraw, ModeBet.FullWinAway ),

                            new TupleBet( ModeBet.DouFirstHalfWinHomeDraw, ModeBet.FirstHalfWinHome ),
                            new TupleBet( ModeBet.DouFirstHalfWinAwayDraw, ModeBet.FirstHalfWinAway ),

                            new TupleBet( ModeBet.DouSecondHalfWinHomeDraw, ModeBet.SecondHalfWinHome ),
                            new TupleBet( ModeBet.DouSecondHalfWinAwayDraw, ModeBet.SecondHalfWinAway ),
                            */
                        };
                    }
                    else if( this._toy.Option.Sense == "Negative" )
                    {
                        return new List<TupleBet>()
                        {
                            new TupleBet( ModeBet.HomeGoals25Non, ModeBet.HomeGoals15Non ),

                            new TupleBet( ModeBet.AwayGoals25Non, ModeBet.AwayGoals15Non ),

                            new TupleBet( ModeBet.FirstHalfGoals25Non, ModeBet.FirstHalfGoals15Non ),

                            new TupleBet( ModeBet.SecondHalfGoals25Non, ModeBet.SecondHalfGoals15Non ),

                            new TupleBet( ModeBet.HomeFirstHalfGoals15Non, ModeBet.HomeFirstHalfGoals05Non ),

                            new TupleBet( ModeBet.AwayFirstHalfGoals15Non, ModeBet.AwayFirstHalfGoals05Non ),

                            new TupleBet( ModeBet.HomeSecondHalfGoals15Non, ModeBet.HomeSecondHalfGoals05Non ),

                            new TupleBet( ModeBet.AwaySecondHalfGoals15Non, ModeBet.AwaySecondHalfGoals05Non ),

                            new TupleBet( ModeBet.Goals35Non, ModeBet.Goals25Non )
                        };
                    }
                    else
                    {
                        throw new NotSupportedException(String.Format("Sense: {0}", this._toy.Option.Sense) );
                    }

                default:

                    var message = String.Format( "GoalsMode: {0}", this._toy.Option.GoalsMode );
                    throw new NotSupportedException( message );
            }
        }
        void WriteScope(
            Scope scope,
            Selector selector,
            IDirectoryConcrete writerdirectory)
        {
            if( ! writerdirectory.HasDirectory( scope.Repository.Tuple.PrimaryBet.ToString() ) )
            {
                writerdirectory.CreateDirectory( scope.Repository.Tuple.PrimaryBet.ToString() );
            }

            var betdirectory = writerdirectory.RetrieveDirectory( scope.Repository.Tuple.PrimaryBet.ToString() );

            var filename = String.Format( "{0}{1}.xml", betdirectory.Fullname, selector.Index );

            var writer = this._toy.Ambit.Pulan.Atoms.CreateWriter( filename );

            writer.WriteAttributeString( "Created", DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );

            writer.WriteAttributeString( "SelectorIndex", selector.Index.ToString() );
            writer.WriteAttributeString( "SelectorName", selector.Name.ToString());

            writer.WriteAttributeString("SourcePath", this._toy.Option.SourcePath);
            writer.WriteAttributeString("Begin", this._toy.Option.Begin.ToString("yyyy-MM-dd HH:mm:ss"));
            writer.WriteAttributeString("End", this._toy.Option.End.ToString("yyyy-MM-dd HH:mm:ss"));
            writer.WriteAttributeString("SprintMode", this._toy.Option.SprintMode);
            writer.WriteAttributeString("TotalSprints", this._toy.Option.TotalSprints.ToString());

            writer.WriteAttributeString("MinimunPositive", this._toy.Option.MinimunPositive.ToString());

            writer.WriteAttributeString("MaximumLoss", this._toy.Option.MaximumLoss.ToString());
            writer.WriteAttributeString("SelectorMode", this._toy.Option.SelectorMode);

            writer.WriteAttributeString("Name", this._toy.Option.Name);
            writer.WriteAttributeString("Type", this._toy.Option.Type);
            
            var q = scope.Sprints.SelectMany(
                item => item.Comingsoon).OrderByDescending(
                selector.OrderBy);

            writer.WriteStartElement( "Matches" );

            var type = typeof(SprintMatch);
            var cache = new Cache( type );

            var ratioproperty = cache.Single( selector.Name );

            foreach( var item in q )
            {
                writer.WriteStartElement( "Match" );

                writer.WriteAttributeString( "ID", item.BetMatch.Match.Concrete.ID.ToString() );
                writer.WriteAttributeString( "Kickoff", item.BetMatch.Match.Concrete.Kickoff.ToString("yyyy-MM-dd HH:mm:ss"));

                writer.WriteAttributeString("Nicename", item.BetMatch.Match.Concrete.Nicename);

                writer.WriteAttributeString("HomeID", item.BetMatch.Match.Concrete.HomeID.ToString());
                writer.WriteAttributeString("HomeName", item.BetMatch.Match.Concrete.HomeName);

                writer.WriteAttributeString("AwayID", item.BetMatch.Match.Concrete.AwayID.ToString());
                writer.WriteAttributeString("AwayName", item.BetMatch.Match.Concrete.AwayName);

                writer.WriteAttributeString("Ratio", ratioproperty.GetValue( item, null ).ToString());

                writer.WriteAttributeString("AllVoters", item.BetMatch.Match.Concrete.Voters.Count().ToString());
                writer.WriteAttributeString("Voters", item.BetMatch.Voters.Count().ToString());
                writer.WriteAttributeString("MaximumLoss", item.BetMatch.Match.MaximumLoss.ToString());
                writer.WriteAttributeString("AverageLoss", item.BetMatch.Match.AverageLoss.ToString());
                writer.WriteAttributeString("AverageEpochs", item.BetMatch.Match.AverageEpochs.ToString());

                writer.WriteAttributeString("IsComingsoon", item.BetMatch.Match.Concrete.IsComingsoon.ToString());

                if( item.BetMatch.Match.Concrete.IsComingsoon )
                {
                    writer.WriteAttributeString("SuccessPrimaryBet", "None");
                    writer.WriteAttributeString("SuccessSecondaryBet", "None");
                }
                else
                {
                    writer.WriteAttributeString("SuccessPrimaryBet", item.BetMatch.SuccessPrimaryBet.ToString());
                    writer.WriteAttributeString("SuccessSecondaryBet", item.BetMatch.SuccessSecondaryBet.ToString());
                }

                writer.WriteAttributeString("AverageHomePrimaryBet", item.AverageHomePrimaryBet.ToString());
                writer.WriteAttributeString("AverageHomeSecondaryBet", item.AverageHomeSecondaryBet.ToString());

                writer.WriteAttributeString("AverageAwayPrimaryBet", item.AverageAwayPrimaryBet.ToString());
                writer.WriteAttributeString("AverageAwaySecondaryBet", item.AverageAwaySecondaryBet.ToString());

                writer.WriteAttributeString("AverageHomeExperiencesFirstHalfHomeGoals", item.AverageHomeExperiencesFirstHalfHomeGoals.ToString());
                writer.WriteAttributeString("AverageAwayExperiencesFirstHalfHomeGoals", item.AverageAwayExperiencesFirstHalfHomeGoals.ToString());

                writer.WriteAttributeString("AverageHomeExperiencesFirstHalfAwayGoals", item.AverageHomeExperiencesFirstHalfAwayGoals.ToString());
                writer.WriteAttributeString("AverageAwayExperiencesFirstHalfAwayGoals", item.AverageAwayExperiencesFirstHalfAwayGoals.ToString());

                writer.WriteAttributeString("AverageHomeExperiencesSecondHalfHomeGoals", item.AverageHomeExperiencesSecondHalfHomeGoals.ToString());
                writer.WriteAttributeString("AverageAwayExperiencesSecondHalfHomeGoals", item.AverageAwayExperiencesSecondHalfHomeGoals.ToString());

                writer.WriteAttributeString("AverageHomeExperiencesSecondHalfAwayGoals", item.AverageHomeExperiencesSecondHalfAwayGoals.ToString());
                writer.WriteAttributeString("AverageAwayExperiencesSecondHalfAwayGoals", item.AverageAwayExperiencesSecondHalfAwayGoals.ToString());

                writer.WriteAttributeString("CountHomeExperiences", item.CountHomeExperiences.ToString());
                writer.WriteAttributeString("CountAwayExperiences", item.CountAwayExperiences.ToString());

                if( this._toy.Option.WriteVoters )
                {
                    this.WriteVoters( item, writer);
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();

            Console.WriteLine( filename );
        }
        void WriteVoters(
            SprintMatch match,
            IWriterConcrete writer)
        {
            writer.WriteStartElement( "Voters" );

            foreach( var item in match.Voters )
            {
                writer.WriteStartElement( "Voter" );

                writer.WriteAttributeString("EffectivenessOutputPrimaryBetSuccessPrimaryBet", item.EffectivenessOutputPrimaryBetSuccessPrimaryBet.ToString());
                writer.WriteAttributeString("EffectivenessOutputSecondaryBetSuccessSecondaryBet", item.EffectivenessOutputSecondaryBetSuccessSecondaryBet.ToString());

                writer.WriteAttributeString("OutputPrimaryBet", item.BetVoter.OutputPrimaryBet.ToString() );
                writer.WriteAttributeString("OutputSecondaryBet", item.BetVoter.OutputSecondaryBet.ToString());

                writer.WriteAttributeString("PowerLoss", item.BetVoter.Voter.PowerLoss.ToString());
                writer.WriteAttributeString("Loss", item.BetVoter.Voter.Concrete.Loss.ToString());

                writer.WriteAttributeString("OutputFirstHalfHomeDecodeGoals", item.BetVoter.Voter.HomeFirst.Value.ToString());
                writer.WriteAttributeString("OutputFirstHalfAwayDecodeGoals", item.BetVoter.Voter.AwayFirst.Value.ToString());

                writer.WriteAttributeString("OutputSecondHalfHomeDecodeGoals", item.BetVoter.Voter.HomeSecond.Value.ToString());
                writer.WriteAttributeString("OutputSecondHalfAwayDecodeGoals", item.BetVoter.Voter.AwaySecond.Value.ToString());

                writer.WriteStartElement( "Output" );

                foreach( var output in item.BetVoter.Voter.Concrete.Output )
                {
                    writer.WriteStartElement( "Vector" );

                    writer.WriteAttributeString("Index", output.Index.ToString());
                    writer.WriteAttributeString("Value", output.Value.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        void WriteExecutes()
        {
            var filename = String.Format( "{0}Executes.xml", this._toy.OptionDirectory.Fullname );

            var writer = this._toy.Ambit.Pulan.Atoms.CreateWriter( filename );

            writer.WriteAttributeString( "Created", DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );

            writer.WriteStartElement("Executes");

            writer.WriteStartElement("Execute");

            writer.WriteAttributeString("Name", this._toy.Option.Execute.Name);
            writer.WriteAttributeString("Type", this._toy.Option.Execute.Type);

            writer.WriteStartElement("Parameters");

            foreach (var item in this._toy.Option.Execute.Parameters)
            {
                writer.WriteStartElement("Parameter");

                writer.WriteAttributeString("Name", item.Name);
                writer.WriteAttributeString("Value", item.Value);

                writer.WriteEndElement();
            }


            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.Close();

            Console.WriteLine( filename );
        }
    }
}
