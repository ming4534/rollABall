using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public Text countText;
    // public Text winText;
    private Rigidbody rb;
    private Vector3 jump;
    public float jumpForce = 20.0f;
    public bool isGrounded;
    private int count;
    public Transform respawn_point;
    public Vector3 playerRespawn;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        count = 0;
        SetCountText ();
        // winText.text = "";
        playerRespawn = transform.position;
    }
     void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement* speed);
    }
     void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (transform.position.y <= -5){
            transform.position = playerRespawn;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
        }
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
            }
        }
        void SetCountText (){
          countText.text = "Count: " + count.ToString ();
        }
        // if (count >= 12){
        //     winText.text = "You Win";
        // }
    // }
}
