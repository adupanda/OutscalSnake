using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerr : MonoBehaviour
{
    
    [SerializeField] private string sceneName;

    public Animator transition;

    public float transitionTime = 1f;
    public void SetScene()
    {
        
        SoundManager.Instance.Play(Sounds.buttonClick);
        SceneManager.LoadScene(sceneName);
        SoundManager.Instance.Play(Sounds.GameStart);
        //StartCoroutine(LoadLevel());
    }

    //IEnumerator LoadLevel()
    //{
    //    bool loadScene = false;
    //    while(!loadScene)
    //    {
    //        //transition.SetTrigger("Start");
    //        //yield return new WaitForSeconds(transitionTime);
    //        SceneManager.LoadScene(sceneName);
    //        loadScene = true;
    //    }
       


    //}
}
