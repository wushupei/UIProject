using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed, rotateSpeed;
    public float hp = 100;
    public Transform muzzle, fuTou;
    public Transform upBody;
    Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    public void PlayerMove(float h, float v)
    {
        Vector3 vel = rig.velocity;
        vel.x = h;
        vel.z = v;
        rig.velocity = transform.TransformDirection(vel * moveSpeed);
    }
    public void PlayerRotate(float x, float y)
    {
        //转身
        transform.Rotate(0, x * Time.deltaTime * rotateSpeed, 0);
        //抬头
        Quaternion qua = Quaternion.LookRotation(Quaternion.AngleAxis(y >= 0 ? -30 : 30, upBody.right) * transform.forward);
        upBody.rotation = Quaternion.RotateTowards(upBody.rotation, qua, Mathf.Abs(y));
    }
    public void PlayerAttack(bool key)
    {
        if (key)
            Instantiate(fuTou, muzzle.position, muzzle.rotation).gameObject.AddComponent<FuTou>().Fly(muzzle);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (hp >= 5)
                hp -= 5;
            else
                hp = 0;
        }
    }
}
