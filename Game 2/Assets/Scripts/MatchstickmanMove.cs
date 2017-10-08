using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchstickmanMove : MonoBehaviour {
    public float speedx = 0;
    public float speedy = 0;
    public int direction = 1;
    public bool oncollide = false;
    public int onwall = 0;
    public bool gameover = false;
    public bool complete = false;
    public GameObject restart;
    public GameObject background;
    public GameObject menubutton;
    public GameObject nextlevel;
    public Text text;
    void Start()
    {
        text.text = "";
        menubutton.SetActive(false);
        nextlevel.SetActive(false);
        transform.position = new Vector3(-10, -1, 0); //-10,-1,0
        GetComponent<Animator>().SetInteger("state", 0);
        speedx = 0;
        speedy = 0;
        direction = 1;
        oncollide = false;
        onwall = 0;
        gameover = false;
        complete = false;
        restart.SetActive(false);
        background.SetActive(false);
    }
    void FixedUpdate()
    {
        if (!gameover)
        {
            if (Input.GetKey(KeyCode.W) && oncollide == true)
            {
                GetComponent<Animator>().SetInteger("state", 2 * direction);
                speedy = 12;
            }
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                direction = -1;
                speedx = 3 * direction;
                if (oncollide == true)
                {
                    GetComponent<Animator>().SetInteger("state", 1 * direction);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    GetComponent<Animator>().SetInteger("state", 3 * direction);
                    GetComponent<BoxCollider2D>().size = new Vector2(1, 0.5f);
                    GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.25f);
                }
                else
                {
                    GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 1);
                    GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
                }
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                direction = 1;
                speedx = 3 * direction;
                if (oncollide == true)
                {
                    GetComponent<Animator>().SetInteger("state", 1 * direction);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    GetComponent<Animator>().SetInteger("state", 3 * direction);
                    GetComponent<BoxCollider2D>().size = new Vector2(1, 0.5f);
                    GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.25f);
                }
                else
                {
                    GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 1);
                    GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
                }
            }
            if ((!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.D)))
            {
                speedx = 0;
            }
            if (speedx == 0 && oncollide == true)
            {
                GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 1);
                GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
                GetComponent<Animator>().SetInteger("state", 0);
            }
            if (oncollide == false)
            {
                speedy--;
            }
            if (onwall == 1)
            {
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
                {
                    speedy = 12;
                    GetComponent<Animator>().SetInteger("state", 2 * direction);
                }
            }
            if (onwall == -1)
            {
                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
                {
                    speedy = 12;
                    GetComponent<Animator>().SetInteger("state", 2 * direction);
                }
            }
            if (speedy <= -50)
            {
                gameover = true;
            }
        }
        else
        {
            speedx = 0;
            speedy = 0;
            if (!complete)
            {
                GetComponent<Animator>().SetInteger("state", 10);
                text.text = "You Died.";
                restart.SetActive(true);
            }
            else
            {
                text.text = "Congratulations.";
                nextlevel.SetActive(true);
                GetComponent<Animator>().SetInteger("state", 0);
            }
            menubutton.SetActive(true);
            background.SetActive(true);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedx, speedy);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (gameover == false)
        {
            if (collision.gameObject.transform.name.Contains("death"))
            {
                gameover = true;
            }
            if (collision.gameObject.transform.localScale.y <= 1)
            {
                oncollide = true;
                speedy = 0;
            }
            if (collision.gameObject.transform.localScale.x <= 1)
            {
                if (collision.gameObject.transform.position.x >= transform.position.x)
                {
                    onwall = 1;
                    GetComponent<Animator>().SetInteger("state", 4);
                }
                else
                {
                    onwall = -1;
                    GetComponent<Animator>().SetInteger("state", -4);
                }
                speedy = 0;
            }
            if(collision.gameObject.name == "finish")
            {
                complete = true;
                gameover = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        oncollide = false;
        onwall = 0;
    }
}
