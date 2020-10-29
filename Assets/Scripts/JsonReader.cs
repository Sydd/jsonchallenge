using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



public class JsonReader
{
    private readonly static JsonReader instance = new JsonReader();

    public static JsonReader Instance
    {
        get => instance;
    }

        
    public DataModel ReadJson(string path)
    {
            
        string jsonFile = System.IO.File.ReadAllText(path);

        var jo = JObject.Parse(jsonFile);

        List<string> titles = new List<string>();
 
        IEnumerable enumerableTitles = jo["ColumnHeaders"].Values<string>();

        
        foreach (var title in enumerableTitles)
        {
            titles.Add(title.ToString());
        }


        if (titles.Count < 1)
        {
            //Our json doesnt have the columnheaders field.
            Debug.LogError("TITLES JSON OBJECT NOT FOUND.");

            return null;
        }

        string jsonTitle = jo["Title"].ToString();


        IEnumerable dataResult = jo["Data"].Values<JObject>();


        List<Data> fullData = new List<Data>();


        foreach (JObject item in dataResult)
        {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            //We check if the fields are the same as the headers declarated in the columnHeaders field.
            if (item.Count != titles.Count)
            {
                Debug.LogError("ONE OF THE DATA ITEMS HAS MORE FIELDS THAN THE DECLARATED IN THE HEADERS.");

            }

            //We add to the model only the data that is in the columnHeaders.

            titles.ForEach(title =>
            {
                JToken value;

                //We try to get the value of the title 
                if (item.TryGetValue(title, out value))
                {

                    //We add it to the Dictionary.

                    keyValuePairs.Add(title, value.ToString());

                } else
                {

                    //This shouldnt happen.

                    Debug.LogError("THE ITEM DATA DOES NOT HAVE THE FIELD " + title);

                }

            });

            Data data = new Data(keyValuePairs);

            fullData.Add(data);

        }



        return new DataModel(jsonTitle,titles, fullData);
    }

    Data ParseObjectToData(JObject data)
    {
        return null;
    }
}
