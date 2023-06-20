using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEditor;
using System.Linq;


[ExecuteInEditMode]
public class setup : MonoBehaviour
{
    public SpriteLibrary girlSpriteLibrary ;
    public SpriteLibraryAsset _path;// = "Assets/lib.asset";
     string path;// = "Assets/lib.asset";
     public GameObject characterasset;
     SpriteLibraryAsset asset;//=new SpriteLibraryAsset();
     string fileAddress;//="Assets/Girl/panther_girl_hero.psb";
// [HideInInspector]
    public string[] cloth={"hat","body","legs","mainHat","mainBody","mainLegs"};//"cloth","sleeve","hair","hand","legl","legr"};
//    [HideInInspector]
    public int[] dressMatch={0,1,2,3,3,3};//{0,0,1,2,3,3};// set index for each cloth

     int noneLabelAddCategoryIdx=3;
 private void Start() {

 }
#if UNITY_EDITOR
 public void CreateAssetLib()
 {

     path=AssetDatabase.GetAssetPath(_path);
     fileAddress=AssetDatabase.GetAssetPath(characterasset);
    if(_path!=null){
        asset=_path;
        
    }else{
        path= "Assets/lib.asset";
        asset = ScriptableObject.CreateInstance<SpriteLibraryAsset>();

    }

    Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath( fileAddress ).OfType<Sprite>().ToArray();

    int counter=0;
    for(int i=0;i<sprites.Count();i++){
    
        string[] s=sprites[i].name.Split('_');
        for(int k=0;k<cloth.Count();k++){
            if(s[0]==cloth[k]){
                asset.AddCategoryLabel(sprites[i],cloth[k],sprites[i].name);
                counter++;
                continue;
            }
        }  
    }
    for(int k=0;k<noneLabelAddCategoryIdx;k++){
        asset.AddCategoryLabel(null,cloth[k],"none");
        }
    if(_path==null){
            AssetDatabase.CreateAsset(asset, path);
    }
    AssetDatabase.SaveAssets();

    Debug.Log("created asset library "+path+"- added "+counter+" image.");

    girlSpriteLibrary.spriteLibraryAsset =asset;

    }
#endif
}
