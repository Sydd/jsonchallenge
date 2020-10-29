using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DataModel
{
    public DataModel(string title, List<string> columnHeaders, List<Data> data)
    {
        this.tittle = title;

        this.columnHeaders = columnHeaders;

        this.data = data;
      }

    public string tittle;

    public List<string> columnHeaders;

    public List<Data> data;

}

[Serializable]
public class Data
{

    public Dictionary<string, string> columnsWithValue;

    public Data()
    {
        columnsWithValue = new Dictionary<string, string>();
    }

    public Data(Dictionary<string,string> keyValuePairs)
    {
        columnsWithValue = keyValuePairs;
    }
}
