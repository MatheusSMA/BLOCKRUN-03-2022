using UnityEngine;
using UnityEngine.UI;

//TODO: Make legs for cube? 🆗
//TODO: Decide Gamestyle

public class PlayerController : MonoBehaviour
{
    //! First time using Singleton!
    public static PlayerController Instance { get; private set; }

    //* ----- Moviment Inputs -----
    private float xMove, zMove;

    //* ----- Moviment Variables -----    
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpHeight;

    private bool grounded;

    //* ----- Player References -----    
    private Rigidbody rbPlayer;
    public GameObject startLevelPosition;

    public Animator animPlayer;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MyInputs();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void MyInputs()
    {
        xMove = Input.GetAxis("Horizontal") * speed;
        zMove = Input.GetAxis("Vertical") * speed;
    }

    private void Move()
    {
        Vector3 move = new Vector3(xMove, rbPlayer.velocity.y, zMove);
        rbPlayer.velocity = move;


        if (move.z != 0 || move.x != 0)
            animPlayer.SetBool("move", true);
        else
        {
            if (move.x == 0 || move.z == 0)
                animPlayer.SetBool("move", false);
        }
    }

    private void Jump()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rbPlayer.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
    public void Run()
    {
        speed = 8f;
        rbPlayer.freezeRotation = false;
    }
    public void StopRun()
    {
        speed = 12f;
        rbPlayer.freezeRotation = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            transform.position = startLevelPosition.transform.position;
        }
    }
}


