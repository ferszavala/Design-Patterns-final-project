using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_final
{

    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract int Key();

        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();
    }


    public abstract class Aggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
    public class ValueIterator : Iterator
    {
        List<KeyValuePair<float, string>> ganancia = new List<KeyValuePair<float, string>>(); private int _posicion = -1;
        public ValueIterator(List<KeyValuePair<float, string>> ganancia)
        {
            this.ganancia = ganancia;
        }

        public override object Current()
        {
            return ganancia[_posicion];
        }

        public override int Key()
        {
            return _posicion;
        }

        public override bool MoveNext()
        {
            if (_posicion < ganancia.Count - 1)
            {
                _posicion++;
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            _posicion = 0;
        }
    }
    public class ConcreteAggregate : Aggregate
    {

        List<KeyValuePair<float, string>> ganancia;
        public ConcreteAggregate(List<KeyValuePair<float, string>> ganancia)
        {
            this.ganancia = ganancia;
        }
        public ConcreteAggregate()
        {
            this.ganancia = new List<KeyValuePair<float, string>>();
        }
        public void Add(KeyValuePair<float, string> s)
        {
            ganancia.Add(s);
        }
        public override IEnumerator GetEnumerator()
        {
            return new ValueIterator(ganancia);
        }
        public void ordenar()
        {
            this.ganancia = ganancia.OrderBy(kvp => kvp.Key).ToList();
        }
        public void reverse()
        {
            this.ganancia = Enumerable.Reverse(ganancia).ToList();
        }
    }
}
