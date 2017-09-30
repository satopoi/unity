using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    bool fallIn;

    // どのボールを吸い寄せるかタグで指定
    public string activeTag;

    // ボールが入っているかを返す
    public bool IsFallIn()
    {
        return fallIn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == activeTag)
        {
            fallIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == activeTag)
        {
            fallIn = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // コライダに触れているオブジェクトのRigidbody
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるか計算
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        // タグに応じてボールに力を加える
        if (other.gameObject.tag == activeTag)
        {
            // 中心地点でボールを止めるため速度を減速させる
            r.velocity *= 0.9f;
            r.AddForce(direction * r.mass * 20.0f);
        } else
        {
            r.AddForce(-direction * r.mass * 20.0f);
        }
    }

}
