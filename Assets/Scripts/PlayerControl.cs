
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D player_rb;
    [SerializeField]
    private float movement_speed;

    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move_player();
    }

    private void move_player()
    {
        Vector2 move_direction = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A)) {
            //Debug.Log("A");
            move_direction.x += -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            //Debug.Log("D");
            move_direction.x += 1;
        }
        player_rb.linearVelocity = move_direction * movement_speed;
        //player_rb.Position += move_direction * movement_speed;
        //float inputHorizontal = Input.GetAxisRaw("Horizontal");
        //player_rb.linearVelocity = new Vector2(inputHorizontal * movementSpeed, player_rb.linearVelocityY);
    }
}
