using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateProgress : MonoBehaviour
{
    GatePopEnemy gatePopEnemy;

    [SerializeField] private float gateCharge;
    public float GateCharge { get { return gateCharge; } }
    [SerializeField] private float gateChargeMax;
    [SerializeField] private float gateChargeSpeed;
    public bool isGateOpen = false;
    public bool isGateCharging = false;
    // Start is called before the first frame update
    void Start()
    {
        gatePopEnemy = GetComponent<GatePopEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        
    }
    public void Charge(bool _isCharge)
    {
        if(!isGateCharging) return;
        if(_isCharge)
        {
            if(gateCharge < gateChargeMax)
            {
                gateCharge += gateChargeSpeed;
                gatePopEnemy.isOn = true;
            }
            else
            {
                isGateOpen = true;
                gatePopEnemy.isOn = false;
            }
        }
        else
        {
            if(gateCharge > 0)
            {
                gateCharge -= gateChargeSpeed * 0.8f;
            }
        }
    }
}
