using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : Damage
{
     [SerializeField] private HealthBar HpBar; 
     float healthPercent;

     void Start(){
         healthPercent = 1;
     }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincible == false){
            hp--;
            healthPercent -= .25f;
            HpBar.updateEnergy(healthPercent);
            invincibility();
        }
        
        if (hp == 0)
        {
            HpBar.updateEnergy(0);
            Die();
        }
    }
}
