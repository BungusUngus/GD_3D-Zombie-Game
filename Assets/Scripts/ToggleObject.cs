using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
  public void toggleObject(GameObject tObject)
    {
        tObject.SetActive(!tObject.activeSelf);
    }
}
