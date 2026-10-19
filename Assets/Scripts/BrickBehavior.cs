using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    //[SerializeField]
    private int health = 1;
    private int brick_type;
    private Rigidbody2D brick_rb;

    private GameBehavior game_behavior;
    private LevelBehavior level_behavior;

    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;

    [SerializeField] private GameObject falling_object_prefab;
    [SerializeField] private GameObject ball_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        brick_type = Random.Range(1, 5);
        if (brick_type == 1)
        {
            health = Random.Range(1, 4);
        }
        else if (brick_type == 3)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 153, 153, 255); ;
        }
        else if (brick_type == 4)
        {
            GetComponent<SpriteRenderer>().color = new Color32(182, 255, 255, 255); ;
        }

        game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
        brick_rb = GetComponent<Rigidbody2D>();
        set_texture();
    }
    private void set_texture() {
        if (brick_type == 1)
        {
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
        else if (brick_type == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite4;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprite3;
        }
    }
    private void destroy_brick() {
        game_behavior.add_score(50);
        if (brick_type == 2)
        {
            GameObject ball = GameObject.Find("Ball");
            BallBehavior ball_behavior = ball.GetComponent<BallBehavior>();
            ball_behavior.powerup();
        }
        else if (brick_type == 3)
        {
            Instantiate(falling_object_prefab, transform.position, transform.rotation);
        }
        else if (brick_type == 4)
        {
            GameObject new_ball = Instantiate(ball_prefab, transform.position, transform.rotation);
            Rigidbody2D ball_rb = new_ball.GetComponent<Rigidbody2D>();
            ball_rb.linearVelocity = new Vector2(0, -5f);
        }

        level_behavior = GameObject.Find("LevelScript").GetComponent<LevelBehavior>();
        level_behavior.on_brick_destroyed();
        Destroy(gameObject);
    }
    public void damage_brick(int dmg) {
        health -= dmg;
        set_texture();
        if (health <= 0) {
            destroy_brick();
        }
    }
}
