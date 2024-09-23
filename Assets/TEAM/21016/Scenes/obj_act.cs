using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_act : MonoBehaviour
{
    public float speed = 0.01f; //속도
    public float dis = 1.5f; //적과 만나면 정지할 거리
    public int obj_type = 0; //아군: 0, 적: 1
    float min = float.MaxValue;
    object[] obj_d;

    ArrayList distance = new ArrayList(); //적과 거리가 담긴 ArrayList

    void Update()
    {
        if (obj_type == 0) //아군일 경우
        {
            Generator.allys.Dequeue(); //이전에 저장된 x좌표 삭제
            Generator.allys.Enqueue(transform.position.x); //자신의 x좌표를 아군의 x좌표가 담긴 Queue에 저장
            this.obj_d = Generator.enemys.ToArray(); //적의 x좌표가 담긴 Queue를 배열로 변환
        }

        else if (obj_type == 1) //적일 경우
        {
            Generator.enemys.Dequeue(); //이전에 저장된 x좌표 삭제
            Generator.enemys.Enqueue(transform.position.x); //자신의 x좌표를 적의 x좌표가 담긴 Queue에 저장
            this.obj_d = Generator.allys.ToArray(); //아군의 x좌표가 담긴 Queue를 배열로 변환
        }

        if (obj_d.Length > 0)
        {
            foreach (object item in obj_d)
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
        transform.Translate(this.speed, 0, 0); //이동
    }
}
