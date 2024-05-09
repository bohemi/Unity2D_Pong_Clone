using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private float horizontal_speed = 0.0f;
    [SerializeField] private float vertical_speed = 0.0f;
    [SerializeField] private float increase_speed = 0.2f; // keeps on increasing during the play
    Rigidbody2D rigid_body = null;
    private int initial_direction = 0;

    private void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        increase_speed = 0.2f;
        initial_direction = Random.Range(1, 3);
        Invoke("InitBall", 2.0f);
    }

    private void Update()
    {
        Debug.Log(rigid_body.velocity.x);
    }

    private void InitBall()
    {
        //rigid_body.AddForce(Vector2.right * horizontal_speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        if (initial_direction == 1)
        {
            rigid_body.AddForce(Vector2.right * horizontal_speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            rigid_body.AddForce(Vector2.up * horizontal_speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        if (initial_direction == 2)
        {
            rigid_body.AddForce(Vector2.left * horizontal_speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            rigid_body.AddForce(Vector2.down * horizontal_speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("right bat");
            rigid_body.AddForce(Vector2.right * increase_speed, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            //Debug.Log("Left bat");
            rigid_body.AddForce(Vector2.left * increase_speed, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "Walls")
            SceneManager.LoadSceneAsync("Play Scene");
            Debug.Log("game Over");
    }
}
