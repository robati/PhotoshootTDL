using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;
using static UnityEngine.Random;
using UnityEngine.SceneManagement;


public class DressUp : MonoBehaviour
{
    public List<SpriteResolver> spriteResolver=new List<SpriteResolver>();
    public List<SpriteResolver> TDLSpriteResolver=new List<SpriteResolver>();
    public List<SpriteResolver> PhtoSpriteResolver=new List<SpriteResolver>();
    public SpriteLibrary spriteLibrary;
    public setup setupInf;
    public Item itemPref;
    public Item delPref;
    public Sprite nullsprite;
    public GameObject winPanel;
    SpriteLibraryAsset spriteLibraryAsset;
    public List<ToggleGroup> listCategory=new List<ToggleGroup>();
    List<List<string>> LabelID=new List<List<string>>();
    List<List<string>> dressSets=new List<List<string>>();
    List<string> categoryL=new List<string>();
    List<Item> items=new List<Item>();
    int a2,b2,c2,d2;
    int a1,b1,c1,d1;
    bool startPlaying = false;
      AudioSource SoundData;
    // Start is called before the first frame update
    private void Awake() {
              SoundData  = GetComponent<AudioSource>();

    }
    private void Start() {
      spriteLibraryAsset=spriteLibrary.spriteLibraryAsset;
      string[] categorys=setupInf.cloth;
      // Debug.Log(categorys.Length);
      foreach (string category in categorys){   //init Category list{"cloth","sleeve","hair","hand","legl","legr"}
        categoryL.Add(category);
        }
      for(int i=0;i<setupInf.cloth.Count();i++){ //init Category labels{cloth:{dress1,dress2},sleeve:{sleeve1,sleeve2},hair:{hair1..}}
        LabelID.Add(new List<string>());        // labellID {0:{0},1:{0,1},2:{0,1}}
        LabelID[i]=setLabel(categoryL[i]);
        }

      dressSetsInitial();                       //init set list {dress:{cloth,sleeve},hair:{hair},hand:{hand},leg:{legrlegl}}
      fillWardrobe();                           // DressSet {0:{0},1:{1},2:{2}}

// Debug.Log("category");


        foreach (string category in categoryL){   
        // Debug.Log(category);
        }
        // Debug.Log("label2s");
        int count=0;
        foreach (List<string> category in LabelID){   
            foreach (string im in category){   
              // Debug.Log(im);
            }
            count++;
            // Debug.Log("count:"+count);
        }
          //  Debug.Log("dressset");       
          count=0;
        foreach (List<string> category in dressSets){   
            foreach (string im in category){   
              // Debug.Log(im);
            }
            count++;
            // Debug.Log("count:"+count);
        }
        // choose a random dress at the start.
        int a= UnityEngine.Random.Range(0, 8);
        int d= UnityEngine.Random.Range(0, 5);
        int b= UnityEngine.Random.Range(0, 8);
        int c= UnityEngine.Random.Range(0, 2);

        chooseDress(2,0,spriteResolver);//0-8
        chooseDress(0,0,spriteResolver);//0-8
        chooseDress(1,0,spriteResolver);
        chooseDress(3,c,spriteResolver);   
        
        a2= UnityEngine.Random.Range(0, 8);
        d2= UnityEngine.Random.Range(0, 5);
        b2= UnityEngine.Random.Range(0, 8);
        c2= UnityEngine.Random.Range(0, 2);

        if(a2==b2&& a2==0){
           a2= UnityEngine.Random.Range(1, 8);

        }
        chooseDress(2,a2,TDLSpriteResolver);
        chooseDress(0,d2,TDLSpriteResolver);
        chooseDress(1,b2,TDLSpriteResolver);
        chooseDress(3,c2,TDLSpriteResolver);
        
     


        chooseDress(2,a2,PhtoSpriteResolver);
        chooseDress(0,d2,PhtoSpriteResolver);
        chooseDress(1,b2,PhtoSpriteResolver);
        chooseDress(3,c2,PhtoSpriteResolver);

           winPanel.SetActive(false);
        a1=0;
        b1=0;
        d1 = 0;
        c1=c;


        startPlaying = true;

    }
public void dressSetsInitial(){
    
      IEnumerable<int> uniqueItems = setupInf.dressMatch.Distinct<int>();
      for(int i=0;i<uniqueItems.Count();i++){
        dressSets.Add(new List<string>());
        }
      for(int k=0;k<setupInf.dressMatch.Count();k++){
        dressSets[setupInf.dressMatch[k]].Add(k.ToString());
        // Debug.Log(setupInf.dressMatch[k]);
        // Debug.Log(k.ToString());
      }
      // dressSets[0].Add("0");//dress
      // dressSets[0].Add("1");
      // dressSets[1].Add("2");//hair
      // dressSets[2].Add("3");//hand
      // dressSets[3].Add("4");//leg
      // dressSets[3].Add("5");

}
public List<string>  setLabel(string category){
  List<string> labelId=new List<string>();
  IEnumerable labels = spriteLibraryAsset.GetCategoryLabelNames(category);
          
  foreach (string label in labels)
  { 
    labelId.Add(label);
  }
  return labelId;
}
  public void fillWardrobe()
    {
      for(int i=0;i<dressSets.Count;i++){    
        ToggleGroup listCategory1=listCategory[i];
        int t=int.Parse(dressSets[i][0]);//select first item of a dress set to show as closet item.

        for(int j=0;j<LabelID[t].Count;j++){
           Sprite sprite=getImage(t,j);
           Item item=null;
          if(sprite==null){  //if it doesnt have an assigned sprite in character sprite library, it means there is a delete item in the closet
            item=Instantiate<Item>(delPref, listCategory1.transform);         
          }
          else{
           item=Instantiate<Item>(itemPref, listCategory1.transform);
          }
          item.id=j;
          item.categoryId=i;
          item.image.sprite=sprite==null?nullsprite:sprite;
          items.Add(item);
          item.toggle.group=listCategory1;
          // item.onDragOk();
          item.gameObject.SetActive(true);
          }
      } 
    }
  
