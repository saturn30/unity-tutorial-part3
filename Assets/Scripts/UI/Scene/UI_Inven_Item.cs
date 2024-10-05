using TMPro;
using UnityEngine;

public class UI_Inven_Item : UI_Base
{
    string _name;
    enum GameObjects
    {
        ItemIcon,
        ItemNameText
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<TextMeshProUGUI>().text = _name;
        Get<GameObject>((int)GameObjects.ItemIcon).AddUIEvent(data => Debug.Log($"아이템 클릭 {_name}"));
    }
    private void Start()
    {
        Init();
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
