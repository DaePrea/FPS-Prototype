using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandle : MonoBehaviour
{

    [SerializeField] Canvas GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.enabled = false;
    }

    public void DeathHandled()
    {
        //enables the game over screen when the player dies
        GameOverCanvas.enabled = true;
        Cursor.visible = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
