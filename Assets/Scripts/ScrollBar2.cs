using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollBar2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool goToFirst;
    public Scrollbar scrollbar;
    public float moveSpeed;
    public void OnClick(){
        if(goToFirst){
            scrollbar.value+=moveSpeed;
        }
        else
            scrollbar.value-=moveSpeed;

    }
}
