using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float magnetRadius = 5.0f;
    [SerializeField] private float moveSpeed = 5.0f;

    private GameObject player;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < magnetRadius)
        {
            transform.position = Vector3.MoveTowards
                (transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlayCoinSound();
            GameManager.Instance.UpdateCoinCount();
            PoolManager.Instance.ReturnPool(this, this);
        }
    }
}
