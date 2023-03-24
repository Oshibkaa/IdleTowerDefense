using UnityEngine;

public static class EnemyStats
{
    [Header("Options")]
    private static int _money = 1;
    private static float _health = 3;
    private static float _speed = 0.25f;
    private static int _damage = 1;

    public static float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public static int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public static float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public static int Money
    {
        get { return _money; }
        set { _money = value; }
    }
}
