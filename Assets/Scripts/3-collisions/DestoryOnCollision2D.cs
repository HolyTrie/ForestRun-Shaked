﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestoryOnCollision2D : MonoBehaviour
{
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag +" ," + triggeringTag);
        if (other.tag == triggeringTag)
        {
            Destroy(other.gameObject);
        }
    }
}