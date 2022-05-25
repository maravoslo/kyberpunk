using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject MovementPanel;
    public GameObject DashPanel;
    public GameObject FindPortalPanel;
    public GameObject PanelTutorial;
    public GameObject PanelFinish;
    public GameObject PanelFailed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MovementTag")
        {
            MovementPanel.gameObject.SetActive(false);
            DashPanel.gameObject.SetActive(true);
        }
        if (col.tag == "DashTag")
        {
            DashPanel.gameObject.SetActive(false);
            FindPortalPanel.gameObject.SetActive(true);
        }
        if ((col.tag == "WallTag") || (col.tag == "ObstacleTag"))
        {
            PanelTutorial.gameObject.SetActive(false);
        }

        if (col.tag == "PortalTag")
        {
            PanelTutorial.gameObject.SetActive(false);
        }
    }
        
}
