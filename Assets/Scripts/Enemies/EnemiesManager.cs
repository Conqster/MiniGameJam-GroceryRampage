using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private List<EnemiesBehaviours> enemies = new List<EnemiesBehaviours>();
    public List<EnemiesBehaviours> queueForAttack = new List<EnemiesBehaviours>();


    private void Start()
    {
        //add all enemies in the scene to the list 
    }

    private void Update()
    {
        


        foreach (var enemy in enemies)
        {

        }

        
        foreach(var enemyqueue in queueForAttack)
        {
            if(!enemyqueue.CanAttackNow())
            {
                queueForAttack.Remove(enemyqueue);
            }
        }

    }
}
