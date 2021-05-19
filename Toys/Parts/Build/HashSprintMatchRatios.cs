using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class HashSprintMatchRatios
    {
        IDictionary<EnumSprintMatchRatios, Double> _hash;

        public HashSprintMatchRatios()
        {
            this._hash = new Dictionary<EnumSprintMatchRatios, Double>();
        }

        public Boolean Contains( EnumSprintMatchRatios key )
        {
            return this._hash.ContainsKey(key);
        }

        public Double this[ EnumSprintMatchRatios key ]
        {
            get
            {
                if( ! this._hash.ContainsKey( key ) )
                {
                    var message = String.Format( "key: {0}", key );
                    throw new NotSupportedException(message);
                }

                return this._hash[key];
            }
        }
        public void Add(EnumSprintMatchRatios key, Double value)
        {
            this._hash.Add( key, value );
        }
    }
}
