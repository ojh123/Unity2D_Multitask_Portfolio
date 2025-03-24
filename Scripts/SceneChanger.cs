using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public void SceneChange(int _num)
    {
        SceneManager.LoadScene(_num);
    }

    public void ReStartScence(int _num)
    {
        SceneManager.LoadScene(_num);
    }
}
