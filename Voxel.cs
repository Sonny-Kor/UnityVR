using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // 1. ������ ���ư� �ӵ� �Ӽ�
    public float speed = 5;
    // ������ ������ �ð�
    public float destoryTime = 3.0f;

    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;

    }

    // Update is called once per frame
    void Update()
    {
        // �����ð��� ������ ������ �����ϰ� �ʹ�.
        // 1. �ð��� �귯�� �Ѵ�.
        currentTime += Time.deltaTime;
        // 2. ���� �ð��� �����ϱ�.
        if (currentTime >= destoryTime)
        {
            // 3. ������ �����ϰ� �ʹ�.
            gameObject.SetActive(false);
            VoxelMaker.voxelPool.Add(gameObject);
        }
    }
}
