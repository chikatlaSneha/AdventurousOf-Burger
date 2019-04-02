using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public enum StateEnum {Idel,Right,Left,Jump};
    public StateEnum PlayerState;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public bool IdelBool = false;
    public bool leftBool = false;
    public bool rightBool = false;
    public bool jumpBool = false;

    public float Speed = 15;
    public float jumpheight = 20;


    public int health;

    //Text Values
    public Text HealthAtStart;

    //Pooling and Menus
    public GameObject deathmenu;
//    public bulletpool pool;
  //  public Platformpooler platformpooler;


    //Transform
    public Transform player;

    void Start()
    {
        PlayerState = StateEnum.Idel;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerState = StateEnum.Right;
            sr.flipX = true;
            anim.SetBool("Run",rightBool);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerState = StateEnum.Left;
            sr.flipX = false;
            anim.SetBool("Run",leftBool);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerState = StateEnum.Jump;
            anim.SetBool("Jump", jumpBool);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerState = StateEnum.Idel;
            anim.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayerState = StateEnum.Idel;
            anim.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            PlayerState = StateEnum.Idel;
            anim.SetBool("Jump", jumpBool);
        }
        MoveMethod(PlayerState);
    }

    public void MoveMethod(StateEnum State)
    {
        switch (State)
        {

            case StateEnum.Idel:
                if (IdelBool == true)
                {
                    //Set to Idel Animation

                    IdelBool = false;
                }
                break;
            case StateEnum.Left:
                //if (leftBool == true)
                //{
                    transform.Translate(Vector3.left * Speed * Time.deltaTime);
                    
                //}
               leftBool = false;
                break;
            case StateEnum.Right:
                //if (rightBool == true)
                //{
                    transform.Translate(Vector3.right * Speed * Time.deltaTime);
                rightBool = false;
                //}
                break;
            case StateEnum.Jump:
                //if (jumpBool == true)
                //{
                    rb.AddForce(Vector3.up * jumpheight * Time.deltaTime);
                 jumpBool = false;
                //}
                break;


        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Destroyed"))
            {
                if (health <= 0)
                {
                    deathmenu.gameObject.SetActive(true);
                    player.gameObject.SetActive(false);
                }
                health = health - 50;
                HealthAtStart.text = health.ToString();
            }
            if (collision.gameObject.CompareTag("objdes"))
            {
                collision.gameObject.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Jump"))
            {
            transform.Translate(Vector3.up * 100 * Time.deltaTime);
            }
        }


    }
