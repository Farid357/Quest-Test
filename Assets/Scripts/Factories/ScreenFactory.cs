using Quest.Data;
using System.Collections.Generic;
using System.Linq;

namespace Quest.GameLogic
{
    public sealed class ScreenFactory
    {
        public ScreenData.Screen Create(EditorScreen editorScreen, EditorScreen[] withTransitions)
        {
            var transitions = CreateTransitions(withTransitions);
            var texture = editorScreen.Card.texture.GetRawTextureData();
            return new ScreenData.Screen(editorScreen.Description, editorScreen.ChoiseDescription, texture, transitions.ToArray());
        }

        private IEnumerable<ScreenData.Screen> CreateTransitions(EditorScreen[] editorScreens)
        {
            foreach (var screen in editorScreens)
            {
                var texture = screen.Card.texture.GetRawTextureData();
                yield return new ScreenData.Screen(screen.Description, screen.ChoiseDescription, texture, default);
            }
        }
    }
}
