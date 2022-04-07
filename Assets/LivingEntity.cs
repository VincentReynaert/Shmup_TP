using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public int LifePoints = 10;
    public bool IsAlive = true;
    public void GetHit(int damages)
    {
        LifePoints -= damages;
        if (LifePoints <= 0) IsAlive = false;
    }
    private void Update()
    {
        if (!IsAlive) Destroy(gameObject);
    }
}
