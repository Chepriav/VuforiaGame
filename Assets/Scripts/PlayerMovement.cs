
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public float speed = 6f;            // Velocidad del player.

    public Vector3 movement;                   // The vector to store the direction of the player's movement.
    private Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    private float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");

        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move(h, v);

        
        //Turning();
    }

    void Move(float h, float v)
    {
        
        movement.Set(h, 0f, v);

        
        movement = movement.normalized * speed * Time.deltaTime;

        
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        
        RaycastHit floorHit;

        
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            
            Vector3 playerToMouse = floorHit.point - transform.position;

            
            playerToMouse.y = 0f;

            
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            
            playerRigidbody.MoveRotation(newRotation);
        }
    }

}
