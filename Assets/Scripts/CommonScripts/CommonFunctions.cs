using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class CommonFunctions : MonoBehaviour
{
    ///No Extra comments.<!-- do not delete comment-->
    ///PotionMaking- 
	public Dictionary<string,int> ItemNameCountMap= new Dictionary<string, int>();// ItemNameCountMap.Add("Item"+i,0);
    public List<GameObject> UiWin = new List<GameObject>();//itemTotal.Add(rand); temp.Remove(temp[j]);
	public Animator MoveItem;//MoveItem.SetTrigger("move");
	AudioSource[] audioData= new AudioSource[2];//audioData[0].Play(SoundDelay);



    private void Awake() {
        AudioSource SoundData;
        SoundData = GetComponent<AudioSource>();
        SoundData.Play(0);
        //SoundData.PlayDelayed(SoundDelay);//float SoundDelay


    }
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
        if(Input.GetKeyDown(KeyCode.R)){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
       }
	    if (Input.GetMouseButton(0)){
		
		}
    }
    public void ChangeScene(int ID){
        SceneManager.LoadScene(ID);
    }
	
	public void stuff(int hehe){
        //Observer D
		// if (subjectToObserve != null)
        // {    
        //     subjectToObserve.ThingHappened += OnThingHappened;
        // }

        // cam=subjectToObserve.GetComponentInParent<Camera>();
        // SoundData = GetComponent<AudioSource>();
		// GameObject Canvas = GameObject.FindWithTag("Canvas");

        //  GameObject instance.tag = "Item"+(ItemMaterial);

        
        // Vector3 ItemToCanvasDist= cam.WorldToScreenPoint(transform.position);
		// float ItemToScreenMiddleDist = Vector3.Distance(ItemToCanvasDist, Canvas.transform.position);
		
		// int ItemMaterial = Random.Range(0,materialList.Count);
		// Mathf.Min(7,n-count);
	}
	IEnumerator moveItem(){// StartCoroutine(moveItem());
			yield return new WaitForSeconds(0.01f);
	}
	void OnTriggerEnter(Collider other)
    {
        GameObject winPanel = new GameObject();
        winPanel.SetActive(true);
        Destroy(other.gameObject);
    }
	private void OnCollisionEnter(Collision other) {
       // event Action ThingHappened;
        //ThingHappened?.Invoke();   
    }
    void moveRotationByTime(Vector3 goalRotation,float journeyTime,float startTime,UnityEngine.Events.UnityAction Callback){
        // call in update funvtion             startTime = Time.time;
        Vector3 center = new Vector3(0,0,0);
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.Rotate(Vector3.Slerp(center, goalRotation, fracComplete));
        if(fracComplete>=1f){
            Callback();
            }
    }
	
}
