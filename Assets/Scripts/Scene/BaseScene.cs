using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;

    protected virtual void Init()
    {
        Object obj = FindFirstObjectByType(typeof(EventSystem));
        if (obj == null)
        {

            Managers.Resource.Inistantiate("UI/EventSystem").name = "@EventSystem";
        }
    }

    public abstract void Clear();
}
