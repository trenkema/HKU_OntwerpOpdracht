using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreObject : MonoBehaviour
{
    private GameObject ignoreObject;

    private void OnEnable()
    {
        EventSystemNew.Subscribe(Event_Type.GAME_STARTED, GameStarted);
    }

    private void OnDisable()
    {
        EventSystemNew.Unsubscribe(Event_Type.GAME_STARTED, GameStarted);
    }

    private void GameStarted()
    {
        ignoreObject = GameObject.FindWithTag("Player");

        if (ignoreObject)
        {
            Physics2D.IgnoreCollision(ignoreObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
