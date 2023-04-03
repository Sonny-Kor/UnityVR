using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // 1. 복셀이 날아갈 속도 속성
    public float speed = 5;
    // 복셀을 제거할 시간
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
        // 일정시간이 지나면 복셀을 제거하고 싶다.
        // 1. 시간이 흘러야 한다.
        currentTime += Time.deltaTime;
        // 2. 제거 시간이 됐으니까.
        if (currentTime >= destoryTime)
        {
            // 3. 복셀을 제거하고 싶다.
            gameObject.SetActive(false);
            VoxelMaker.voxelPool.Add(gameObject);
        }
    }
}
