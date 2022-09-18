using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    public void Kill(GameObject player) => Destroy(player);
}
