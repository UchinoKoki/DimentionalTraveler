using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackArea : MonoBehaviour
{
    public Player player;
    public List<Enemy> hitList = new List<Enemy>();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hitList.Add(other.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hitList.Remove(other.GetComponent<Enemy>());
        }
    }
    public List<Enemy> GetEnemyList()
    {
        return hitList;
    }
}
