using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class BetRepository
    {
        Container _container;
        TupleBet _tuple;

        IList<BetMatch> _matches;
        IDictionary<Int32, BetExperience> _experiences;

        public BetRepository(
            Container container,
            TupleBet tuple )
        {
            this._container = container;
            this._tuple = tuple;

            this._matches = new List<BetMatch>();
            this._experiences = new Dictionary<Int32, BetExperience>();

            this.Parse();
        }
        public Container Container { get { return this._container; } }
        public TupleBet Tuple { get { return this._tuple; } }
        public IEnumerable<BetMatch> Matches { get { return this._matches; } }
        public IEnumerable<BetExperience> Experiences { get { return this._experiences.Values; } }
        void Parse()
        {
            this.BuildMatches();
            this.BuildExperiences();
        }
        void BuildExperiences()
        {
            foreach (var item in this._container.Experiences)
            {
                var experience = new BetExperience(this, item);

                this._experiences.Add( item.Concrete.ID, experience);
            }
        }
        void BuildMatches()
        {
            foreach (var item in this._container.Matches)
            {
                var match = new BetMatch(this, item);

                this._matches.Add(match);
            }
        }
        public Boolean HasExperience(
            Int32 ID)
        {
            return this._experiences.ContainsKey(ID);
        }
        public BetExperience RetrieveExperience(
            Int32 ID)
        {
            return this._experiences[ID];
        }
    }
}
