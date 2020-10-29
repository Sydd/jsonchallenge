using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataModelTest
{
    public static DataModel DataModelMock()
    {
        List<string> headers = new List<string>();

        headers.Add("ID");
        headers.Add("Name");
        headers.Add("Role");
        headers.Add("NickName");



        Data data = new Data();
        Data data1 = new Data();
        Data data2 = new Data();
        Data data3 = new Data();
        Data data4 = new Data();



        data.columnsWithValue.Add("ID", "0");
        data.columnsWithValue.Add("Name", "August");
        data.columnsWithValue.Add("Role", "Enginer");
        data.columnsWithValue.Add("NickName", "Killer");

        data1.columnsWithValue.Add("ID", "1");
        data1.columnsWithValue.Add("Name", "Jazmin");
        data1.columnsWithValue.Add("Role", "Designer");
        data1.columnsWithValue.Add("NickName", "Jaz");


        data2.columnsWithValue.Add("ID", "12313");
        data2.columnsWithValue.Add("Name", "Carlos");
        data2.columnsWithValue.Add("Role", "dev");
        data2.columnsWithValue.Add("NickName", "carlosvdev");



        data3.columnsWithValue.Add("ID", "3");
        data3.columnsWithValue.Add("Name", "miriam");
        data3.columnsWithValue.Add("Role", "dancer");
        data3.columnsWithValue.Add("NickName", "dancemiriam");

        data4.columnsWithValue.Add("ID", "123123");
        data4.columnsWithValue.Add("Name", "ñoqui");
        data4.columnsWithValue.Add("Role", "nuncamas");
        data4.columnsWithValue.Add("NickName", "ñoquibarrio");


        List<Data> listData = new List<Data>();

        listData.Add(data);
        listData.Add(data1);
        listData.Add(data2);
        listData.Add(data3);
        listData.Add(data4);


        DataModel test = new DataModel("Test titulo1", headers, listData);

        return test; 
    }
}
