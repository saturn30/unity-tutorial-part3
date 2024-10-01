using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collision Enter : {other.gameObject.name}");
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log($"Trigger Enter : {other.gameObject.name}");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1f);
            RaycastHit hit;

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                Debug.Log($"Raycase camera : {hit.collider.gameObject.name}");
            }
        }
    }
}
