using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDeath : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        gameObject.SendMessageUpwards("MinionBurned");
    }
}
