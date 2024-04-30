using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{

    public GameObject inseki_Prefab;
    float span = 1.0f;
    float delta = 0;
    float speed = -0.1f;
    int ratio = 0;

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        float n = Random.Range(0, 9);
        if (this.delta > this.span)
        {
            this.delta = 0;

            if(MenuSelect.Level == 0)
            {
                ArrowGene_x(1);
            }
            if(MenuSelect.Level == 1)
            {
                ArrowGene_x(2);
            }
            if (MenuSelect.Level == 2)
            {
                if (n < 5)
                {
                    ArrowGene();
                }
                ArrowGene_x(2);
            }

        }
    }

    void ArrowGene()
    {
        GameObject go = Instantiate(inseki_Prefab);
        
        float px = Random.Range(0, 5);
        
        if (px < 1)
        {
            px = (float)-3.5;
        }
        else if (px < 2)
        {
            px = (float)-2.0;
        }
        else if (px < 3)
        {
            px = (float)-0.5;
        }
        else if (px < 4)
        {
            px = (float)1;
        }
        else if (px < 5)
        {
            px = (float)2.5;
        }
        else if(px < 6)
        {
            px = (float)4;
        }

        go.transform.position = new Vector3(13, px, 0);
        go.GetComponent<ArrowController>().dropSpeed = this.speed;
    }

    void ArrowGene_x(int x)
    {
        int[] iti = new int[x];//—”‚ÌŠi”[”z—ñ
        float[] zahyou = new float[x];//—”‚ğŒ³‚É‚µ‚½À•W‚ÌŠi”[”z—ñ
        int cnt = 0;
        int a = 0;

        while (a < x)
        {
            cnt  = 0;
            iti[a] = Random.Range(0, 5);
            for(int i = 0;i<a;i++)
            {
                if(iti[i] == iti[a])
                {
                    cnt++;
                }
            }
            if(cnt == 0)
            {
                if (iti[a] < 1)
                {
                    zahyou[a] = (float)-3.5;
                }
                else if (iti[a] < 2)
                {
                    zahyou[a] = (float)-2.0;
                }
                else if (iti[a] < 3)
                {
                    zahyou[a] = (float)-0.5;
                }
                else if (iti[a] < 4)
                {
                    zahyou[a] = (float)1;
                }
                else if (iti[a] < 5)
                {
                    zahyou[a] = (float)2.5;
                }
                else if (iti[a] < 6)
                {
                    zahyou[a] = (float)4;
                }

                a++;    
            }
        }

        for(int i = 0;i<x;i++)
        {
            Instantiate(inseki_Prefab, new Vector3(13, zahyou[i], 0), Quaternion.identity);
        }

    }
}
