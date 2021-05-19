using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class BetMatch
    {
        BetRepository _repository;

        Match _match;

        IDictionary<String, BetVoter> _voters;

        public BetMatch(
            BetRepository repository,
            Match match)
        {
            this._repository = repository;
            this._match = match;

            this._voters = new Dictionary<String, BetVoter>();

            this.Parse();
        }
        void Parse()
        {
            foreach( var item in this._match.Voters )
            {
                var voter = new BetVoter( this, item );

                this._voters.Add( item.Concrete.VoterFile, voter );
            }
        }
        public BetRepository Repository { get { return this._repository; } }
        public Match Match { get { return this._match; } }
        public IEnumerable<BetVoter> Voters { get { return this._voters.Values; } }

        public Boolean HasVoter( Voter voter )
        {
            return this._voters.ContainsKey(voter.Concrete.VoterFile);
        }

        public BetVoter this[ Voter voter ]
        {
            get
            {
                return this._voters[ voter.Concrete.VoterFile ];
            }
        }
        
        public Boolean SuccessPrimaryBet
        {
            get
            {
                if( ! this._repository.HasExperience( this._match.Concrete.ID ) )
                {
                    var message = String.Format( "ID: {0} | Kickoff: {1} | File: {2}", 
                        this._match.Concrete.ID, 
                        this._match.Concrete.Kickoff,
                        this._match.Concrete.SchemaParent.File.Fullname);

                    throw new NotSupportedException( message );
                }

                var single = this._repository.RetrieveExperience( this._match.Concrete.ID );

                return single.SuccessPrimaryBet;
            }
        }
        public Boolean SuccessSecondaryBet
        {
            get
            {
                var single = this._repository.RetrieveExperience( this._match.Concrete.ID );

                return single.SuccessSecondaryBet;
            }
        }

        public Boolean EffectivenessOutputPrimaryBetSuccessPrimaryBet( BetVoter voter )
        {
            var single = this._voters[ voter.Voter.Concrete.VoterFile ];

            return single.OutputPrimaryBet & this.SuccessPrimaryBet;
        }

        public Boolean EffectivenessOutputSecondaryBetSuccessSecondaryBet(BetVoter voter)
        {
            var single = this._voters[ voter.Voter.Concrete.VoterFile ];

            return single.OutputSecondaryBet & this.SuccessSecondaryBet;
        }
    }
}
