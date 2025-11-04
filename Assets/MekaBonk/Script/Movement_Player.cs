using UnityEngine;

[RequireComponent(typeof(Controller_Player), typeof(CharacterController))]
public class Movement_Player : MonoBehaviour
{
    // component
    private Controller_Player controller_Player;
    private CharacterController character_Controller;

    // ray
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        TryGetComponent(out controller_Player);
        TryGetComponent(out character_Controller);
    }

    public void Move(float _moveSpeed, float _deltatime)
    {
        if (controller_Player == null) return;
        if (character_Controller == null) return;

        Vector2 inputValue = controller_Player.inputValue;
        Vector3 moveValue = new(inputValue.x, 0, inputValue.y);

        Move(moveValue, _moveSpeed, _deltatime);
    }

    public void Move(Vector3 _moveValue, float _moveSpeed ,float _deltatime)
    {
        Vector3 movement = _moveValue * _moveSpeed * _deltatime;

        character_Controller.Move(movement);
    }

    public void Rotation(Transform _transform)
    {
        Vector3 hitPoint = MousePointHit();

        Vector3 direction = _transform.position - hitPoint;
        direction.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        _transform.rotation = targetRotation;
    }

    private Vector3 MousePointHit()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int layerMask = LayerMask.GetMask("Plane");
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private void Update()
    {
       
    }
}
