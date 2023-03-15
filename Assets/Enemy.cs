using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private ParticleSystem _explosionParticle;

    private int _health = 1;
    
    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health <= 0)
        {
            DeathParticle();
            Destroy(gameObject);
        }
    }

    public bool IsAlive()
    {
        return _health > 0;
    }

    private void DeathParticle()
    {
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
    }
}
