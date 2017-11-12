using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class PunctuationFactory:ISentenceItemFactory
    {
        IDictionary<string, ISentenceItem> _cachedItems;

        public ISentenceItem Create(string chars)
        {
            return _cachedItems.ContainsKey(chars) ? _cachedItems[chars] : null;
        }
        public PunctuationFactory(SeparatorContainer separatorContainer)
        {
            _cachedItems = new Dictionary<string, ISentenceItem>();
            foreach (var l in separatorContainer.All())
            {
                _cachedItems.Add(l.Content, new Punctuation(l));

            }
        }
    }
}
