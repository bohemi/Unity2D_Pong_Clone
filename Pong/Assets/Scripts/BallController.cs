using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public static int scoreCountLeft { get; private set; }
    public static int scoreCountRight { get; private set; }

    [SerializeField] private float _horizontalSpeed = 200f;
    [SerializeField] private float _increaseSpeed; // keeps on increasing during the play
    Rigidbody2D _rigidBody = null;

    // it will change the velocity of the ball at every given value increments in total score
    [SerializeField] int _changeVelocityAtThisValue = 2;

    private void Start()
    {
        _changeVelocityAtThisValue = 4;
        scoreCountLeft = scoreCountRight = 0;
        _increaseSpeed = 0.5f;

        _rigidBody = GetComponent<Rigidbody2D>();

        Invoke("InitBall", 2.0f);
    }

    private void Update()
    {
        IncreaseBallSpeed(_increaseSpeed);
    }

    private void InitBall()
    {
        int _initialDirection = Random.Range(0, 2);

        if (_initialDirection < 1)
        {
            _rigidBody.AddForce(Vector2.right * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            _rigidBody.AddForce(Vector2.up * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            _rigidBody.velocity = new Vector2(5f, 6f);
        }
        else
        {
            _rigidBody.AddForce(Vector2.left * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            _rigidBody.AddForce(Vector2.down * _horizontalSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            _rigidBody.velocity = new Vector2(-5f, -6f);
        }
    }

    void IncreaseBallSpeed(float speed)
    {
        if (scoreCountLeft + scoreCountRight == _changeVelocityAtThisValue)
        {
            _changeVelocityAtThisValue += _changeVelocityAtThisValue;
            print(_rigidBody.velocity);
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x + (_increaseSpeed - 0.2f), _rigidBody.velocity.y + _increaseSpeed);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerLeft"))
        {
            _rigidBody.AddForce(Vector2.right * _increaseSpeed, ForceMode2D.Impulse);
            scoreCountLeft++;
        }
        else if (collision.collider.CompareTag("PlayerRight"))
        {
            _rigidBody.AddForce(Vector2.left * _increaseSpeed, ForceMode2D.Impulse);
            scoreCountRight++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HorizontalWalls"))
        {
            SceneManager.LoadSceneAsync("Play Scene");
        }
    }
}
