using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    public Camera endCamera;
    public Slider slider;
    public TMP_Text endText;
    public Button restartButton;

    // Start is called before the first frame update
    void OnEnable()
    {
        endCamera.enabled = true;
        slider.gameObject.SetActive(false);
        endText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
