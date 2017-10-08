using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour {
    public float speedx = 0;
    public float speedy = 0;
    public int direction = -1;
    public GameObject man;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(20, 14, 0); //-10,-1,0
        GetComponent<Animator>().SetInteger("state", 0);
        speedx = 0;
        speedy = 0;
        direction = -1;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(System.Math.Abs(transform.position.x - man.transform.position.x) <= 6 && System.Math.Abs(transform.position.y - man.transform.position.y) <= 2)
        {
            speedx = -3;
            GetComponent<Animator>().SetInteger("state", 1*direction);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedx, speedy);
        speedy--;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.name.Contains("death"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.transform.localScale.y <= 1)
        {
                speedy = 0;
        }
    }
}
