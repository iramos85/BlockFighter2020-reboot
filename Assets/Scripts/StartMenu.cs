using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);

        Invoke("DisplayText", 1f);
    }
    private void DisplayText()
    {
        textBox.SetActive(true);
    }

}
