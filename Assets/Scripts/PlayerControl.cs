
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameBehavior game_behavior;
    private Rigidbody2D player_rb;
    [SerializeField]
    private float movement_speed;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;

    void Start()
    {
        game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
        player_rb = GetComponent<Rigidbody2D>();
        set_texture(game_behavior.get_lives());
    }

    // Update is called once per frame
    void Update()
    {
        move_player();
    }

    private void move_player()
    {
        Vector2 move_direction = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            move_direction.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            move_direction.x += 1;
        }
        player_rb.linearVelocity = move_direction * movement_speed;
        //player_rb.Position += move_direction * movement_speed;
        //float inputHorizontal = Input.GetAxisRaw("Horizontal");
        //player_rb.linearVelocity = new Vector2(inputHorizontal * movementSpeed, player_rb.linearVelocityY);
    }
    public void set_texture(int health) {
        if (health == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (health == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else if (health == 3)
        {
            GetComponent<SpriteRenderer>().sprite = sprite3;
        }
    }
}
