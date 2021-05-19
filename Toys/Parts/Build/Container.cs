using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Container
    {
        Play _play;
        ISchemaConcrete _schema;

        IList<Match> _matches;
        IList<Experience> _experiences;

        public Container(
            Play play,
            ISchemaConcrete schema)
        {
            this._play = play;
            this._schema = schema;

            this._matches = new List<Match>();
            this._experiences = new List<Experience>();

            this.Parse();
        }
        public Play Play { get { return this._play; } }
        public ISchemaConcrete Schema { get { return this._schema; } }
        public IEnumerable<Match> Matches { get { return this._matches; } }
        public IEnumerable<Experience> Experiences { get { return this._experiences; } }
        void Parse()
        {
            foreach (var item in this._schema.Experiences)
            {
                var experience = new Experience(this, item);

                this._experiences.Add(experience);
            }

            foreach ( var item in this._schema.Matches )
            {
                var match = new Match( this, item );

                this._matches.Add( match );
            }
        }
    }
}
