using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    public float maxrange;
    public float range;
    public float health;
    bool lockedonplayer;
    bool timetoswitch  = true;
    public Transform player;
    Rigidbody2D rb;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timetoswitch == true)
        {
            timetoswitch = false;
            StartCoroutine(shiftnumbers());
        }


        if (lockedonplayer == false)
        {
        rb.velocity = new Vector2(x, y);
        }
        else
        {
            Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);


            transform.up = direction;
            rb.velocity = transform.up * 1;

        }


        if (Mathf.Sqrt((((transform.position.x - player.position.x)* (transform.position.x - player.position.x)) + ((transform.position.y - player.position.y)* (transform.position.y - player.position.y)))) < range)
        {
            
            lockedonplayer = true;
        }

        if (lockedonplayer && Mathf.Sqrt((((transform.position.x - player.position.x) * (transform.position.x - player.position.x)) + ((transform.position.y - player.position.y) * (transform.position.y - player.position.y)))) > maxrange)
        {
            lockedonplayer = false;
        }
  
    }

    IEnumerator shiftnumbers()
    {
       
        x = Random.Range(-0.3f, 0.3f);
        y = Random.Range(-0.3f, 0.3f);
        yield return new WaitForSeconds(4);
        timetoswitch = true;

    }

    public void takingdamage(float damage, GameObject player)
    {
        health -= damage;
        Debug.Log(health);

        if (health <= 0)
        {
            player.GetComponent<PlayerMovement>().changeobjective();
            Destroy(gameObject);
        }
    }


}
