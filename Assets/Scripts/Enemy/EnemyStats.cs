using UnityEngine;

public static class EnemyStats
{
    [Header("Options")]
    private static int _money = 1;
    private static float _health = 1;
    private static float _speed = 1f;
    private static float _damage = 1;

    public static void ResetStats()
    {
        _health = 1;
        _speed = 0.25f;
        _damage = 1;
    }

    public static float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public static float Damage
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
