using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Hero;
    public GameObject[] Enemy;
    public GameObject Menang;

    void Update()
    {
        if(!Enemy[0].activeInHierarchy && !Enemy[1].activeInHierarchy)
        {
            Time.timeScale = 0;
            Menang.SetActive(true);
        }
        
    }
}
