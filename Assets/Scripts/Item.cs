using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public DressUp DressUpController;
        public Vector3 Movement;

    public int id;
    public int categoryId;
    public Image image;
    public Toggle toggle;
    private bool isDragging=false;
    private bool snspping=false;
    private Camera cam;
    public Collider2D dressTarget;
    public Collider2D dress;
    public Vector2 SnapPos;
    public Transform grrandParent ;
    float movespeed = 5f;
    int index ;
    Transform Parent ;
    bool unmoved= true;
      AudioSource music;
    // Start is called before the first frame update
    void Update() 
    {
        if(isDragging){
            // transform.position=new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z);
                       Vector2 tmp = cam.ScreenToWorldPoint(Input.mousePosition);

            // Debug.Log(Input.mousePosition.x);
            // Debug.Log(tmp.x);
            // transform.position=new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z);
            transform.position=new Vector2(tmp.x,tmp.y);

            // Debug.Log(Input.mousePosition.y);
        }
        else if(snspping){
            float x =-(transform.position.x - SnapPos.x);
            float y =-(transform.position.y - SnapPos.y);
            transform.position = new Vector2(transform.position.x + x*movespeed * Time.deltaTime, transform.position.y+ y*movespeed * Time.deltaTime);
            if(transform.position.x >= SnapPos.x - 2){
                snspping = false;
                               unmoved = true;
                               transform.parent = Parent;
               transform.SetSiblingIndex(index);
        }
            // MoveTo(Movement,0,Time.time);
        }
    }
private void OnCollisionEnter2D(Collision2D other){
    // Debug.Log("heeeee~");
}
   public void onDragOk(){
        DressUpController.chooseDress(categoryId,id,DressUpController.spriteResolver);
        toggle.isOn=true;
         music.Play(0);
         Debug.Log("yo");
   }
   public void OntValueChanged(bool isOn){

       image.enabled = !isOn;
   }
   public void onPoniter(bool dawn){
       if(dawn && unmoved){
                     index= transform.GetSiblingIndex();

           isDragging=true;
           SnapPos = transform.position;
           transform.parent = grrandParent;

           unmoved = false;
       
        //   Debug.Log("y"+index);
       }
       else{
           isDragging=false;

           if((dressTarget.OverlapPoint(new Vector2(transform.position.x,transform.position.y)))){
               onDragOk();
                transform.parent = Parent;//?
           }
           else{
            //    transform.position=SnapPos; //cam.ScreenToWorldPoint(SnapPos);
               
                        //  Debug.Log("x"+index);

            //    unmoved = true;
                // MoveTo(SnapPos);
                snspping=true;
           }
       }
   }
    private void Start() {
   cam = Camera.main;   
   Parent = gameObject.transform.parent; 
            music = GetComponent <AudioSource>();


   }
   private void Awake() {
               SnapPos = transform.position;

   }
    protected void MoveTo(Vector2 goalRotation,float journeyTime,float startTime)
    {
        Vector2 center = new Vector2(0,0);
        float fracComplete = (Time.time - startTime) / journeyTime;
        // transform.mo(Vector2.Lerp(center, goalRotation, fracComplete));
    }
}
