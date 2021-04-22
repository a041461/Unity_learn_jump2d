using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 StartPosition;
    public Sprite[] mysprites;
    
    private int typeofEnemy;

    public float[] enemySpeed;
    public float[] enemyDistance;

    float speed;
    float distance;

    int direction = 1;

    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        typeofEnemy = int.Parse(this.tag.Replace("EnemyType",""));
        this.GetComponent<SpriteRenderer>().sprite = mysprites[typeofEnemy];
        speed = enemySpeed[typeofEnemy];
        distance = enemyDistance[typeofEnemy];       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-direction * speed * Time.deltaTime, 0, 0));
        if (((StartPosition - this.transform.position).x * direction) > distance)
        {
            typeofEnemy = typeofEnemy + direction * 3;
            direction = -direction;
            this.GetComponent<SpriteRenderer>().sprite = mysprites[typeofEnemy];
        }
        if (GM.floor.transform.position.y > this.transform.position.y + 1)
        {
            GM.addInactiveEnemy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player"))
        {
            //collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //collision.GetComponent<Rigidbody2D>().gravityScale = 3;
            //collision.GetComponent<Collider2D>().enabled = false;
            GM.endGame();
        }
    }
}
