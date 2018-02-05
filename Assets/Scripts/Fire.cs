using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Use this for initialization

    [SerializeField]
    private float damage = 1;

    public float Damage
    {
        get
        {
            return damage;
        }
        private set
        {
            damage = value;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(damage);

            Debug.Log(player.CurrentHitPoints);
        }
    }


}