    public void chooseDress(int setId,int dressId,List<SpriteResolver> spriteResolver){

        // spriteResolver[0].SetCategoryAndLabel(categoryL[1],LabelID[1][dressId]);


      //  Debug.Log(int.Parse(dressSets[setId][0]));

        // Debug.Log(categoryL[0]);
        Debug.Log(dressSets[setId].Count);
        // Debug.Log(setId);
        // Debug.Log(dressId);
                // Debug.Log(LabelID[0][dressId]);
      for(int j=0;j<dressSets[setId].Count;j++){
        int cId=int.Parse(dressSets[setId][j]);
 
        spriteResolver[cId].SetCategoryAndLabel(categoryL[cId],LabelID[cId][dressId]);
      }
// Debug.Log("A"+a2+"B"+b2+"C"+c2); //setId a2=2 b2=1 c2=3
// Debug.Log("A"+setId+" /"+dressId);
      if(setId==2)
        a1=dressId;
      else if(setId==1)
        b1=dressId;
      else if(setId==3)
        c1=dressId;
        else if(setId==0)
        d1=dressId;
      if(a1==a2 && b1==b2 && c1==c2 && d1==d2){
       
      StartCoroutine(ShowPanel());
      }
        
    }
    public void nextCharacter(){
     
     int dressid=(c1 + 1) %2;
              chooseDress(3,dressid,spriteResolver);
             // toggle.isOn=true;

    }
      IEnumerator ShowPanel()
        {
          if(startPlaying){
             SoundData.Play();
            yield return new WaitForSeconds(0.5f);
            winPanel.SetActive(true);
          }
        }
    public Sprite getImage(int cId,int dressId){
      return spriteLibraryAsset.GetSprite(categoryL[cId],LabelID[cId][dressId]);
    }
    public void Restart(){
      SceneManager.LoadScene(1);

    } 
    public void Back(){
        SceneManager.LoadScene(0);
    }
}
