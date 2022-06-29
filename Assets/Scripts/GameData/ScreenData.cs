using System;
using System.Collections.Generic;

namespace Quest.Data
{
    [Serializable]
    public sealed class ScreenData
    {
        private readonly List<Screen> _all = new();

        public void Add(Screen data) => _all.Add(data);


        [Serializable]

        public sealed class Screen
        {
            public string Description;
            public string ChoiseDescription;
            public byte[] Card;
            public Screen[] Transitions;

            public Screen(string description, string choiseDescription, byte[] card, Screen[] transitions)
            {
                Description = description ?? throw new ArgumentNullException(nameof(description));
                ChoiseDescription = choiseDescription ?? throw new ArgumentNullException(nameof(choiseDescription));
                Card = card ?? throw new ArgumentNullException(nameof(card));
                Transitions = transitions ?? throw new ArgumentNullException(nameof(transitions));
            }
        }
    }
}
