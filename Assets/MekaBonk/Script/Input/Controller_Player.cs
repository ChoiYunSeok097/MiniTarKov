using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_Player : MonoBehaviour, Input_Player.IPlayerActions
{
    private Input_Player input;

    public Vector2 inputValue { get; private set; }

    private void Start()
    {
        input = new Input_Player();
        input.Player.SetCallbacks(this);

        input.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
    }
}
