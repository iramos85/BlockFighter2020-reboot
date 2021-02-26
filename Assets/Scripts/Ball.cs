using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;


    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    //bool bounceAction = false;

    //cache references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
      /*  if (bounceAction == true)
        {
            LaunchBallAction();
        }
      */
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = paddle1.transform.position;
        transform.position = paddlePos + paddleToBallVector;
    }

    /*   private void OnTriggerEnter2D(Collider2D collision)
       {
           bounceAction = true;
           Debug.Log("collision");   
       }

       private void LaunchBallAction()
       {
           if (Input.GetMouseButtonDown(0))
           {
               GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 15f);
               Debug.Log("bounce");
           }
       }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            myAudioSource.Play();
            myRigidBody2D.velocity += velocityTweak;
        }
    }

}
