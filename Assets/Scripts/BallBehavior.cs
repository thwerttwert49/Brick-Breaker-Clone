using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody2D ball_rb;
    [SerializeField]
    private float ball_speed;
    private Vector2 ball_start_position;
    [SerializeField] private bool is_clone;
    private GameBehavior game_behavior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball_rb = GetComponent<Rigidbody2D>();
        ball_start_position = ball_rb.position;
        ball_rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), -ball_speed);
        game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        ball_rb.linearVelocity = ball_rb.linearVelocity.normalized * ball_speed; //keep the ball at a constant speed
        if (ball_rb.linearVelocity.y < 0.01 && ball_rb.linearVelocity.y > -0.01) {
            ball_rb.linearVelocity = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); //in case ball gets stuck with no y velocity, it give it random velocity
        }
        if (ball_rb.linearVelocity.x < 0.01 && ball_rb.linearVelocity.x > -0.01) {
            ball_rb.linearVelocity = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); //in case ball gets stuck with no x velocity
        }
        if (ball_rb.position.y < -5) {
            if (is_clone == false)
            {
                ball_rb.position = ball_start_position;
                game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
                game_behavior.lose_life();
            } else {
                Destroy(gameObject);
            }
        }
        if (transform.localScale.x > 0.6) {
            transform.localScale -= new Vector3(0.0001f, 0.0001f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Brick"))
        {
            //Debug.Log("Collided with a brick");
            BrickBehavior brick = collision.gameObject.GetComponent<BrickBehavior>();
            brick.damage_brick(1);
        }
    }
    public void powerup() {
        transform.localScale += new Vector3(0.3f, 0.3f, 0f);
    }
}
