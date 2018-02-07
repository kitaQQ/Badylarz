using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static float heroHealth;
    public float startHeroHealth = 100;
    public static float aoeDamage = 5f;
    public static float directDamage = 30f;

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        heroHealth = startHeroHealth;
        Rounds = 0;
    }
}
