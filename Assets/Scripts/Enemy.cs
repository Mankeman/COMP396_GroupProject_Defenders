using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public float startSpeed = 10f;
    public float health = 100;
    public int value = 50;
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }
    public void Slow(float slowValue)
    {
        speed = startSpeed * (1f - slowValue);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        Destroy(gameObject);
    }
}
