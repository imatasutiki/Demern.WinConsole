using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Bafang.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Scope
    {
        Play _play;
        BetRepository _repository;

        IList<SprintHub> _sprints;

        public Scope(
            Play play,
            BetRepository repository )
        {
            this._play = play;
            this._repository = repository;

            this._sprints = new List<SprintHub>();

            this.Parse();
        }
        public BetRepository Repository { get { return this._repository; } }
        void Parse()
        {
            var begin = this._play.Toy.Option.Begin;
            var end = this._play.Toy.Option.End;
            
            var mode = this._play.Toy.Option.SprintMode;
            var total = this._play.Toy.Option.TotalSprints;

            var beginoffset = 0;
            var endoffset = 0;
                
            for (var i = 0; i < total; i++)
            {
                var sprint = new SprintHub( this._repository, begin, end);
                this._sprints.Add(sprint);

                switch( mode )
                {
                    case "Weekend":

                        if( i % 2 == 0)
                        {
                            beginoffset = 4;
                            endoffset = 3;
                        }
                        else
                        {
                            beginoffset = 3;
                            endoffset = 4;
                        }

                        break;

                    case "Other":

                        if (i % 2 == 0)
                        {
                            beginoffset = 3;
                            endoffset = 4;
                        }
                        else
                        {
                            beginoffset = 4;
                            endoffset = 3;
                        }

                        break;

                    default:

                        var message = String.Format( "Mode: {0}", mode );
                        throw new NotSupportedException( message );
                }
                
                begin = begin.AddDays(- beginoffset); ;
                end = end.AddDays(- endoffset); ;
            }
        }

        public IEnumerable<SprintHub> Sprints { get { return this._sprints; } }
    }
}
