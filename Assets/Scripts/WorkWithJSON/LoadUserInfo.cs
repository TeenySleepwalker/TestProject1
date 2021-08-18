using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUserInfo : MonoBehaviour
{
       // Start is called before the first frame update

    void Start()
    {
        Text UserName =   GameObject.Find("UserNameText").GetComponent<Text>();
        Text UserAge = GameObject.Find("UserAgeText").GetComponent<Text>(); ;
        Text UserRelation = GameObject.Find("UserRelationText").GetComponent<Text>(); ;
        UserName.text = InputHandler.entries[OnItemClick.itemIndex].name; //CreateView.userDataList[OnItemClick.itemIndex].userName;
        UserAge.text = InputHandler.entries[OnItemClick.itemIndex].age.ToString(); //CreateView.userDataList[OnItemClick.itemIndex].userAge.ToString();
        UserRelation.text = InputHandler.entries[OnItemClick.itemIndex].relationNamed; //CreateView.userDataList[OnItemClick.itemIndex].userRelation;

    }

  
}
