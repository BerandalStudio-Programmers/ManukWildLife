using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite spriteCheck1;
    public Sprite spriteCheck2;

    private SpriteRenderer checkpointSpriteRenderer;

    public bool checkpointReached;

    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = spriteCheck2;
            checkpointReached = true;
        }
    }
}
