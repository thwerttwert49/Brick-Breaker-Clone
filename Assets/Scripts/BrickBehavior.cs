using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    //[SerializeField]
    private int health = 1;
    private int brick_type;
    private Rigidbody2D brick_rb;

    private GameBehavior game_behavior;
    private LevelBehavior level_behavior;

    [SerializeField] private GameObject falling_object_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        brick_type = Random.Range(1, 4);
        if (brick_type == 1) {
            health = Random.Range(1, 4);
        }
        game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
        brick_rb = GetComponent<Rigidbody2D>();
    }
    private void destroy_brick() {
        game_behavior.add_score(50);
        if (brick_type == 2) {
            GameObject ball = GameObject.Find("Ball");
            BallBehavior ball_behavior = ball.GetComponent<BallBehavior>();
            ball_behavior.powerup();
        }else if (brick_type == 3) {
            Instantiate(falling_object_prefab, transform.position, transform.rotation);
        }

        level_behavior = GameObject.Find("LevelScript").GetComponent<LevelBehavior>();
        level_behavior.on_brick_destroyed();
        Destroy(gameObject);
    }
    public void damage_brick(int dmg) {
        health -= dmg;
        if (health <= 0) {
            destroy_brick();
        }
    }
}
