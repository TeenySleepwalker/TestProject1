using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnItemClick : MonoBehaviour, IPointerClickHandler 
{
    //    ScrollView myView;   


    // Start is called before the first frame update
    public static int itemIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        var myitem= eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<UnityEngine.UI.Image>();

        int.TryParse(myitem.name.Substring(4, myitem.name.Length - 4), out itemIndex);
        //itemIndex = myitem.name.Substring(4, myitem.name.Length);

        Debug.Log(itemIndex);
        SceneManager.LoadScene("InfoScena");
    }


}

