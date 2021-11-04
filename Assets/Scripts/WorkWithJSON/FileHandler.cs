using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class FileHandler {
    public static List<T> ReadListFromJSON<T> (string filename) {
        string content = ReadFile (GetPath (filename));
        
        if (string.IsNullOrEmpty (content) || content == "{}") {
            return new List<T> ();
        }

        List<T> res = JsonHelper.FromJson<T> (content).ToList ();
        
        return res;

    }


    private static string GetPath (string filename) {
     /*   string filepath;
             #if UNITY_ANDROID
             //чтение файла для андроид платформы
             WWW wwwFile =new WWW ("jar:file://" + Application.dataPath + "!/assets/"+filename);
             while (!wwwFile.isDone) { }
              filepath = string.Format("{0}/{1}", Application.persistentDataPath, "info.dat");
           Debug.Log("1     "+filepath);
             File.WriteAllBytes(filepath, wwwFile.bytes);
             return filepath;

#endif

        //чтение файла для винды

#if !UNITY_ANDROID*/

        // filepath = Application.persistentDataPath + "/" + filename;
        // Debug.Log(Application.persistentDataPath + "/" + filename);
        return Application.persistentDataPath + "/" + filename;

//        return filepath;
        // Debug.Log(filepath);
//#endif



      /*  Debug.Log(Application.persistentDataPath + "/" + filename);
        return Application.persistentDataPath + "/" + filename;*/

    }


    private static string ReadFile (string path) {
        if (File.Exists (path)) {
            using (StreamReader reader = new StreamReader (path)) {
                string content = reader.ReadToEnd ();
                return content;
            }
        }
        return "";
    }
}

public static class JsonHelper {
    public static T[] FromJson<T> (string json) {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (json);
        return wrapper.users;
    }

    [Serializable]
    private class Wrapper<T> {
        public T[] users;
    }
}