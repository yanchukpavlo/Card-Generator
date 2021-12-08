using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{
    [Header("Card")]
    [SerializeField] SOCardGenetatorData data;
    [SerializeField] float widthCard = 300;
    [SerializeField] float heigthCard = 500;
    [SerializeField] float textSpacing = 5;

    [Header("Background")]
    [SerializeField] float spacing = 10;
    [SerializeField] Color backgroundColor;
    [SerializeField] Sprite backgroundSprite;

    [Header("Header")]
    [SerializeField] [Range(0, 1)] float widthHeaderP = 0.95f;
    [SerializeField] [Range(0, 1)] float heigthHeaderP = 0.15f;

    [Header("Visual")]
    [SerializeField] [Range(0, 1)] float widthVisualP = 0.95f;
    [SerializeField] [Range(0, 1)] float heigthVisualP = 0.5f;

    [Header("Description")]
    [SerializeField] [Range(0, 1)] float widthDescriptionP = 0.95f;
    [SerializeField] [Range(0, 1)] float heigthDescriptionP = 0.35f;

    Card currentNewCard;
    Card currentLodetCard;

    public void CreateCard()
    {
        if (currentNewCard != null)
        {
            Destroy(currentNewCard.gameObject);
        }

        //create card
        RectTransform cardRect  = CreateBlock("New Card", transform.parent, new Vector2(widthCard, heigthCard));
        cardRect.localPosition += new Vector3(-250, 0);
        Card card = cardRect.gameObject.AddComponent<Card>();
        currentNewCard = card;
        SetRandomCardInfo(card, data);

        //create background
        RectTransform bgRect = CreateBlock("Background", cardRect);
        AddImage(bgRect.gameObject, backgroundSprite, backgroundColor);
        AddVerticalLayoutGroup(bgRect.gameObject, spacing);

        //create header
        RectTransform headerRect = CreateBlock("Header", bgRect, 
            new Vector2((widthCard * widthHeaderP), (heigthCard * heigthHeaderP) - spacing*2));
        AddImage(headerRect.gameObject, null, Color.white);
        AddText(headerRect.gameObject, card.Header);

        //create visual
        RectTransform visualRect = CreateBlock("Visual", bgRect,
            new Vector2((widthCard * widthVisualP), (heigthCard * heigthVisualP) - spacing*2));
        AddImage(visualRect.gameObject, card.Visual, Color.white);

        //create description
        RectTransform descriptionRect = CreateBlock("Description", bgRect,
            new Vector2((widthCard * widthDescriptionP), (heigthCard * heigthDescriptionP) - spacing*2));
        AddImage(descriptionRect.gameObject, null, Color.white);
        AddText(descriptionRect.gameObject, card.Description);
    }

    public void SaveCard()
    {
        if (currentNewCard != null)
        {
            CardSaver.SaveCard(currentNewCard);
        }
    }

    public void LoadCard()
    {
        if (currentLodetCard != null)
        {
            Destroy(currentLodetCard.gameObject);
        }

        //create card
        RectTransform cardRect = CreateBlock("New Card", transform.parent, new Vector2(widthCard, heigthCard));
        cardRect.localPosition += new Vector3(250, 0);
        Card card = cardRect.gameObject.AddComponent<Card>();
        currentLodetCard = card;
        CardSaver.LoadCard(card);

        //create background
        RectTransform bgRect = CreateBlock("Background", cardRect);
        AddImage(bgRect.gameObject, backgroundSprite, backgroundColor);
        AddVerticalLayoutGroup(bgRect.gameObject, spacing);

        //create header
        RectTransform headerRect = CreateBlock("Header", bgRect,
            new Vector2((widthCard * widthHeaderP), (heigthCard * heigthHeaderP) - spacing * 2));
        AddImage(headerRect.gameObject, null, Color.white);
        AddText(headerRect.gameObject, card.Header);

        //create visual
        RectTransform visualRect = CreateBlock("Visual", bgRect,
            new Vector2((widthCard * widthVisualP), (heigthCard * heigthVisualP) - spacing * 2));
        AddImage(visualRect.gameObject, card.Visual, Color.white);

        //create description
        RectTransform descriptionRect = CreateBlock("Description", bgRect,
            new Vector2((widthCard * widthDescriptionP), (heigthCard * heigthDescriptionP) - spacing * 2));
        AddImage(descriptionRect.gameObject, null, Color.white);
        AddText(descriptionRect.gameObject, card.Description);
    }

    void SetRandomCardInfo(Card card, SOCardGenetatorData data)
    {
        card.Header = Helper.Randomize(data.headers);
        card.Visual = Helper.Randomize(data.visuals);
        card.Description = Helper.Randomize(data.descriptions);
        card.Modifier = Helper.Randomize(data.cardModifier);
    }

    RectTransform CreateBlock(string name, Transform parent, Vector2 size)
    {
        GameObject obj = new GameObject(name, typeof(RectTransform));
        RectTransform rect = (RectTransform)obj.transform;
        rect.SetParent(parent, false);
        rect.sizeDelta = size;

        return rect;
    }

    RectTransform CreateBlock(string name, Transform parent)
    {
        GameObject obj = new GameObject(name, typeof(RectTransform));
        RectTransform rect = (RectTransform)obj.transform;
        rect.SetParent(parent, false);
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);
        rect.sizeDelta = new Vector2(0, 0);
        return rect;
    }

    RectTransform CreateBlock(string name, Transform parent, float spacing)
    {
        GameObject obj = new GameObject(name, typeof(RectTransform));
        RectTransform rect = (RectTransform)obj.transform;
        rect.SetParent(parent, false);
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);
        rect.sizeDelta = -Vector2.one *  spacing * 2;
        return rect;
    }

    void AddVerticalLayoutGroup(GameObject obj, float spacing)
    {
        VerticalLayoutGroup group = obj.AddComponent<VerticalLayoutGroup>();
        group.childAlignment = TextAnchor.MiddleCenter;
        group.childControlHeight = false;
        group.childControlWidth = false;
        group.childForceExpandHeight = false;
        group.childForceExpandWidth = false;
        group.spacing = spacing;
    }
    
    void AddImage(GameObject obj, Sprite sprite, Color color)
    {
        Image bgImage = obj.AddComponent<Image>();
        if (sprite != null)
        {
            bgImage.type = Image.Type.Sliced;
            bgImage.sprite = sprite;
            bgImage.color = color;
        }
    }

    void AddText(GameObject obj, string text)
    {
        var textObj = CreateBlock("Text", obj.transform, textSpacing);
        TextMeshProUGUI textMesh = textObj.gameObject.AddComponent<TextMeshProUGUI>();
        textMesh.color = Color.black;
        textMesh.enableAutoSizing = true;
        textMesh.horizontalAlignment = HorizontalAlignmentOptions.Center;
        textMesh.verticalAlignment = VerticalAlignmentOptions.Middle;
        textMesh.text = text;
    }
}
