using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudControl : MonoBehaviour
{
    [Header("thingsToActivate \n ShowMoreButtons \n Pause \n ControlsInfo")]
    [SerializeField] GameObject[] thingsToActivate;

    bool showMoreButtons;
    bool gameFreezt;
    bool showControls;

    public void ShowMoreButtons()
    {
        if(showMoreButtons == false)
        {
            thingsToActivate[0].SetActive(true);

            showMoreButtons = true;
        }
        else
        {
            thingsToActivate[0].SetActive(false);

            showMoreButtons = false;
        }
    }

    public void PauseGame()
    {
        if (gameFreezt == false)
        {
            thingsToActivate[0].SetActive(false);
            thingsToActivate[1].SetActive(true);

            Time.timeScale = 0;

            gameFreezt = true;
            showMoreButtons = false;
        }
        else
        {
            thingsToActivate[0].SetActive(false);
            thingsToActivate[1].SetActive(false);

            Time.timeScale = 1;

            gameFreezt = false;
            showMoreButtons = false;
        }
    }

    public void ShowControls()
    {
        if (showControls == false)
        {
            thingsToActivate[0].SetActive(false);
            thingsToActivate[1].SetActive(true);
            thingsToActivate[2].SetActive(true);

            Time.timeScale = 0;

            showControls = true;
            showMoreButtons = false;
        }
        else
        {
            thingsToActivate[0].SetActive(false);
            thingsToActivate[1].SetActive(false);
            thingsToActivate[2].SetActive(false);

            Time.timeScale = 1;

            showControls = false;
            showMoreButtons = false;
        }
    }
}
