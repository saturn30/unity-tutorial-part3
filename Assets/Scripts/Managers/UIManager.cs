
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
  int _order = 1;
  Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
  UI_Scene _sceneUI = null;

  GameObject Root
  {
    get
    {
      GameObject uiRoot = GameObject.Find("@UI_Root");
      if (uiRoot == null) uiRoot = new GameObject { name = "@UI_Root" };
      return uiRoot;
    }
  }

  public void SetCanvas(GameObject go, bool sort = true)
  {
    Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    canvas.overrideSorting = true; // 부모가 어떤 소팅값을 가지더라도 자식 sort값 우선 적용

    if (sort)
    {
      canvas.sortingOrder = _order;
      _order += 1;
    }
    else
    {
      canvas.sortingOrder = 0;
    }
  }


  public T ShowPopupUI<T>(string name = null) where T : UI_Popup
  {
    if (string.IsNullOrEmpty(name)) name = typeof(T).Name;
    GameObject go = Managers.Resource.Inistantiate($"UI/Popup/{name}");
    T popup = Util.GetOrAddComponent<T>(go);
    _popupStack.Push(popup);
    go.transform.SetParent(Root.transform);

    return popup;
  }

  public void ClosePopupUI()
  {
    if (_popupStack.Count == 0)
    {
      return;
    }
    UI_Popup popup = _popupStack.Pop();
    Managers.Resource.Destroy(popup.gameObject);
  }
  // 좀 더 안전하게 삭제하기 위해서 대상 팝업인지 체크할 인자를 받음.
  public void ClosePopupUI(UI_Popup popup)
  {
    if (_popupStack.Count == 0)
    {
      return;
    }
    if (_popupStack.Peek() != popup)
    {
      Debug.Log("Close Popup Failed!");
      return;
    }
    ClosePopupUI();
  }

  public void CloseAllPopupUI()
  {
    while (_popupStack.Count != 0)
    {
      ClosePopupUI();
    }
  }


  public T ShowSceneUI<T>(string name = null) where T : UI_Scene
  {
    if (string.IsNullOrEmpty(name)) name = typeof(T).Name;
    GameObject go = Managers.Resource.Inistantiate($"UI/Scene/{name}");
    T scene = Util.GetOrAddComponent<T>(go);
    _sceneUI = scene;

    go.transform.SetParent(Root.transform);

    return scene;
  }
}
