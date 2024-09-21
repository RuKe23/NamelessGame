using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally_move : MonoBehaviour
{
    float speed = 0.01f; //속도
    float dis = 1.5f; //적과 만나면 정지할 거리
    float min = float.MaxValue;

    ArrayList distance = new ArrayList(); //적과 거리가 담긴 ArrayList

    void Update()
    {
        Generator.allys.Enqueue(transform.position.x); //자신의 x좌표를 아군의 x좌표가 담긴 Queue에 저장
        Generator.allys.Dequeue(); //이전에 저장된 x좌표 삭제

        object[] enemys_d = Generator.enemys.ToArray(); //적의 x좌표가 담긴 Queue를 배열로 변환

        if (enemys_d.Length > 0)
        {
            foreach (object item in enemys_d)
            {
                float pe = float.Parse(item.ToString()); //object형을 float형으로 변환
                float pa = transform.position.x;
                float d = Mathf.Abs(pa - pe);
                this.distance.Add(d);
            }

            foreach (float k in this.distance) //적과의 거리 중 가장 짧은 거리 계산
            {
                if (k < this.min)
                {
                    this.min = k;
                }
            }

            if (this.min < this.dis) //적과의 거리가 적과 만나면 정지할 거리보다 짧은 경우 속도를 0으로 변환
            {
                this.speed = 0;
            }
        }
        transform.Translate(this.speed,0,0); //이동
    }
}
