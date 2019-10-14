using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyKnightSpawn : MonoBehaviour
{
    public GameObject respawn;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UnitController>().setHealth(100);
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<UnitController>().getHealth() <= 0)
        {
            GameObject.Find("GameController").GetComponent<PlayerManager>().decreaseEnemyRespawns();
            dead = true;
            gameObject.GetComponent<UnitController>().setHealth(100);
            gameObject.GetComponent<NavMeshAgent>().destination = respawn.transform.position;
            gameObject.transform.position = respawn.transform.position;
            gameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(GameObject.Find("rpgpp_lt_terrain_grass_01 (97)").transform.position.x + Random.Range(-30, 30), GameObject.Find("rpgpp_lt_terrain_grass_01 (97)").transform.position.y, GameObject.Find("rpgpp_lt_terrain_grass_01 (97)").transform.position.z + Random.Range(-30, 30)));
            RectTransform[] o = gameObject.GetComponentsInChildren<RectTransform>();
            for (int i = 0; i < o.Length; i++)
            {
                if (o[i].name.Equals("HealthBar"))
                {
                    gameObject.GetComponent<UnitController>().setHealth(gameObject.GetComponent<UnitController>().getHealth() - 10);
                    if (gameObject.GetComponent<UnitController>().getHealth() <= 0) gameObject.GetComponent<UnitController>().setHealth(0);
                    o[i].transform.localScale = new Vector3(gameObject.GetComponent<UnitController>().getHealth() / 100, o[i].transform.localScale.y, o[i].transform.localScale.z);
                    break;
                }
            }
        }
    }

    public bool isdead()
    {
        return dead;
    }
}
