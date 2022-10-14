using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    const float PLAYER_DISTANCE_SPAWN_lEVEL_PART = 30f;
    const float PLAYER_DISTANCE_LEVEL_REMOVE = 28f;
    Vector3 lastEndPosition;
    GameObject partToRemove;

    [SerializeField] Transform levelPart_Start;
    [SerializeField] GameObject[] levelPartList;
    [SerializeField] GameObject player;


    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPoint").position;
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_lEVEL_PART)
        {
            SpawnLevelPart();
        }
        //else if (Vector3.Distance(player.transform.position, partToRemove.transform.position) > PLAYER_DISTANCE_LEVEL_REMOVE)
        //{
        //    Debug.Log("Remove");
        //    Destroy(partToRemove);
        //}
    }

    void SpawnLevelPart()
    {
        GameObject _randomLevelPart = levelPartList[Random.Range(0, levelPartList.Length)];
        Transform _lastLevelTransform = SpawnLevelPart(_randomLevelPart.transform,lastEndPosition);
        lastEndPosition = _lastLevelTransform.Find("EndPoint").position;
        partToRemove = _randomLevelPart;

    }
    
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}

