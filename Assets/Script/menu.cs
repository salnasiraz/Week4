using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject menufitur;
    // Start is called before the first frame update
    void Start()
    {
        menupanel.SetActive(true);
        menufitur.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart()
    {
        menupanel.SetActive(false);
        menufitur.SetActive(true);
    }

    public void ButtonBack(){
        menupanel.SetActive(true);
        menufitur.SetActive(false);
    }

    public void ButtonStorym(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ButtonSinglep(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ButtonMultip(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ButtonCoop(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ButtonFreem(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

}
