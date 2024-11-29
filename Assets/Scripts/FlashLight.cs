using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light mainLight;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;

    // Start is called before the first frame update
    void Start()
    {
        mainLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        mainLight.intensity = Mathf.Clamp(mainLight.intensity, minBrightness, maxBrightness);
        if (drainOverTime == true && mainLight.enabled == true)
        {
            if (mainLight.intensity > minBrightness)
            {
                mainLight.intensity -= Time.deltaTime * (drainRate / 1000);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            mainLight.enabled = !mainLight.enabled;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReplaceBattery(1.6f);
        }
    }
    public void ReplaceBattery(float amount)
    {
        mainLight.intensity += amount;
    }
}
