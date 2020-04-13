using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int hp = 1;
    public float damage = 1f;
    protected float invinceTime = 0;
    protected bool isInvincible = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincible == false){
            hp--;
            invincibility();
        }
        
        if (hp == 0)
        {
            Die();
        }
    }

    //Move the onject into a short invincibility time
    protected void invincibility(){
        Debug.Log("Currently Invincible");
        isInvincible = true;
        invinceTime = .5f;
    }

    void FixedUpdate(){
        if (isInvincible){
            invinceTime -= Time.deltaTime;
            if (invinceTime <= 0){
                isInvincible = false;
                Debug.Log("No Longer Invincible");
            }
        }  
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
