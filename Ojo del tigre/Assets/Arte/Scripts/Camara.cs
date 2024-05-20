using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject target;
    public int kill;
    public GameObject[] barreras;

    private float targetPoseX;
    private float targetPoseY;

    private float poseX;
    private float poseY;

    public float izquierdaMax;
    public float derechaMax;

    public float alturaMax;
    public float alturaMin;

    public float speed;
    public bool encendida = true;

    void Awake()
    {
        poseX = targetPoseX + derechaMax;
        poseY = targetPoseY + alturaMin;
        transform.position = Vector3.Lerp(transform.position, new Vector3(poseX, poseY, -1), 1);
    }

    private void MoveCam()
    {
        
        if (encendida)
        {
            if (target)
            {
                targetPoseX = target.transform.position.x;
                targetPoseY = target.transform.position.y;

                if (targetPoseX > derechaMax && targetPoseX < izquierdaMax)
                {
                    poseX = targetPoseX;
                }

                if (targetPoseY < alturaMax && targetPoseY > alturaMin)
                {
                    poseY = targetPoseY;
                }
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(poseX, poseY, -1), speed * Time.deltaTime);
        }
    }

    void Update()
    {
        MoveCam();
        if (kill >= 2)
        {
            izquierdaMax = 32.09f;
            barreras[0].SetActive(false);
        }
        if (kill >= 6)
        {
            izquierdaMax = 62.76f;
            barreras[1].SetActive(false);
        }
    }
}
