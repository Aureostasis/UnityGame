using System;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3500f;
    public float spaceForce = 50f;
    private Camera mainCam;
    private int rollCD = 0;
    public GameObject player;
    private Rigidbody2D playerRb;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (rollCD <= 0) { 
                    Debug.Log("Pressed Spacebar");
                    rb.totalForce = new Vector2(0, 0);
                    Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 direction = (mousePos - transform.position).normalized;
                    rb.AddForce(direction * spaceForce, ForceMode2D.Impulse);
                    rollCD = 200;
                }
            }
    }

    void FixedUpdate()
    {
        rollCD -= 1;

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(new Vector2(0, speed * Time.deltaTime));  
        }
        if (Input.GetKey(KeyCode.S)){
            rb.AddForce(new Vector2(0, -speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A)){
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0)); 
        }
        if (Input.GetKey(KeyCode.D)){
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
    }
    public void TakeDmg()
    {   
        playerRb = player.GetComponent<Rigidbody2D>();
        var blastDirection = new Vector3(0, 0, 0);
        blastDirection = (rb.velocity * 5);
        blastDirection *= -1;
        Debug.Log("Touched the fireball");
        rb.AddForce(blastDirection, ForceMode2D.Impulse);
    }
}
