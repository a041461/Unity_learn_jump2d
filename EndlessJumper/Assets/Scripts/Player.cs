using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 acc;
    float leftBorder;
    float rightBorder;
    SpriteRenderer thisRender;
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        thisRender = this.GetComponent<SpriteRenderer>();
        Vector3 playerSize = this.GetComponent<Renderer>().bounds.size;
        float distance = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x - (playerSize.x / 2);
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x + (playerSize.x / 2);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            acc.x = -0.1f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            acc.x = 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            acc.x = 0;
        }
        Vector3 diff = Vector3.MoveTowards(this.transform.localPosition, this.transform.localPosition + acc, (0.5f * Time.time));
        diff.y = this.transform.localPosition.y;
        diff.z = 0f;
        if (diff.x < leftBorder)
        {
            diff.x = rightBorder;
        }
        if(diff.x > rightBorder)
        {
            diff.x = leftBorder;
        }

        this.transform.localPosition = diff;
    }

    void jump(float x)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,12f*x),ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("platform") || collision.tag.Contains("Tile"))
        {
            jump(1);
        }
        else if (collision.name.Contains("floor")&&this.transform.position.y<collision.transform.position.y+1)
        {
            GM.endGame();
        }
    }


}
