using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Sprite[] mySprites;

    int tileType;
    Vector3 startPosition;
    float distance;
    float speed;
    int direction = 1;
    public GameManager GM;


    private void OnEnable()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (this.tag == "TileType" + i)
            {
                tileType = i;
                mySpriteRenderer.sprite = mySprites[i];
                break;
            }
        }
        switch (tileType)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                startPosition = this.transform.position;
                distance = GM.gameSettings.movingTileHorizontal.distance;
                speed = GM.gameSettings.movingTileHorizontal.distance;
                break;
            case 5:
                startPosition = this.transform.position;
                distance = GM.gameSettings.movingTileVertucal.distance;
                speed = GM.gameSettings.movingTileVertucal.distance;
                break;


        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (tileType)
        {
            case 4:
                transform.Translate(new Vector3(-direction * speed * Time.deltaTime, 0, 0));
                if (((startPosition - this.transform.position).x * direction) > distance)
                {
                    direction = -direction;
                }


                break;
            case 5:
                transform.Translate(new Vector3(0, -direction * speed * Time.deltaTime, 0));
                if (((startPosition - this.transform.position).y * direction) > distance)
                {
                    direction = -direction;
                }
                break;

        }
        if (GM.floor.transform.position.y > this.transform.position.y + 1)
        {
            GM.addInactiveTile(this.gameObject);
        }

    }
}
