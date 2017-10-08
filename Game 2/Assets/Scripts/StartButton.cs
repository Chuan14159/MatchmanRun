using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public string level="Menu";
    public void OnClick()
    {
        SceneManager.LoadScene(level);
    }
}
