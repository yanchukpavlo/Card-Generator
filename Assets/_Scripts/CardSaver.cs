using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class CardSaver
{
    public static void SaveCard(Card card)
    {
        SerializeData exportObj = new SerializeData();

        exportObj.header = card.Header;
        exportObj.description = card.Description;
        exportObj.modifier = card.Modifier;

        Texture2D tex = DeCompress(card.Visual.texture);
        exportObj.spriteX = tex.width;
        exportObj.spriteY = tex.height;
        exportObj.spriteBytes = ImageConversion.EncodeToPNG(tex);
        string text = JsonConvert.SerializeObject(exportObj);
        File.WriteAllText(Application.persistentDataPath + "/temp.zyxer", text);
    }

    public static void LoadCard(Card card)
    {
        SerializeData importObj = new SerializeData();

        string text = File.ReadAllText(Application.persistentDataPath + "/temp.zyxer");
        importObj = JsonConvert.DeserializeObject<SerializeData>(text);
        Texture2D tex = new Texture2D(importObj.spriteX, importObj.spriteY);
        ImageConversion.LoadImage(tex, importObj.spriteBytes);
        Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one);

        card.Header = importObj.header;
        card.Visual = mySprite;
        card.Description = importObj.description;
        card.Modifier = importObj.modifier;
    }

    static Texture2D DeCompress(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

    [System.Serializable]
    class SerializeData
    {
        public string header;
        public string description;
        public SOCardModifier modifier;

        public int spriteX;
        public int spriteY;
        public byte[] spriteBytes;
    }
}