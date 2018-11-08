
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Joystick joystick;
    Vector3 direction;
    public Transform model;

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
        direction = (joystick.Direction).normalized;
        
        float heading = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)-90;
        model.rotation = Quaternion.Euler(0f, heading * -1, 0f);
    }
}
