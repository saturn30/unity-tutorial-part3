using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void Init();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
            if (objects[i] == null) Debug.Log($"Failed to bind! : {names[i]}");
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            return null;
        }
        return objects[index] as T;
    }

    protected GameObject GetGameObject(int index) { return Get<GameObject>(index); }
    protected TextMeshProUGUI GetText(int index) { return Get<TextMeshProUGUI>(index); }
    protected Button GetButton(int index) { return Get<Button>(index); }
    protected Image GetImage(int index) { return Get<Image>(index); }

    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = go.GetOrAddComponent<UI_EventHandler>();
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHangler -= action;
                evt.OnDragHangler += action;
                break;
        }
    }
}
