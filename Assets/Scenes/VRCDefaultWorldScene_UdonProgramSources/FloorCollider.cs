
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace FloorCollider
{ 
public class FloorCollider : UdonSharpBehaviour
{
    public GameObject[] StairsObjects;
    public int[] Stairs;

    private void Start()
    {
        foreach (var stair in StairsObjects)
        {
            stair.SetActive(true);
        }
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.IsValid() && player.isLocal)
        {
            foreach (var stair in StairsObjects)
            {
                stair.SetActive(false);
            }
        }
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (!player.IsValid() || !player.isLocal) return;

        foreach (var stair in StairsObjects)
        {
            stair.SetActive(true);
        }
    }
}
}