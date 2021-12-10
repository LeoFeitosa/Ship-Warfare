using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ClickableLinkController : MonoBehaviour, IPointerClickHandler
{
    TextMeshProUGUI textMessage;

    void Start()
    {
        textMessage = GetComponent<TextMeshProUGUI>();
        CheckLinks();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMessage, eventData.position, eventData.pressEventCamera);
        if (linkIndex == -1)
            return;
        TMP_LinkInfo linkInfo = textMessage.textInfo.linkInfo[linkIndex];
        string selectedLink = linkInfo.GetLinkID();
        if (selectedLink != "")
        {
            Debug.LogFormat("Open link {0}", selectedLink);
            Application.OpenURL(selectedLink);
        }
    }

    void CheckLinks()
    {
        Regex regx = new Regex("((http://|https://|www\\.)([A-Z0-9.-:]{1,})\\.[0-9A-Z?;~&#=\\-_\\./]{2,})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        MatchCollection matches = regx.Matches(textMessage.text);
        foreach (Match match in matches)
            textMessage.text = textMessage.text.Replace(match.Value, match.Value);
    }
}