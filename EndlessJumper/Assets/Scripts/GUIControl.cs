using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{
    public GameManager GM;
    public GameObject GameOverPanel;
    public GameObject GameStartPanel;
    // Start is called before the first frame update
    void Start()
    {
        //GameStartPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
}
