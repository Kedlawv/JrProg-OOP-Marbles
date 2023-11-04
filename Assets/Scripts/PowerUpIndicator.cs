using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIndicator : MonoBehaviour
{
    public bool Active
    {
        get
        {
            return this.Active;
        }

        set
        {
            this.gameObject.SetActive(value);
        }
    }

    public Vector3 Position
    {
        get
        {
            return this.transform.position;
        }

        set
        {
            this.transform.position = value;
        }
    }
}
