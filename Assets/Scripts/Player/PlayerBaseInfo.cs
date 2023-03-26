using System;
using UnityEngine;

public class PlayerBaseInfo : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _attackSpeed = 1f;
    [SerializeField] private float _rangeOfAttack = 1f;

    public event Action<int> DamageChanged;
    public event Action<float> AttackSpeedChanged;
    public event Action<float> RangeOfAttackChanged;

    public int Damage
    {
        get { return _damage; }
        set
        {
            _damage = value;
            DamageChanged?.Invoke(_damage);
        }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set
        {
            _attackSpeed = value;
            AttackSpeedChanged?.Invoke(_attackSpeed);
        }
    }

    public float RangeOfAttack
    {
        get { return _rangeOfAttack; }
        set
        {
            _rangeOfAttack = value;
            RangeOfAttackChanged?.Invoke(_rangeOfAttack);
        }
    }
}
