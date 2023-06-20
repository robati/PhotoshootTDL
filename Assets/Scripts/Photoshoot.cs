using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photoshoot : MonoBehaviour
{
    public List<GameObject> Scenes;
    // Public List<GameObject> SceneSelect;
    public GameObject dressUpScene;
    public GameObject dressUpMenus;
    public GameObject shootingScene;
   // public int id = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick(int id){
        dressUpMenus.SetActive(false);
        dressUpScene.SetActive(false);
        shootingScene.SetActive(true);

        Scenes[id].SetActive(true);
        gameObject.SetActive(false);

    }
}
