using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public GameObject[] model;
    public Transform[] spawnPoints;
    private float timer;
    private float nextTriggerTimer;

    void Start()
    {
        timer = 0;
        nextTriggerTimer = 0.25f;
        /*spawnPointIndex['a'] = 0;
        spawnPointIndex['b'] = 4;
        spawnPointIndex['c'] = 2;
        spawnPointIndex['d'] = 2;
        spawnPointIndex['e'] = 2;
        spawnPointIndex['f'] = 3;
        spawnPointIndex['g'] = 4;
        spawnPointIndex['h'] = 5;
        spawnPointIndex['i'] = 7;
        spawnPointIndex['j'] = 6;
        spawnPointIndex['k'] = 7;
        spawnPointIndex['l'] = 8;
        spawnPointIndex['m'] = 6;
        spawnPointIndex['n'] = 5;
        spawnPointIndex['o'] = 8;
        spawnPointIndex['p'] = 9;
        spawnPointIndex['q'] = 0;
        spawnPointIndex['r'] = 3;
        spawnPointIndex['s'] = 1;
        spawnPointIndex['t'] = 4;
        spawnPointIndex['u'] = 6;
        spawnPointIndex['v'] = 3;
        spawnPointIndex['w'] = 1;
        spawnPointIndex['x'] = 1;
        spawnPointIndex['y'] = 5;
        spawnPointIndex['z'] = 0;

        modelIndex['a'] = 0;
        modelIndex['b'] = 1;
        modelIndex['c'] = 2;
        modelIndex['d'] = 3;
        modelIndex['e'] = 4;
        modelIndex['f'] = 5;
        modelIndex['g'] = 6;
        modelIndex['h'] = 7;
        modelIndex['i'] = 8;
        modelIndex['j'] = 9;
        modelIndex['k'] = 10;
        modelIndex['l'] = 11;
        modelIndex['m'] = 12;
        modelIndex['n'] = 13;
        modelIndex['o'] = 14;
        modelIndex['p'] = 15;
        modelIndex['q'] = 16;
        modelIndex['r'] = 17;
        modelIndex['s'] = 18;
        modelIndex['t'] = 19;
        modelIndex['u'] = 20;
        modelIndex['v'] = 21;
        modelIndex['w'] = 22;
        modelIndex['x'] = 23;
        modelIndex['y'] = 24;
        modelIndex['z'] = 25;*/
    }

    void Update()
    {
        int spawnPointIndex = -1;
        int modelIndex = -1;

        timer += Time.deltaTime;
        if (timer > nextTriggerTimer)
        {
            if (Input.GetKey(KeyCode.A))
            {
                spawnPointIndex = 0;
                modelIndex = 0;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.B))
            {
                spawnPointIndex = 4;
                modelIndex = 1;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.C))
            {
                spawnPointIndex = 2;
                modelIndex = 2;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.D))
            {
                spawnPointIndex = 2;
                modelIndex = 3;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.E))
            {
                spawnPointIndex = 2;
                modelIndex = 4;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.F))
            {
                spawnPointIndex = 3;
                modelIndex = 5;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.G))
            {
                spawnPointIndex = 4;
                modelIndex = 6;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.H))
            {
                spawnPointIndex = 5;
                modelIndex = 7;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.I))
            {
                spawnPointIndex = 7;
                modelIndex = 8;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.J))
            {
                spawnPointIndex = 6;
                modelIndex = 9;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.K))
            {
                spawnPointIndex = 7;
                modelIndex = 10;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.L))
            {
                spawnPointIndex = 8;
                modelIndex = 11;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.M))
            {
                spawnPointIndex = 6;
                modelIndex = 12;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.N))
            {
                spawnPointIndex = 5;
                modelIndex = 13;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.O))
            {
                spawnPointIndex = 8;
                modelIndex = 14;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.P))
            {
                spawnPointIndex = 9;
                modelIndex = 15;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                spawnPointIndex = 0;
                modelIndex = 16;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.R))
            {
                spawnPointIndex = 3;
                modelIndex = 17;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.S))
            {
                spawnPointIndex = 1;
                modelIndex = 18;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.T))
            {
                spawnPointIndex = 4;
                modelIndex = 19;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.U))
            {
                spawnPointIndex = 6;
                modelIndex = 20;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.V))
            {
                spawnPointIndex = 3;
                modelIndex = 21;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.W))
            {
                spawnPointIndex = 1;
                modelIndex = 22;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.X))
            {
                spawnPointIndex = 1;
                modelIndex = 23;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.Y))
            {
                spawnPointIndex = 5;
                modelIndex = 24;
                Spawn(spawnPointIndex, modelIndex);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                spawnPointIndex = 0;
                modelIndex = 25;
                Spawn(spawnPointIndex, modelIndex);
            }

            if (spawnPointIndex != -1 && modelIndex != -1)
            {
                timer = 0;
                nextTriggerTimer -= 0.1f;
            }
            else
            {
                nextTriggerTimer = 0.25f;
            }
        }
    }   
    
    void Spawn(int spawnPointIndex, int modelIndex)
    {
        Instantiate(model[modelIndex], spawnPoints[spawnPointIndex].position, model[modelIndex].transform.rotation);
    }
}
