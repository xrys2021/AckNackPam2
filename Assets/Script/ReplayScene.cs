using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScene : MonoBehaviour
{
    public void LoadGame()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }
}
