using System;



[Serializable]
public class GameSettings
{
    [Serializable]
    public class NormalTile
    {
        public float probabilityweight;
        public float minHeightBetweenTiles;
        public float maxHerghtBetweenTiles;
    }
    [Serializable]
    public class BrokenTile
    {
        public float probabilityweight;
        public float minHeightBetweenTiles;
        public float maxHerghtBetweenTiles;
    }
    [Serializable]
    public class OneTimeOnly
    {
        public float probabilityweight;
        public float minHeightBetweenTiles;
        public float maxHerghtBetweenTiles;
    }
    [Serializable]
    public class SpringTile
    {
        public float probabilityweight;
        public float jumpForces;
        public float minHeightBetweenTiles;
        public float maxHerghtBetweenTiles;
    }
    [Serializable]
    public class MovingTileHorizontal
    {
        public float probabilityweight;
        public float speed;
        public float distance;
        public float minHeightBetweenTiles;
        public float maxHerghtBetweenTiles;
    }
    [Serializable]
    public class MovingTileVertucal
    {
        public float probabilityweight;
        public float speed;
        public float distance;
        public float minHeightBetweenTiles;
        public float maxHerghtBetweenTiles;
    }
    public NormalTile normalTiles;
    public BrokenTile brokenTiles;
    public OneTimeOnly onetimeonlyTiles;
    public SpringTile springTiles;
    public MovingTileHorizontal movingTileHorizontal;
    public MovingTileVertucal movingTileVertucal;
    public float itemAppearProbability;
    public float enemyProbability;



}
