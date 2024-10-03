using TMPro;
using UnityEngine;

public class UI_Button : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    int point = 0;

    public void OnButtonClick()
    {
        point += 1;
        text.SetText($"Point : {point}");
    }
}
