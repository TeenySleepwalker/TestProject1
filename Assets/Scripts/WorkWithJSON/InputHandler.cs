using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {
    [SerializeField] InputField nameInput;
   // [SerializeField] 
    string filename= "/info.dat";

    public GameObject _itemObject;//= new GameObject();
    GameObject objectItems;// = new GameObject();

    public static List<InputEntry> entries = new List<InputEntry> ();

    private void Start () {
        entries = FileHandler.ReadListFromJSON<InputEntry>(filename);
        for (int i = 0; i <= entries.Count - 1; i++)
        {
            objectItems = Instantiate(_itemObject, transform);
            objectItems.name = "Item" + i;
            objectItems.transform.GetChild(0).GetComponent<Text>().text = entries[i].name;
            objectItems.transform.GetChild(1).GetComponent<Text>().text = entries[i].age.ToString();

            if (entries[i].relation == 0)
            {
                entries[i].relationNamed = "Свободен";
            }
            if (entries[i].relation == 1)
            {
                entries[i].relationNamed = "В браке";
            }
            Debug.Log(entries[i].name + "  " + entries[i].age.ToString());
        }
      



    }

}