using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_spawner : MonoBehaviour
{
    public Transform enemyprefab;
    public Player _player;

    public static Enemy_spawner _enemy_spawn
    {
        get
        {
            return enemy_spawn;
        }
    }

    private static Enemy_spawner enemy_spawn = null;

    void Awake()
    {
        if (enemy_spawn)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        enemy_spawn = this;

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void spawn(float x,float z)
    {
        //Vector3 enemy = new Vector3(_player.transform.position.x + random(), _player.transform.position.y, _player.transform.position.z + random());
        Vector3 enemy = new Vector3(_player.transform.position.x + random2() +x, _player.transform.position.y-5.0f, _player.transform.position.z - random()+z);
        Instantiate(enemyprefab, enemy, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float random()
    {
        float z = Random.Range(20.0f,50.0f);
        return z;
    }
    float random2()
    {
        float x = Random.Range(-5.0f, 5.0f);
        return x;
    }
}
