using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }

    protected override void Init()
    {
        base.Init();
    }

    public override void Clear()
    {
        Debug.Log("Login Scene Clear");
    }
}
