using System;
using System.Collections.Generic;

namespace Quest.Data
{
    [Serializable]
    public sealed class ScreenData
    {
        private readonly List<Data> _all = new();

        public void Add(Data data) => _all.Add(data);


        [Serializable]

        public sealed class Data
        {
            public string Description;
            public string ChoiseDescription;
            public byte[] Card;
            public Data Transition;

            public Data(string description, string choiseDescription, byte[] card, Data transition)
            {
                Description = description ?? throw new ArgumentNullException(nameof(description));
                ChoiseDescription = choiseDescription ?? throw new ArgumentNullException(nameof(choiseDescription));
                Card = card ?? throw new ArgumentNullException(nameof(card));
                Transition = transition ?? throw new ArgumentNullException(nameof(transition));
            }
        }
    }
}
