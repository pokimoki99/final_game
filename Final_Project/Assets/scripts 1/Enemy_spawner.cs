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
    public void spawn()
    {
        Vector3 enemy = new Vector3(_player.transform.position.x + random(), _player.transform.position.y, _player.transform.position.z + random());
        Instantiate(enemyprefab, enemy, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float random()
    {
        float a = Random.Range(0.0f,10.0f);
        return a;
    }
}
