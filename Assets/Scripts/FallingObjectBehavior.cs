using UnityEngine;

public class FallingObjectBehavior : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private GameBehavior game_behavior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Brick"))
        {
            //Debug.Log("Collided with a brick");
            BrickBehavior brick = collision.gameObject.GetComponent<BrickBehavior>();
            brick.damage_brick(1);
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Player")) {
            game_behavior = GameObject.Find("GameMain").GetComponent<GameBehavior>();
            game_behavior.lose_life();
            Destroy(gameObject);
        }
    }
}
