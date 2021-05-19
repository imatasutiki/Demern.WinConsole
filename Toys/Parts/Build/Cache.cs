using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Nibiru.Demern.WinConsole.Toys.Parts.Build
{
    class Cache
    {
        Type _type;

        IEnumerable<PropertyInfo> _properties;
        
        public Cache( Type type )
        {
            this._type = type;

            this._properties = new List<PropertyInfo>( type.GetProperties() );
        }
        public PropertyInfo Single( String name )
        {
            try
            {
                return this._properties.Single(
                    item => item.Name == name);
            }
            catch( Exception ex )
            {
                var message = String.Format( "Name: {0} in {1}", name, this._type.Name );
                throw new NotSupportedException( message, ex );
            }
        }
    }
}
