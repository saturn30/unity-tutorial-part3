using System.Collections.Generic;
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

        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            list.Add(Managers.Resource.Inistantiate("unitychan"));
        }
        foreach (GameObject obj in list)
        {
            Managers.Resource.Destroy(obj);
        }
    }

    public override void Clear()
    {
        Debug.Log("Login Scene Clear");
    }
}
