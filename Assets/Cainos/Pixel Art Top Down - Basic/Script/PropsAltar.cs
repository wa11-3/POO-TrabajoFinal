﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsAltar : MonoBehaviour
{
    public static event Action altarEvent;


    public List<SpriteRenderer> runes;
    public float lerpSpeed;

    private Color curColor;
    private Color targetColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 1);
        if (other.CompareTag("Statue"))
        {
            altarEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 0);
    }

    private void Update()
    {
        curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

        foreach (var r in runes)
        {
            r.color = curColor;
        }
    }
}
