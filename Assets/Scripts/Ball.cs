using UnityEngine;

public class Ball : MonoBehaviour{

    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;
    Vector3 paddleToBallVector;
    Rigidbody2D myRigidbody2D;
    bool hasStarted = false;


    void Start(){
        paddleToBallVector = transform.position - paddle.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (!hasStarted)
        {
            lockBallToPaddle();
            launchBallOnClick();
        }
    }

    public void launchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }
    public void lockBallToPaddle()
    {
        Vector3 paddlePos = new Vector3(paddle.transform.position.x, paddle.transform.position.y, paddle.transform.position.z);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor), Random.Range(0f,randomFactor));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
