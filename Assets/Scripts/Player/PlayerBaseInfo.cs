using UnityEngine;

public class PlayerBaseInfo : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _attackSpeed = 1f;
    [SerializeField] private float _rangeOfAttack = 1.5f;

    public event System.Action<int> DamageChanged;
    public event System.Action<float> AttackSpeedChanged;
    public event System.Action<float> RangeOfAttackChanged;

    public int Damage
    {
        get { return _damage; }
        set
        {
            _damage = value;
            if (DamageChanged != null)
            {
                DamageChanged(_damage);
            }
        }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set
        {
            _attackSpeed = value;
            if (AttackSpeedChanged != null)
            {
                AttackSpeedChanged(_attackSpeed);
            }
        }
    }

    public float RangeOfAttack
    {
        get { return _rangeOfAttack; }
        set
        {
            _rangeOfAttack = value;
            if (RangeOfAttackChanged != null)
            {
                RangeOfAttackChanged(_rangeOfAttack);
            }
        }
    }
}
