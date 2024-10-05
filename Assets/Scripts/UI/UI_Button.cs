
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    enum Texts
    {
        PointButtonText,
        ScoreText
    }

    enum Buttons
    {
        PointButton
    }

    enum GameObjects
    {
        TestObject
    }

    enum Images
    {
        ItemIcon
    }
    int _score = 0;

    private void Start()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetText((int)Texts.ScoreText).text = "Blind Test";

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClick);
    }

    void OnButtonClick(PointerEventData data)
    {
        _score += 1;
        if (_score > 10)
        {
            GetText((int)Texts.ScoreText).SetText("You Win!!");
        }
        else
        {
            GetText((int)Texts.ScoreText).SetText($"Point : {_score}");
        }
    }
}
