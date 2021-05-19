using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

using Nibiru.Demern.Contracts.Atoms.All;

using Nibiru.Pulan.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Split
{
    class Play
    {
        ToySplit _toy;

        public Play(
            ToySplit toy )
        {
            this._toy = toy;
        }
        public void Start()
        {
            Console.WriteLine( this._toy.Option.SourcePath );

            var sourcedirectory = this._toy.Ambit.Urubamba.Atoms.OpenDirectory( this._toy.Option.SourcePath );
            
            var allfiles = sourcedirectory.RetrieveAllFiles( "*.xml", System.IO.SearchOption.AllDirectories );

            var allcontainers = new List<Container>();

            var i = 0;
            var count = allfiles.Count;

            foreach( var item in allfiles )
            {
                Console.WriteLine( "{0} / {1}", ++i, count );

                var schema = this._toy.Ambit.Demern.Atoms.OpenSchema( item );

                var container = new Container( schema );

                allcontainers.Add( container );
            }

            this.ProcessAllContainers( allcontainers );
        }
        void ProcessAllContainers(
            IEnumerable<Container> allcontainers )
        {
            for (var i = 0; i < this._toy.Option.MaximumPartitions; i++)
            {
                var name = String.Format( "{0}-{1}-{2}", 
                    this._toy.OptionDirectory.Name, 
                    i + 1, 
                    this._toy.Option.MaximumPartitions);

                this._toy.OptionDirectory.CreateDirectory(name);
            }

            var alldirectories = this._toy.OptionDirectory.RetrieveAllDirectories();

            var q = allcontainers.OrderByDescending(
                item => item.Voters * item.Elements);

            var k = 0;

            foreach (var item in q)
            {
                this.WriteContainer(item, alldirectories.ElementAt(k));

                k++;

                if (k > this._toy.Option.MaximumPartitions - 1)
                {
                    k = 0;
                }
            }
        }
        void WriteContainer(
            Container container, IDirectoryConcrete directory )
        {
            directory.CreateDirectory(container.Schema.FutureDirectory);
            var writerdirectory = directory.RetrieveDirectory( container.Schema.FutureDirectory );
            
            var filename = String.Format(
                "{0}{1}",
                writerdirectory.Fullname,
                container.Schema.File.Name);

            var writer = this._toy.Ambit.Pulan.Atoms.CreateWriter(filename);

            writer.WriteAttributeString("Created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            
            writer.WriteAttributeString("FutureDirectory", container.Schema.FutureDirectory);
            writer.WriteAttributeString("FutureFile", container.Schema.FutureFile);

            writer.WriteStartElement("Matches");

            var q = container.Schema.Matches;

            foreach (var item in q)
            {
                writer.WriteStartElement("Match");

                writer.WriteAttributeString("ID", item.ID.ToString());
                writer.WriteAttributeString("Kickoff", item.Kickoff.ToString("yyyy-MM-dd HH:mm:ss"));

                writer.WriteAttributeString("Nicename", item.Nicename);

                writer.WriteAttributeString("HomeID", item.HomeID.ToString());
                writer.WriteAttributeString("HomeName", item.HomeName);

                writer.WriteAttributeString("AwayID", item.AwayID.ToString());
                writer.WriteAttributeString("AwayName", item.AwayName);

                writer.WriteAttributeString("IsComingsoon", item.IsComingsoon.ToString());

                writer.WriteAttributeString("FirstHalfHomeGoals", item.FirstHalfHomeGoals.ToString());
                writer.WriteAttributeString("FirstHalfAwayGoals", item.FirstHalfAwayGoals.ToString());

                writer.WriteAttributeString("SecondHalfHomeGoals", item.SecondHalfHomeGoals.ToString());
                writer.WriteAttributeString("SecondHalfAwayGoals", item.SecondHalfAwayGoals.ToString());

                this.WriteAllVoters(item, writer);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            
            writer.Close();

            Console.WriteLine(filename);
        }
        void WriteAllVoters(
            IMatchConcrete match,
            IWriterConcrete writer)
        {
            writer.WriteStartElement("Voters");

            foreach (var item in match.Voters)
            {
                writer.WriteStartElement("Voter");

                writer.WriteAttributeString("Epochs", item.Epochs.ToString());
                writer.WriteAttributeString("Loss", item.Loss.ToString());
                    
                writer.WriteAttributeString("VoterFile", item.VoterFile);

                this.WriteVoter(item, writer);

                writer.WriteEndElement();
                
            }

            writer.WriteEndElement();
        }
        void WriteVoter(
            IVoterConcrete voter,
            IWriterConcrete writer)
        {
            writer.WriteStartElement("Output");

            foreach (var item in voter.Output)
            {
                writer.WriteStartElement("Vector");

                writer.WriteAttributeString("Index", item.Index.ToString());
                writer.WriteAttributeString("Value", item.Value.ToString());

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
