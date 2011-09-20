using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Statistics
{
    class PlayerStatisticItemCollection<T> : IDictionary<Player, PlayerStatisticItem<T> >
    {
        public void Add(Player key, PlayerStatisticItem<T> value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Player key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Player> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Player key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Player key, out PlayerStatisticItem<T> value)
        {
            throw new NotImplementedException();
        }

        public ICollection<PlayerStatisticItem<T>> Values
        {
            get { throw new NotImplementedException(); }
        }

        public PlayerStatisticItem<T> this[Player key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<Player, PlayerStatisticItem<T>> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Player, PlayerStatisticItem<T>> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Player, PlayerStatisticItem<T>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<Player, PlayerStatisticItem<T>> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Player, PlayerStatisticItem<T>>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
