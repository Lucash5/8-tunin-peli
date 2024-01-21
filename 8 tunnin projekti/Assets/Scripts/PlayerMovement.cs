using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public TMP_Text text;
    Animator anim;
    bool abletoattack = true;
    Rigidbody2D rb;
    public int speed;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        

        anim.SetFloat("x", Input.GetAxisRaw("Horizontal")* Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("y", Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Horizontal") != 0)
        {

        transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal") * 10, transform.localScale.y, transform.localScale.z);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Enemy" && abletoattack == true && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(swing());
            collision.gameObject.GetComponent<SlimeAI>().takingdamage(damage, gameObject);
           
        }
    }
    



    IEnumerator swing()
    {
        yield return new WaitForSeconds(0.1f);
        abletoattack = false;
        yield return new WaitForSeconds(1.5f);
        abletoattack = true;
    }
    int number = 5;
    public void changeobjective()
    {
        number -= 1;
        int x = 5 - number;
        text.text = x.ToString() + "/5";
    }

}
