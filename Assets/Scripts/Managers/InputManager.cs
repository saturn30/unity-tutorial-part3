using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    private bool _pressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        // 키보드 입력이 있는 경우
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }
        if (MouseAction != null)
        {
            // 좌클릭
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                _pressed = false;
            }
        }
    }
}
