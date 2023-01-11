using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            WaterDeath();
        }
    }

    public void WaterDeath()
    {
        Debug.Log("Death");

        // stop time
        // bring up ui that says death and cause of it
        // decrease lives if that's what I do
        // function to restart level/respawn player
    }
}
