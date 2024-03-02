using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerShaker : MonoBehaviour
{
    CinemachineImpulseSource cinemachineInpuleSource;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineInpuleSource = GetComponent<CinemachineImpulseSource>();
    }
    public void ShakeCamera()
    {
        cinemachineInpuleSource.GenerateImpulse();
    }
}
