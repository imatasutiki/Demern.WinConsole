using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class SprintHub
    {
        BetRepository _repository;
        DateTime _begin;
        DateTime _end;

        IList<SprintMatch> _comingsoon;
        IList<SprintMatch> _matches;
        IList<SprintExperience> _experiences;

        public SprintHub(
            BetRepository repository,
            DateTime begin,
            DateTime end )
        {
            this._repository = repository;
            this._begin = begin;
            this._end = end;

            this._comingsoon = new List<SprintMatch>();
            this._matches = new List<SprintMatch>();
            this._experiences = new List<SprintExperience>();

            this.Parse();
        }
        void Parse()
        {
            this.BuildComingsoon();
            this.BuildMatches();
            this.BuildExperiences();
        }
        void BuildExperiences()
        {
            var q = this._repository.Experiences.Where(
                item => item.Experience.Concrete.Kickoff < this._begin);

            foreach( var item in q )
            {
                var experience = new SprintExperience( this, item );
                this._experiences.Add( experience );
            }
        }
        void BuildComingsoon()
        {
            var q = this._repository.Matches.Where(
                item => item.Match.Concrete.Kickoff > this._begin
                    & item.Match.Concrete.Kickoff < this._end);

            foreach (var item in q)
            {
                var match = new SprintMatch(this, item);
                this._comingsoon.Add(match);
            }
        }
        void BuildMatches()
        {
            var q = this._repository.Matches.Where(
                item => item.Match.Concrete.Kickoff < this._begin);

            foreach (var item in q)
            {
                var match = new SprintMatch(this, item);
                this._matches.Add(match);
            }
        }
        public BetRepository Repository { get { return this._repository; } }
        public IEnumerable<SprintMatch> Comingsoon { get { return this._comingsoon; } }
        public IEnumerable<SprintMatch> Matches { get { return this._matches; } }
        public IEnumerable<SprintExperience> Experiences { get { return this._experiences; } }
    }
}
