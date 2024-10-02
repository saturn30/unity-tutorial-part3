using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField] private Vector3 _delta = new Vector3(0f, 10f, -10f);
    [SerializeField] private GameObject _player;

    private void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            Vector3 playerPos = _player.transform.position + Vector3.up * 2f;
            if (Physics.Raycast(playerPos, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - playerPos).magnitude * 0.8f;
                transform.position = playerPos + _delta.normalized * dist;
                transform.LookAt(playerPos);
            }
            else
            {
                transform.position = playerPos + _delta;
                transform.LookAt(playerPos);
            }
        }
    }
}
