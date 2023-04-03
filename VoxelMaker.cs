using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFacotry;
    // 오브젝트 풀의 크기
    public int voxelPoolsize = 20;
    public static List<GameObject> voxelPool = new List<GameObject>();

    public float createTime = 0.1f;
    float currentTime = 0;

    public Transform crosshair;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < voxelPoolsize; i++)
        {
            GameObject voxel = Instantiate(voxelFacotry);
            voxel.SetActive(false);
            voxelPool.Add(voxel);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        ARAVRInput.DrawCrosshair(crosshair);
        currentTime += Time.deltaTime;
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            if (currentTime > createTime)
            {
                Ray ray = new Ray(ARAVRInput.RHandPosition,ARAVRInput.RHandDirection); // screen point view point world point/
                RaycastHit hitinfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitinfo))
                {
                    if (voxelPool.Count > 0)
                    {
                        currentTime = 0;
                        GameObject voxel = voxelPool[0];
                        voxel.SetActive(true);
                        voxel.transform.position = hitinfo.point;
                        voxelPool.RemoveAt(0);
                    }
                }
            }
        }
        
    }
}
