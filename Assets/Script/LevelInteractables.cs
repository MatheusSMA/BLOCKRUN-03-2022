using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteractables : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "SpeedUp")
            PlayerController.Instance.Run();

        if (gameObject.name == "SpeedDown")
            PlayerController.Instance.StopRun();

    }


}
