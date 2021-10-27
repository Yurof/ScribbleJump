using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsPLayer : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public JumpingPlayer jumpingPlayer;
    public Weapon weapon;

    private PlayerActionControls controls;

    private void Awake()
    {
        controls = new PlayerActionControls();
        controls.Player.Jump.performed += ctx => Jumping();
        controls.Player.Move.performed += ctx => Move(ctx);
        controls.Player.Pause.performed += ctx => pauseMenu.ResumeOrPause();
        controls.Player.Shoot.performed += ctx => weapon.Shoot();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Jumping()
    {
        if (PlayerPrefs.HasKey("Cheat"))
        {
            if (PlayerPrefs.GetInt("Cheat") == 1)
            {
                jumpingPlayer.Jump();
            }
        }
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        jumpingPlayer.Moving(ctx.ReadValue<float>());
    }
}