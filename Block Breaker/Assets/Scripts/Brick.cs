using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crackSounds;
    public Sprite[] hitSprites;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;

    private bool isBreakable;

    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();

        isBreakable = tag == "Breakble";
        if (isBreakable)
        {
            LevelManager.BreakableBrickCount++;

            print("breakableCount :" + LevelManager.BreakableBrickCount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;

        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            PlayBreakSound();
            PlayPuffSmoke();
            CheckNeedGotoNextLevel();
            Destroy(gameObject);
        }
        else
        {
            LoadSprite();
        }
    }

    private void PlayBreakSound()
    {
        if (crackSounds != null)
        {
            AudioSource.PlayClipAtPoint(crackSounds, transform.position, 0.8f);
        }
    }

    private void PlayPuffSmoke()
    {
        if (smoke != null)
        {
            var smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
            var particleSystem = smokePuff.GetComponent<ParticleSystem>().main;
            particleSystem.startColor = GetComponent<SpriteRenderer>().color;
        }
    }

    private void CheckNeedGotoNextLevel()
    {
        LevelManager.BreakableBrickCount--;
        if (LevelManager.BreakableBrickCount <= 0)
        {
            levelManager.LoadNextLevel();
        }
    }

    private void LoadSprite()
    {
        if (hitSprites == null || hitSprites.Length < timesHit)
        {
            return;
        }

        int hitSpritIndex = timesHit - 1;
        var hitSprite = hitSprites[hitSpritIndex];
        if (hitSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite;
        }
        else
        {
            Debug.LogError("brick missing sprite");
        }
    }
}
