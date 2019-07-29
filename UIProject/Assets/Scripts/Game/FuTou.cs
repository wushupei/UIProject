using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuTou : MonoBehaviour
{
    bool fly = true;
    Rigidbody rig;
    Quaternion rotateInfo;
    Transform fuTou;
    private float collisionTf;
    ParticleSystem effectPrefab;
    private void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        fuTou = transform.GetChild(0);
        rotateInfo = fuTou.rotation;
        effectPrefab = Resources.Load<ParticleSystem>("Prefabs/Effect/Blood");
        //(摆正)恢复成初始旋转
        Vector3 euler = transform.eulerAngles;
        euler.x = 0;
        transform.eulerAngles = euler;
    }
    private void FixedUpdate()
    {
        if (fly)
            fuTou.Rotate(0, -30, 0);
        if (rig.IsSleeping())
        {
            Destroy(rig);
            Destroy(GetComponent<BoxCollider>());
            Destroy(this);
        }
        if (transform.position.y < -10)
            Destroy(gameObject);
    }
    public void Fly(Transform muzzle)
    {
        rig.AddForce(muzzle.forward * 10 + muzzle.up * 2, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (fly)
        {
            fly = false;
            if (collision.transform.CompareTag("Enemy"))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    transform.position = hit.point + (transform.position - hit.point).normalized * 0.1f;
                    rig.isKinematic = true;
                    fuTou.rotation = rotateInfo;
                    ShowEffect(hit.point, collision.transform);
                }
            }
        }
        transform.SetParent(collision.transform);
    }
    private void ShowEffect(Vector3 hitPos, Transform colTF) //生成特效
    {
        Vector3 dir = hitPos - new Vector3(colTF.position.x, hitPos.y, colTF.position.z);
        Transform tf = Instantiate(effectPrefab.transform, hitPos, Quaternion.identity, colTF);
        tf.rotation = Quaternion.LookRotation(dir);
        //tf.LookAt(transform);
    }
}
