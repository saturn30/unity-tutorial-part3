using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform chlid in gridPanel.transform)
        {
            Managers.Resource.Destroy(chlid.gameObject);
        }

        // 실제 인벤토리 정보를 참고해서 넣어야함
        for (int i = 0; i < 10; i++)
        {
            UI_Inven_Item item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent: gridPanel.transform);
            item.SetInfo($"Sword {i + 1}");
        }

    }

    private void Start()
    {
        Init();
    }
}
