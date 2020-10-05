using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHp = 10;   //vida maxima
    public int hp;          //vida actual
    public HealthBarBehaviour hpBar;

    void Start()
    {
        hp = maxHp;
        hpBar.setHealth(hp, maxHp);
    }

    void Update()
    {
        
    }

    public void Attacked()
    {
        --hp;
        hpBar.setHealth(hp, maxHp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
