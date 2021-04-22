using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject defaultTile = null;
    public GameObject defaultEnemy = null;
    public GameObject defaultItem = null;
    public int initialSize = 40;
    public GameSettings gameSettings;
    float totalWeight;
    float currentPosition = -3f;
    public float ScreenDistance;
    public GameObject floor;
    public int score;
    Vector3 initCameraPosition;
    public bool isGamePaused = true;
    public bool isGameOver;
    public GUIControl gui;
    public GUIText scoretext;


    Queue<GameObject> tilePool = new Queue<GameObject>();
    Queue<GameObject> enemyPool = new Queue<GameObject>();
    Queue<GameObject> itemPool = new Queue<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        getTotalProbabilityWeight();
        GenerateTilePool();
        GenerateEnemyPool();
        GenerateItemPool();
        for (int i = 0; i < initialSize; i++)
        {
            GenerateTile();
            GenerateEnemy();
            GenerateItem();
        }
        pauseGame();
        initCameraPosition = Camera.main.transform.position;

    }

    public void pauseGame()
    {
        isGamePaused = true;
    }

    public void resumeGame()
    {
        isGamePaused = false;
    }

    public void endGame() {
        isGameOver = true;
        
        Camera.main.transform.position = initCameraPosition;
        gui.ShowGameOverPanel();

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = score.ToString();
    }

    void getTotalProbabilityWeight()
    {
        float sum = 0;
        sum += gameSettings.normalTiles.probabilityweight;
        sum += gameSettings.brokenTiles.probabilityweight;
        sum += gameSettings.onetimeonlyTiles.probabilityweight;
        sum += gameSettings.springTiles.probabilityweight;
        sum += gameSettings.movingTileHorizontal.probabilityweight;
        sum += gameSettings.movingTileVertucal.probabilityweight;
        totalWeight = sum;
    }

    public GameObject getInactiveTile() => tilePool.Dequeue();

    public GameObject getInactiveEnemy() => enemyPool.Dequeue();

    public GameObject getInactiveItem() => itemPool.Dequeue();

    void GenerateTile()
    {
        GameObject go = getInactiveTile();
        float rand = Random.Range(0,totalWeight);
        int randomNumber =GetTileBaseOnRandomNumber(rand);

        Vector2 tmpPos = new Vector2(Random.Range(-ScreenDistance,ScreenDistance),currentPosition);
        switch (randomNumber)
        {
            case 0:
                go.transform.position = tmpPos;
                currentPosition += Random.Range(gameSettings.normalTiles.minHeightBetweenTiles,gameSettings.normalTiles.maxHerghtBetweenTiles);
                go.tag = "TileType0";
                go.SetActive(true);
                break;
            case 1:
                go.transform.position = tmpPos;
                currentPosition += Random.Range(gameSettings.brokenTiles.minHeightBetweenTiles, gameSettings.brokenTiles.maxHerghtBetweenTiles);
                go.tag = "TileType1";
                go.SetActive(true);
                break;
            case 2:
                go.transform.position = tmpPos;
                currentPosition += Random.Range(gameSettings.onetimeonlyTiles.minHeightBetweenTiles, gameSettings.onetimeonlyTiles.maxHerghtBetweenTiles);
                go.tag = "TileType2";
                go.SetActive(true);
                break;
            case 3:
                go.transform.position = tmpPos;
                currentPosition += Random.Range(gameSettings.springTiles.minHeightBetweenTiles, gameSettings.springTiles.maxHerghtBetweenTiles);
                go.tag = "TileType3";
                go.SetActive(true);
                break;
            case 4:
                go.transform.position = tmpPos;
                currentPosition += Random.Range(gameSettings.movingTileHorizontal.minHeightBetweenTiles, gameSettings.movingTileHorizontal.maxHerghtBetweenTiles);
                go.tag = "TileType4";
                go.SetActive(true);
                break;
            case 5:
                go.transform.position = tmpPos;
                currentPosition += Random.Range(gameSettings.movingTileVertucal.minHeightBetweenTiles, gameSettings.movingTileVertucal.maxHerghtBetweenTiles);
                go.tag = "TileType5";
                go.SetActive(true);
                break;
        }

    }

    void GenerateEnemy()
    {
        float rand = Random.Range(0f, 1f);
        Vector2 tmpPos = new Vector2(Random.Range(-ScreenDistance, ScreenDistance), currentPosition);
        if (rand < gameSettings.enemyProbability)
        {
            GameObject go = getInactiveEnemy();
            go.tag = "EnemyType" + Random.Range(0,3);
            go.transform.position = tmpPos;
            go.SetActive(true);
        }
    }

    void GenerateItem()
    {
        float rand = Random.Range(0f, 1f);
        Vector2 tmpPos = new Vector2(Random.Range(-ScreenDistance, ScreenDistance), currentPosition);
        if (rand < gameSettings.itemAppearProbability)
        {
            GameObject go = getInactiveItem();
            go.tag = "ItemType" + Random.Range(0, 3);
            go.transform.position = tmpPos;
            go.SetActive(true);
        }
    }

    public int GetTileBaseOnRandomNumber(float randomNumber)
    {
       
        return Random.Range(0,6);
    }

    private void GenerateTilePool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject go = GameObject.Instantiate(defaultTile, Vector3.zero, Quaternion.identity);
            go.SetActive(false);
            go.name = "Tile" + i;
            tilePool.Enqueue(go);
        }
    }

    private void GenerateEnemyPool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject go = GameObject.Instantiate(defaultEnemy, Vector3.zero, Quaternion.identity);
            go.SetActive(false);
            go.name = "Enemy" + i;
            enemyPool.Enqueue(go);
        }
    }

    private void GenerateItemPool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject go = GameObject.Instantiate(defaultItem, Vector3.zero, Quaternion.identity);
            go.SetActive(false);
            go.name = "Item" + i;
            itemPool.Enqueue(go);
        }
    }

    public void addInactiveItems(GameObject inactiveItem)
    {
        inactiveItem.SetActive(false);
        itemPool.Enqueue(inactiveItem);
        GenerateItem();
       
    }

    public void addInactiveEnemy(GameObject inactiveItem)
    {
        inactiveItem.SetActive(false);
        enemyPool.Enqueue(inactiveItem);
        GenerateEnemy();
    }

    public void addInactiveTile(GameObject inactiveItem)
    {
        inactiveItem.SetActive(false);
        tilePool.Enqueue(inactiveItem);
        GenerateTile();
        score += 5;
    }


}
