using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    Vector3 _destPos;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        Managers.Resource.Inistantiate("UI/UI_Button");

        // InputManager 이벤트 핸들러 등록
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    public enum PlayerState
    {
        Die, Moving, Idle
    }
    PlayerState _state = PlayerState.Idle;

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1f);

        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Wall");
        if (Physics.Raycast(ray, out hit, 100f, mask))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
        }
    }

    void UpdateDie() { }
    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }
        anim.SetFloat("speed", _speed);
    }
    void UpdateIdle()
    {
        anim.SetFloat("speed", 0);
    }
}
