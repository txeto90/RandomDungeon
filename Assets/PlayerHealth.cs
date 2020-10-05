using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public HealthBarBehaviour hpBar;
    public float maxHp = 10;
    public float hp;

    void Start()
    {
        hp = maxHp;
        hpBar.setHealth(hp, maxHp);
    }

    // Update is called once per frame
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
