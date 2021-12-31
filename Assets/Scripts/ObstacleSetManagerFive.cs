using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetManagerFive : MonoBehaviour
{
    public GameObject observer;
    public GameObject player;
    bool observerIsActive = true;
    float observerCD = 2f;
    float timer = 0;

    private void Update()
    {
        if (observerIsActive)
        {
            observer.SetActive(true);
        } else
        {
            observer.SetActive(false);
        }

        if (timer >= observerCD)
        {
            timer = 0;
            observerIsActive = !observerIsActive;
        }

        timer += Time.fixedDeltaTime;

        CheckVisibility();
    }

    private void CheckVisibility()
    {
        if (observer.activeSelf && player.transform.GetComponent<SpriteRenderer>().sortingOrder > 0)
        {
            for (int i = 1; i <= 6; i++)
            {
                transform.Find("grass").gameObject.tag = "Enemy";
            }
        }
        else
        {
            for (int i = 1; i <= 6; i++)
            {
                transform.Find("grass").gameObject.tag = "Untagged";
            }
        }
    }
}
