using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    public int speed = 3;

    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage(1);
                Destroy(this.gameObject);
            }
        }
    }
}
