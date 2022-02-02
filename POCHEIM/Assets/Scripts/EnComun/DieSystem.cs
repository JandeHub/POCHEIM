using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSystem : MonoBehaviour
{
    private Animator _anim;

    public bool dead { get; private set; }

    public GameObject[] lootItems;

    void OnEnable()
    {
        GetComponent<HealthSystem>().OnDie += Die;
    }

    void OnDisable()
    {
        GetComponent<HealthSystem>().OnDie -= Die;
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        
        dead = false;
    }

    void Die()
    {
        Debug.Log("Enemy died");

        dead = true;
        _anim.SetBool("dead", true);

        int lootRarity = Random.Range(0, 101);

        if(lootRarity < 3)
        {
            Instantiate(lootItems[0].gameObject, transform.position, Quaternion.identity);
        }
        else if(lootRarity < 10)
        {
            Instantiate(lootItems[1].gameObject, transform.position, Quaternion.identity);
        }
        else if(lootRarity < 40)
        {
            Instantiate(lootItems[2].gameObject, new Vector3(transform.position.x, transform.position.y + 5, 0), Quaternion.identity);
        }
        else if(lootRarity < 70)
        {
            Instantiate(lootItems[3].gameObject, transform.position, Quaternion.identity);
        }
        

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2);
        this.enabled = true;
        


    }
}
