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
        GameOverCanvas.enabled = true;
        Cursor.visible = true;
        FindObjectOfType<Weapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
