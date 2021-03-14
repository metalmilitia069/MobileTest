using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField]
    private int gems = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Player player = collision.GetComponent<Player>();
            //player.diamonds += gems;
            player.AddGems(gems);
            Destroy(this.gameObject);
        }
    }
}
