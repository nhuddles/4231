using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderIntro : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
