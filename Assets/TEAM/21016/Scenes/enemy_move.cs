using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    float speed = -0.01f;
    float dis = 1.5f;
    float min = float.MaxValue;

    ArrayList distance = new ArrayList();

    void Update()
    {
        Generator.enemys.Enqueue(transform.position.x);
        Generator.enemys.Dequeue();

        object[] allys_d = Generator.allys.ToArray();

        if (allys_d.Length > 0)
        {
            foreach (object item in allys_d)
            {
                float pa = float.Parse(item.ToString());
                float pe = transform.position.x;
                float d = Mathf.Abs(pe - pa);
                this.distance.Add(d);
            }

            foreach (float k in this.distance) 
            {
                if (k < this.min)
                {
                    this.min = k;
                }
            }

            if (this.min < this.dis) 
            {
                this.speed = 0;
            }
        }
        transform.Translate(this.speed,0,0);
    }
}
