using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

using Nibiru.Pulan.Contracts.Atoms.All;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Merge
{
    class Play
    {
        ToyMerge _toy;

        public Play(
            ToyMerge toy)
        {
            this._toy = toy;
        }
        public void Start()
        {
            var allrepositories = new List<Repository>();

            foreach( var path in this._toy.Option.Paths )
            {
                Console.WriteLine( path );

                var directory = this._toy.Ambit.Urubamba.Atoms.OpenDirectory( path );

                var repository = new Repository( directory );

                allrepositories.Add( repository );
            }

            this.ProcessAllRepositories( allrepositories );
        }
        void ProcessAllRepositories(
            IEnumerable<Repository> allrepositories)
        {
            var first = allrepositories.First();

            var alldirectories = first.Directory.RetrieveAllDirectories();

            var i = 0;
            var count = alldirectories.Count();

            foreach( var directory in alldirectories )
            {
                Console.WriteLine( "{0} / {1}", ++i, count );

                var group = new Group( directory );

                this.ProcessGroup(group, allrepositories);
            }

        }
        void ProcessGroup(
            Group pivot,
            IEnumerable<Repository> allrepositories )
        {
            var allcontainers = new List<Container>();

            foreach( var item in allrepositories )
            {
                var directory = item.Directory.RetrieveDirectory(pivot.Directory.Name);

                var group = new Group( directory );

                var schema = this._toy.Ambit.Demern.Atoms.OpenSchema( group.Single );

                var container = new Container( item, schema );

                allcontainers.Add( container );
            }
            
            this.WriteAllContainers( allcontainers, pivot );
        }
        void WriteAllContainers( 
            IEnumerable<Container> allcontainers,
            Group pivot )
        {
            this._toy.OptionDirectory.CreateDirectory(pivot.Directory.Name);
            var writerdirectory = this._toy.OptionDirectory.RetrieveDirectory(pivot.Directory.Name);

            var q = allcontainers.SelectMany(
                item => item.Boxes).GroupBy(
                item => item.Match.ID);

            var filename = String.Format(
                "{0}{1}",
                writerdirectory.Fullname,
                pivot.Single.Name);

            var writer = this._toy.Ambit.Pulan.Atoms.CreateWriter( filename );

            writer.WriteAttributeString( "Created", DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );

            var container = allcontainers.First();

            writer.WriteAttributeString("FutureDirectory", container.Schema.FutureDirectory );
            writer.WriteAttributeString("FutureFile", container.Schema.FutureFile );

            writer.WriteStartElement( "Matches" );

            foreach( var item in q )
            {
                writer.WriteStartElement( "Match" );

                writer.WriteAttributeString( "ID", item.Key.ToString() );

                var first = item.First();

                writer.WriteAttributeString("Kickoff", first.Match.Kickoff.ToString( "yyyy-MM-dd HH:mm:ss" ) );

                writer.WriteAttributeString("Nicename", first.Match.Nicename);

                writer.WriteAttributeString("HomeID", first.Match.HomeID.ToString() );
                writer.WriteAttributeString("HomeName", first.Match.HomeName);

                writer.WriteAttributeString("AwayID", first.Match.AwayID.ToString());
                writer.WriteAttributeString("AwayName", first.Match.AwayName);

                writer.WriteAttributeString("IsComingsoon", first.Match.IsComingsoon.ToString());

                writer.WriteAttributeString("FirstHalfHomeGoals", first.Match.FirstHalfHomeGoals.ToString());
                writer.WriteAttributeString("FirstHalfAwayGoals", first.Match.FirstHalfAwayGoals.ToString());

                writer.WriteAttributeString("SecondHalfHomeGoals", first.Match.SecondHalfHomeGoals.ToString());
                writer.WriteAttributeString("SecondHalfAwayGoals", first.Match.SecondHalfAwayGoals.ToString());

                this.WriteGrouping( item, writer );

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            if( this._toy.Option.IncludeExperiences )
            {
                writer.WriteStartElement("Experiences");

                this.WriteExepriences(allcontainers, writer);

                writer.WriteEndElement();
            }

            writer.Close();

            Console.WriteLine( filename );
        }
        void WriteExepriences(
            IEnumerable<Container> allcontainers,
            IWriterConcrete writer)
        {
            var q = allcontainers.First().Schema.Experiences;

            foreach( var item in q )
            {
                writer.WriteStartElement( "Experience" );

                writer.WriteAttributeString( "ID", item.ID.ToString() );

                writer.WriteAttributeString("Kickoff", item.Kickoff.ToString( "yyyy-MM-dd HH:mm:ss" ) );

                writer.WriteAttributeString("HomeID", item.HomeID.ToString());
                writer.WriteAttributeString("AwayID", item.AwayID.ToString());

                writer.WriteAttributeString("FirstHalfHomeGoals", item.FirstHalfHomeGoals.ToString());
                writer.WriteAttributeString("FirstHalfAwayGoals", item.FirstHalfAwayGoals.ToString());

                writer.WriteAttributeString("SecondHalfHomeGoals", item.SecondHalfHomeGoals.ToString());
                writer.WriteAttributeString("SecondHalfAwayGoals", item.SecondHalfAwayGoals.ToString());

                writer.WriteEndElement();
            }
        }
        void WriteGrouping(
            IGrouping<Int32, Box> grouping,
            IWriterConcrete writer)
        {
            writer.WriteStartElement( "Voters" );

            foreach( var item in grouping )
            {
                foreach( var voter in item.Match.Voters )
                {
                    writer.WriteStartElement( "Voter" );

                    writer.WriteAttributeString( "Epochs", voter.Epochs.ToString() );
                    writer.WriteAttributeString( "Loss", voter.Loss.ToString() );

                    var voterfile = voter.VoterFile + " " + item.Container.Repoitory.Directory.Fullname;

                    writer.WriteAttributeString("VoterFile", voterfile);

                    this.WriteVoter( voter, writer );

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
        }
        void WriteVoter(
            IVoterConcrete voter,
            IWriterConcrete writer )
        {
            writer.WriteStartElement( "Output" );

            foreach( var item in voter.Output )
            {
                writer.WriteStartElement( "Vector" );

                writer.WriteAttributeString( "Index", item.Index.ToString() );
                writer.WriteAttributeString( "Value", item.Value.ToString() );

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
