using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PercentHoverLeft : MonoBehaviour
{
     private static PercentHoverLeft instance;
    private Text hoverText;
    private RectTransform backgroundRectTransform;
    
    [SerializeField] private Camera uiCamera;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
        backgroundRectTransform = transform.Find("backgroundLeft").GetComponent<RectTransform>();
        hoverText = transform.Find("textLeft").GetComponent<Text>();
        
    }
    private void ShowHover(int shotPercent){
        gameObject.SetActive(true);
        hoverText.text =  "Shot Chance: " + shotPercent.ToString() + "%";        
        // print("this was called + " + shotPercent.ToString());
    }

    private void HideHover(){
        gameObject.SetActive(false);
    }

    void Update() {
        // Vector2 localPoint;
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),Input.mousePosition, uiCamera, out localPoint);
        // transform.localPosition = localPoint;
    }

   public static void ShowHover_Static(int shotPercent){
       instance.ShowHover(shotPercent);

   }
   public static void HideHover_Static(){
       instance.HideHover();
   }
}
