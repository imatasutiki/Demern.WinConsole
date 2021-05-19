using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Merge
{
    class Container
    {
        Repository _repository;
        ISchemaConcrete _schema;

        IList<Box> _boxes;

        public Container(
            Repository repository,
            ISchemaConcrete schema )
        {
            this._repository = repository;
            this._schema = schema;

            this._boxes = new List<Box>();

            this.Parse();
        }
        void Parse()
        {
            var q = this._schema.Matches;

            foreach( var item in q )
            {
                var box = new Box( this, item );

                this._boxes.Add( box );
            }
        }
        public Repository Repoitory { get { return this._repository; } }
        public ISchemaConcrete Schema { get { return this._schema; } }
        public IEnumerable<Box> Boxes { get { return this._boxes; } }
    }
}
