using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;


public class GameConfiguration : MonoBehaviour
{
    [Header("Json Challenge File")]
    public InputField jsonFile;

    public Action<DataModel> OnLoad;

    public Action OnStartLoading;

    public Action OnFileNotFoundException;

    public void Read()
    {
        
        if(OnStartLoading != null)
        {
            OnStartLoading();
        }

        LoadJson();


    }


    async void LoadJson()
    {

        try
        {
            DataModel fullData = await Task<DataModel>.Run(() => JsonReader.Instance.ReadJson(Application.streamingAssetsPath + "\\" + jsonFile.text));


            if (OnLoad != null)
            {

                OnLoad(fullData);
            }
        }
        catch (System.IO.FileNotFoundException exp)
        {

            if (OnFileNotFoundException != null)
            {

                OnFileNotFoundException();
            }
        }


    }


}
