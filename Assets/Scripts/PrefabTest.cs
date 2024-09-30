using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    void Start()
    {
        GameObject tank = Managers.Resource.Inistantiate("Tank");
        Managers.Resource.Destroy(tank, 3.0f);
    }
}
