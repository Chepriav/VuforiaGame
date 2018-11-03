
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Joystick joystick;
    Vector3 direction;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        direction = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (joystick.Direction != Vector2.zero)
        {
        Turning();
        }
    }

    void Turning()
    {
        direction = joystick.Direction;
       
        float heading = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,heading * -1,0f);
    }
}
