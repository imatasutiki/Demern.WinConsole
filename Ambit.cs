using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Demern.Contracts;

using Nibiru.Urubamba.Contracts;

using Nibiru.Pulan.Contracts;

using Nibiru.Raxa.Contracts.Atoms.All;

using Nibiru.Mozonte.Contracts.Atoms.All;

namespace Nibiru.Demern.WinConsole
{
    class Ambit
    {
        IDemernFactory _demern;
        IUrubambaFactory _urubamba;
        IPulanFactory _pulan;
        IBinaryConcrete _binary;
        IMenuConcrete _menu;
        public Ambit(
            IDemernFactory demern,
            IUrubambaFactory urubamba,
            IPulanFactory pulan,
            IBinaryConcrete binary,
            IMenuConcrete menu )
        {
            this._demern = demern;
            this._urubamba = urubamba;
            this._pulan = pulan;
            this._binary = binary;
            this._menu = menu;
        }
        public IDemernFactory Demern { get { return this._demern; } }
        public IUrubambaFactory Urubamba { get { return this._urubamba; } }
        public IPulanFactory Pulan { get { return this._pulan; } }
        public IBinaryConcrete Binary { get { return this._binary; } }
        public IMenuConcrete Menu { get { return this._menu; } }
        public void Start()
        {
            Console.WriteLine( "Name: '{0}'", this._menu.Selected.Name );
            Console.WriteLine( "Type: '{0}'", this._menu.Selected.Type );

            switch( this._menu.Selected.Type )
            {
                case "HelloWorld":

                    this.HelloWorld();
                    break;

                case "Testing":

                    this.Testing();
                    break;

                case "Build":

                    this.Build();
                    break;

                case "Merge":

                    this.Merge();
                    break;

                case "Split":

                    this.Split();
                    break;

                default:

                    var message = String.Format( "SelectedType: {0}", this._menu.Selected.Type );
                    throw new NotSupportedException( message );
            }
        }
        void Split()
        {
            var path = @"C:\FILES\TEST\Demern";
            var directory = this.Urubamba.Atoms.OpenDirectory(path);

            var toy = new Toys.ToySplit(this, directory);
            toy.Play();
        }
        void Merge()
        {
            var path = @"C:\FILES\TEST\Demern";
            var directory = this.Urubamba.Atoms.OpenDirectory(path);

            var toy = new Toys.ToyMerge(this, directory);
            toy.Play();
        }
        void Build()
        {
            var path = @"C:\FILES\TEST\Demern";
            var directory = this.Urubamba.Atoms.OpenDirectory( path );

            var toy = new Toys.ToyBuild(this, directory);
            toy.Play();
        }
        void Testing()
        {
            var toy = new Toys.ToyTesting( this );
            toy.Play();
        }
        void HelloWorld()
        {
            var toy = new Toys.ToyHelloWorld();
            toy.Play();
        }
    }
}
