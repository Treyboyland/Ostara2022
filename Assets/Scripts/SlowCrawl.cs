using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCrawl : MonoBehaviour
{
    [SerializeField]
    float secondsBetweenMoves;

    [SerializeField]
    float secondsPerMove;

    static Player player;

    void FindPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Crawl());
        }
    }

    Vector3 GetNextPosition()
    {
        Vector3 nextPos = transform.position;
        if (player == null)
        {
            if (Random.Range(0.0f, 1.0f) < .5f)
            {
                nextPos.x += Random.Range(0.0f, 1.0f) < .5f ? 1 : -1;
            }
            else
            {
                nextPos.y += Random.Range(0.0f, 1.0f) < .5f ? 1 : -1;
            }
        }
        else
        {
            float xdiff, ydiff;
            xdiff = Mathf.Abs(player.transform.position.x - transform.position.x);
            ydiff = Mathf.Abs(player.transform.position.y - transform.position.y);

            if (xdiff > ydiff)
            {
                nextPos.x += player.transform.position.x < transform.position.x ? -1 : 1;
            }
            else
            {
                nextPos.y += player.transform.position.y < transform.position.y ? -1 : 1;

            }
        }

        return nextPos;
    }

    IEnumerator Crawl()
    {
        FindPlayer();
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenMoves);
            FindPlayer();
            Vector3 nextPos = GetNextPosition(), startPos = transform.position;


            float elapsed = 0;

            while (elapsed < secondsPerMove)
            {
                elapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, nextPos, elapsed / secondsPerMove);
                yield return null;
            }

            transform.position = nextPos;

            yield return null;
        }
    }
}

