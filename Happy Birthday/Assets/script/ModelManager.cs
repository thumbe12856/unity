using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public GameObject[] model;
    public Transform[] spawnPoints;
    private float timer;
    private float nextTriggerTimer;
    private bool[] swit = new bool[26];

    void Start()
    {
        timer = 0;
        nextTriggerTimer = 0.25f;
        for (int i = 0; i < 26; i++)
            swit[i] = false;
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

        //L
        if (1.4 >= timer && timer >= 1.3)
        {
            spawnPointIndex = 0;
            modelIndex = 11;

            if (!swit[modelIndex])
            {
                Spawn(spawnPointIndex, modelIndex);
                swit[modelIndex] = true;
            }
        }
        //W
        else if (1.5 >= timer && timer >= 1.4)
        {
            spawnPointIndex = 1;
            modelIndex = 22;

            if (!swit[modelIndex])
            {
                Spawn(spawnPointIndex, modelIndex);
                swit[modelIndex] = true;
            }
        }
        //T
        else if (1.6 >= timer && timer >= 1.5)
        {
            spawnPointIndex = 2;
            modelIndex = 19;

            if (!swit[modelIndex])
            {
                Spawn(spawnPointIndex, modelIndex);
                swit[modelIndex] = true;
            }
        }

        
        else if (1.85 >= timer && timer >= 1.8)
        {
            swit[19] = true;

            spawnPointIndex = 3;
            modelIndex = 7;

            if (!swit[modelIndex])
            {
                //H
                Spawn(spawnPointIndex, modelIndex);
                swit[modelIndex] = true;

                //A
                spawnPointIndex = 4;
                modelIndex = 0;
                Spawn(spawnPointIndex, modelIndex);

                //P
                spawnPointIndex = 5;
                modelIndex = 15;
                Spawn(spawnPointIndex, modelIndex);

                //P
                spawnPointIndex = 6;
                modelIndex = 15;
                Spawn(spawnPointIndex, modelIndex);

                //Y
                spawnPointIndex = 7;
                modelIndex = 24;
                Spawn(spawnPointIndex, modelIndex);
            }
        }

        else if (2.05 >= timer && timer >= 2)
        {
            spawnPointIndex = 8;
            modelIndex = 1;

            if (!swit[modelIndex])
            {
                //B
                Spawn(spawnPointIndex, modelIndex);
                swit[modelIndex] = true;

                //I
                spawnPointIndex = 9;
                modelIndex = 8;
                Spawn(spawnPointIndex, modelIndex);

                //R
                spawnPointIndex = 10;
                modelIndex = 17;
                Spawn(spawnPointIndex, modelIndex);

                //T
                spawnPointIndex = 11;
                modelIndex = 19;
                Spawn(spawnPointIndex, modelIndex);

                //H
                spawnPointIndex = 12;
                modelIndex = 7;
                Spawn(spawnPointIndex, modelIndex);

                //D
                spawnPointIndex = 13;
                modelIndex = 3;
                Spawn(spawnPointIndex, modelIndex);

                //A
                spawnPointIndex = 14;
                modelIndex = 0;
                Spawn(spawnPointIndex, modelIndex);

                //Y
                spawnPointIndex = 15;
                modelIndex = 24;
                Spawn(spawnPointIndex, modelIndex);
            }
        }

        else if(timer >= 3.5)
        {
            timer = 0;
            for (int i = 0; i < 25; i++)
                swit[i] = false;
        }
    }   
    
    void Spawn(int spawnPointIndex, int modelIndex)
    {
        Instantiate(model[modelIndex], spawnPoints[spawnPointIndex].position, model[modelIndex].transform.rotation);
    }
}
