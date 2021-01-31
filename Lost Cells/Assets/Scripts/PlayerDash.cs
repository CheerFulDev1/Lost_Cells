using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D myRb;
    private Animator playerAnim;
    private float dashSpeed = 10;
    private bool hasEye = false;

    public GameObject dashEffect;
    public GameObject portal;
    public GameObject cella;
    

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
            if (!hasEye)
            {
                playerAnim.SetTrigger("dashTrig");
            }
            else
            {
                playerAnim.SetBool("hasEye", true);
                playerAnim.SetTrigger("dashTrig");
            }
            
                myRb.velocity = Vector2.left * dashSpeed;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
                Instantiate(dashEffect, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180));

        }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
            if (!hasEye)
            {
                playerAnim.SetTrigger("dashTrig");
            }
            else
            {
                playerAnim.SetBool("hasEye", true);
                playerAnim.SetTrigger("dashTrig");
            }
                myRb.velocity = Vector2.right * dashSpeed;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
                Instantiate(dashEffect, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0));
        }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRb.velocity = Vector2.up * dashSpeed;
            if (!hasEye)
            {
                playerAnim.SetTrigger("dashTrig");
            }
            else
            {
                playerAnim.SetBool("hasEye", true);
                playerAnim.SetTrigger("dashTrig");
            }
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
                Instantiate(dashEffect, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90));
        }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                myRb.velocity = Vector2.down * dashSpeed;
            if (!hasEye)
            {
                playerAnim.SetTrigger("dashTrig");
            }
            else
            {
                playerAnim.SetBool("hasEye", true);
                playerAnim.SetTrigger("dashTrig");
            }
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
                Instantiate(dashEffect, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EvilGround")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.tag == "Item")
        {
            hasEye = true;
            GameObject myEye = GameObject.FindGameObjectWithTag("Item");
            myEye.SetActive(false);
            portal.SetActive(true);
        }

        if(collision.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(collision.tag == "Heart")
        {
            GameObject myHeart = GameObject.FindGameObjectWithTag("Heart");
            myHeart.SetActive(false);
            cella.SetActive(true);

        }

        if(collision.tag == "Cella")
        {
            SceneManager.LoadScene("Game_Over");
        }


    }
}
