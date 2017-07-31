using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    public float spawnDelay = 0.5f;

    private bool isMoveRight = false;
    private float xmin;
    private float xmax;

    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        var leftMostPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMostPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftMostPoint.x + width * 0.5f;
        xmax = rightMostPoint.x - width * 0.5f;

        SpawnUntilFull();
    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x;
        if (isMoveRight)
        {
            newX = (transform.position + Vector3.right * speed * Time.deltaTime).x;
        }
        else
        {
            newX = (transform.position + Vector3.left * speed * Time.deltaTime).x;
        }

        transform.position = new Vector3(Mathf.Clamp(newX, xmin, xmax), transform.position.y, transform.position.z);

        if (newX >= xmax || newX <= xmin)
        {
            isMoveRight = !isMoveRight;
        }

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
    }

    private Transform NextFreePosition()
    {
        foreach (Transform positionGameObject in transform)
        {
            if (positionGameObject.childCount <= 0)
            {
                return positionGameObject;
            }
        }

        return null;
    }

    private void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition == null)
        {
            return;
        }

        SpawnEnemy(freePosition);

        Invoke("SpawnUntilFull", spawnDelay);
    }

    private void SpawnEnemy(Transform parent)
    {
        var enemy = Instantiate(enemyPrefab, parent.position, Quaternion.identity);
        enemy.transform.parent = parent;
    }

    private bool AllMembersDead()
    {
        foreach (Transform positionGameObject in transform)
        {
            if (positionGameObject.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
