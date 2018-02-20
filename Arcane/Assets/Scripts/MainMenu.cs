using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image PressEntertoBegin;
    public Image snowLoadingIcon;
    bool fade = true;
    bool rotate = false;
	void Start ()
    {
		
	}
	void Update ()
    {
        FadeEffect();
        Load();
	}
    void FadeEffect()
    {
        if (PressEntertoBegin.color.a ==1)
        {
            fade = true;
        }
        if(PressEntertoBegin.color.a <= 0)
        {
            fade = false;
        }
        if (fade)
        {
            PressEntertoBegin.color -= new Color(0, 0, 0, 0.01f);
        }
        if(!fade)
        {
            PressEntertoBegin.color += new Color(0, 0, 0, 0.01f);
        }
    }
    void Load()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            PressEntertoBegin.gameObject.SetActive(false);
            snowLoadingIcon.gameObject.SetActive(true);
            rotate = true;
            SceneManager.LoadScene(1);
        }
        if (rotate)
        {
            snowLoadingIcon.transform.Rotate(0, 0, -2, 0);
        }
    }

}
