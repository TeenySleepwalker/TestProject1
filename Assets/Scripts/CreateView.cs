using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//директивы для сериализации данных
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using System.Threading.Tasks;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using UnityEngine.EventSystems;
[System.Serializable]
public class UserData
{
    public string userName;
    public int userAge;
    public string userRelation;
   }

public class CreateView : MonoBehaviour
{
    public static List<UserData> userDataList;
    public GameObject _itemObject;//= new GameObject();
    GameObject objectItems;// = new GameObject();
    string usersDataFromFile;
    string fileName = "/info.dat";

    string userName, relationStatus;
    int userAge, userRelation;


    // Start is called before the first frame update
    void Start()
    {

        int i = 0; // счетчик для коллекции List
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + fileName);
            usersDataFromFile = sr.ReadToEnd();
            if (sr != null)
            {
                bool EOF = false; //счетчик конца файла true-достигли, false-не достигли, продолжаем цикл
                userDataList = new List<UserData>();
                usersDataFromFile = usersDataFromFile.Remove(0, usersDataFromFile.IndexOf('[') + 3);
                while (EOF != true)
                {
                    usersDataFromFile = usersDataFromFile.Remove(0, 7);//убираем все символы до тега name
                    userName = usersDataFromFile.Substring(0, usersDataFromFile.IndexOf(@""","));
                    usersDataFromFile = usersDataFromFile.Remove(0, usersDataFromFile.IndexOf(@""",") + 8);
                    int.TryParse(usersDataFromFile.Substring(0, usersDataFromFile.IndexOf(",")), out userAge);
                    usersDataFromFile = usersDataFromFile.Remove(0, usersDataFromFile.IndexOf(",") + 12);
                    int.TryParse(usersDataFromFile.Substring(0, usersDataFromFile.IndexOf("}")), out userRelation);

                    if (userRelation == 0)
                        relationStatus = "Свободен";
                    if (userRelation == 1)
                        relationStatus = "В браке";
                    userDataList.Add(new UserData() { userName = userName, userAge = userAge, userRelation = relationStatus});
                    //копирование моего Item и задание дочерним компонентам значения
                                        
                    objectItems = Instantiate(_itemObject, transform);
                    objectItems.name = "Item" + i;
                    objectItems.transform.GetChild(0).GetComponent<Text>().text = userDataList[i].userName;
                    objectItems.transform.GetChild(1).GetComponent<Text>().text = userDataList[i].userAge.ToString();
                    
                    if (usersDataFromFile.IndexOf("name") == -1) //если в тексте нет тега name то данных пользователя нет
                    {
                        EOF = true;
                    }
                    else
                    {
                        usersDataFromFile = usersDataFromFile.Remove(0, usersDataFromFile.IndexOf("}") + 4); //иначе удаляем символы до следующего тега name
                        i++;
                    }
                }
            }
        }

    }
    void CreateItems()
    { 
       
    }
   /*  public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.selectedObject.name);
    }*/
     
            // Update is called once per frame
            void Update()
            {
  
            }




}

