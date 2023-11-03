using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEditor.UI;
using UnityEngine.UI;

public class EnemiesBehaviours : MonoBehaviour
{
    [SerializeField, Range(0.0f, 10.0f)] private float moveSpeed = 5.0f;
    [SerializeField] private Vector2 moveDirection = Vector2.zero;
    [SerializeField, Range(0.0f, 15.0f)] private float sightRange = 10.0f;

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLM;
    public ContactFilter2D contactFilter;
    private List<GameObject> contacts = new List<GameObject>();

    [Header("CoolDown")]
    [SerializeField] private Image coolDownDisplay;
    [SerializeField, Range(0.0f, 10.0f)] float cooldownTimer = 1.0f;
    private float cooldownTime;
    public bool cooldown = false;

    public bool canAttack = false;
    [Tooltip("Check Box for Manager to handle attacking")]
    public bool aPuppet = false;
    private bool orderRecieved = false;
    public bool OrderRecieved
    {
        set { orderRecieved = value; }
    }


    private void Start()
    {
        cooldownTime = cooldownTimer;
    }


    private void Update()
    {

        canAttack = CanAttackPlayer();

        if(!aPuppet)
        {
            if (canAttack && !cooldown)
            {
                Vector2 direction = player.position - transform.position;
                transform.position += (Vector3)direction * 2.0f;
                cooldown = true;
                cooldownTime = 0.0f;
            }

            if (cooldown)
            {
                cooldownTime += Time.deltaTime;
                if (cooldownTime > cooldownTimer)
                {
                    cooldown = false;
                }
            }
        }
        else
        {
            if (canAttack && !cooldown && orderRecieved)
            {
                Vector2 direction = player.position - transform.position;
                transform.position += (Vector3)direction * 2.0f;
                cooldown = true;
                cooldownTime = 0.0f;
                orderRecieved = false;
            }

            if (cooldown)
            {
                cooldownTime += Time.deltaTime;
                if (cooldownTime > cooldownTimer)
                {
                    cooldown = false;
                }
            }
        }




    }



    private bool CanAttackPlayer()
    {
        bool attack = false;
        if (Physics2D.OverlapCircle(transform.position, sightRange, playerLM))
        {
            RaycastHit2D[] hits;
            Vector2 direction = player.position - transform.position;   
            float distance = Vector2.Distance(transform.position, player.position);

            hits = Physics2D.RaycastAll(transform.position, direction, distance);
            contacts.Clear();

            foreach(RaycastHit2D hit in hits)
            {

                contacts.Add(hit.collider.gameObject);
            }

            if(hits.Length > 0)
            {
                if (hits[0].collider.gameObject.CompareTag("Player"))
                {
                    attack = true;
                }
            }
            
        }
        return attack;
    }


    public bool CanAttackNow()
    {
        bool attack = false;
        attack = CanAttackNow() && !cooldown;

        return attack;
    }


    private void LateUpdate()
    {
        if(coolDownDisplay != null)
        {
            coolDownDisplay.fillAmount = cooldownTime / cooldownTimer;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);


        Gizmos.color = Color.yellow;
        Vector2 direction = player.position - transform.position;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction);
    }



}
