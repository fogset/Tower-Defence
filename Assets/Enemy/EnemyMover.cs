﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    List<Tile> path = new List<Tile>();

    [SerializeField]
    [Range(0f, 5f)]
    float speed = 1f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject tile in tiles)
        {
            Tile waypoint = tile.GetComponent<Tile>();

            if (waypoint != null)
            {
                path.Add (waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach (Tile waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt (endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position =
                    Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
