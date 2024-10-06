using UnityEngine;

public class TestSound : MonoBehaviour
{
    int i = 0;
    public AudioClip audioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (i % 2 == 0)
        {
            Managers.Sound.Play(audioClip, Define.Sound.Bgm);
        }
        else
        {
            Managers.Sound.Play("UnityChan/univ0002", Define.Sound.Bgm);
        }
        i++;
    }
}
