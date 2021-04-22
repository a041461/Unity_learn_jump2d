using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite[] mysprites;
    public GameObject[] flame;
    public float[] itemPower;
    int typeofItem;
    GameObject player;
    bool fly = false;
    public GameManager GM;


    // Start is called before the first frame update
    void Start()
    {
        typeofItem = int.Parse(this.tag.Replace("ItemType", ""));
        this.GetComponent<SpriteRenderer>().sprite = mysprites[typeofItem];
    }

    // Update is called once per frame
    void Update()
    {
        if (fly)
        {
            player.transform.Translate(new Vector2(0,12*Time.deltaTime));
        }

        else if (GM.floor.transform.position.y > this.transform.position.y + 1)
        {
            GM.addInactiveItems(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player")){
            switch (typeofItem)
            {
                case 2:
                    //todo 添加金币分数
                    GM.score += 20;
                    GM.addInactiveItems(this.gameObject);
                    break;
                case 0:
                case 1:
                    player = collision.gameObject;
                    player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    fly = true;
                    player.GetComponent<Rigidbody2D>().isKinematic = true;
                    player.GetComponent<Collider2D>().enabled = false;
                    flame[typeofItem].SetActive(true);
                    this.GetComponent<SpriteRenderer>().enabled = false;
                    //stopFly();
                    break;



            }
        }
    }

    IEnumerator stopFly()
    {
        yield return new WaitForSeconds(itemPower[typeofItem]);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<Collider2D>().enabled = true;
        fly = false;
        flame[typeofItem].SetActive(false);
    }

}
