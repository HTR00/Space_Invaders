using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image backgroundImage;
    public Color hoverColor = Color.gray;
    public float hoverScale = 1.1f;

    private Color originalColor;
    private Vector3 originalScale;

    void Start()
    {
        originalColor = GetComponentInChildren<Text>().color;
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (backgroundImage != null)
        {
            backgroundImage.color = hoverColor;
        }

        GetComponentInChildren<Text>().color = hoverColor;
        transform.localScale = originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (backgroundImage != null)
        {
            backgroundImage.color = new Color (19, 250, 0);
;
        }

        GetComponentInChildren<Text>().color = originalColor;
        transform.localScale = originalScale;
    }
}
