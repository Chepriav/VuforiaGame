
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public float speed = 6f;            // Velocidad del player.

    private Joystick joystick;
    Vector3 direction;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        direction = Vector3.zero;
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (joystick.Direction != Vector2.zero)
        {
        Turning();
        }
    }

    void Turning()
    {
        direction = joystick.Direction;

        float heading = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,heading - 45 ,0f);
    }
}
