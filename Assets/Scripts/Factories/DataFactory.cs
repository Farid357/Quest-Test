using Quest.Data;

namespace Quest.GameLogic
{
    public sealed class DataFactory
    {
        public ScreenData.Data Create(EditorData editorData, EditorData withTransition)
        {
            var texture = editorData.Card.texture.GetRawTextureData();
            var transitionTexture = withTransition.Card.texture.GetRawTextureData();
            var transitionData = new ScreenData.Data(withTransition.Description, withTransition.ChoiseDescription, transitionTexture, default);
            return new ScreenData.Data(editorData.Description, editorData.ChoiseDescription, texture, transitionData);
        }
    }
}
