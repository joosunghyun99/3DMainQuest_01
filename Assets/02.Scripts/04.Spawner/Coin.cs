using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.UpdateCoinCount();
            PoolManager.Instance.ReturnPool(this, this);
        }
    }
}
