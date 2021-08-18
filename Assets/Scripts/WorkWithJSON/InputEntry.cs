using System;

[Serializable]
public class InputEntry {
    public string name;
    public int age;
    public int relation;
    public string relationNamed;

    public InputEntry (string _name, int _age, int _relation) {
        name = _name;
        age = _age;
        relation = _relation;
    }
}



