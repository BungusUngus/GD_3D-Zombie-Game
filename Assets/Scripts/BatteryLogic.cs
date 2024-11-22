using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatteryLogic : FlashLight
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<FlashLight>().ReplaceBattery(1f);
            Destroy(gameObject);
        }
    }
}
