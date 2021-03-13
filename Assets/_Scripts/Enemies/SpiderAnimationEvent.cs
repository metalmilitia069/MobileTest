using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private SpiderEnemy _spider;

    private void Start()
    {
        _spider = transform.parent.GetComponent<SpiderEnemy>();
    }

    public void Fire()
    {
        _spider.Attack();
    }
}
