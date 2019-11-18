using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
//-----------------------------------------
[System.Serializable]
public class TransformDataXML
{
    public float PosX, PosY, PosZ;
    public float EulerX, EulerY, EulerZ;
    public float ScaleX, ScaleY, ScaleZ;
    public string ObjectName = string.Empty;
}
//-----------------------------------------
[System.Serializable]
[XmlRoot("TransformCollectionXML")]

public class TransformCollectionXML
{
    [XmlArray("Items"), XmlArrayItem("TransformDataXML")]
    public TransformDataXML[] DataArray;
}

public class SerializeTransformXML : MonoBehaviour
{
    public Transform[] TransformArray;
    public string FilePath = "/Saves/MyTransformData.json";
    public TransformCollectionXML MyData;
    //-----------------------------------------
    // Use this for initialization 
    void Start()
    {
        //Get transform component
        TransformArray = Object.FindObjectsOfType<Transform>();
        TransformCollectionXML MyData = new TransformCollectionXML();
    }
    //----------------------------------------- 
    public void SaveData()
    {
        //Create new array
        MyData.DataArray = new TransformDataXML[TransformArray.Length];
        for (int i = 0; i < MyData.DataArray.Length; i++)
        {
            MyData.DataArray[i] = new TransformDataXML();
            MyData.DataArray[i].PosX = TransformArray[i].position.x;
            MyData.DataArray[i].PosY = TransformArray[i].position.y;
            MyData.DataArray[i].PosZ = TransformArray[i].position.z;

            MyData.DataArray[i].EulerX = TransformArray[i].rotation.eulerAngles.x;
            MyData.DataArray[i].EulerY = TransformArray[i].rotation.eulerAngles.y;
            MyData.DataArray[i].EulerZ = TransformArray[i].rotation.eulerAngles.z;

            MyData.DataArray[i].ScaleX = TransformArray[i].localScale.x;
            MyData.DataArray[i].ScaleY = TransformArray[i].localScale.y;
            MyData.DataArray[i].ScaleZ = TransformArray[i].localScale.z;

            MyData.DataArray[i].ObjectName = TransformArray[i].name;

        }

        string SavePath = FilePath;
        XmlSerializer serializer = new XmlSerializer(typeof(TransformCollectionXML));
        FileStream stream = new FileStream(SavePath, FileMode.Create);
        serializer.Serialize(stream, MyData);
        stream.Close();
        Debug.Log("Saving Data To: " + SavePath);
    }
    //-----------------------------------------

    public void LoadData()
    {
        string LoadPath = FilePath;
        var serializer = new XmlSerializer(typeof(TransformCollectionXML));
        var stream = new FileStream(LoadPath, FileMode.Open);
        MyData = serializer.Deserialize(stream) as TransformCollectionXML;
        stream.Close();
        //Update objects        
        for (int i = 0; i < MyData.DataArray.Length; i++)
        {
            //Find object of matching name            
            GameObject Selected = GameObject.Find(MyData.DataArray[i].ObjectName);
            //Get transform component            
            Transform SelectedTransform = Selected.GetComponent<Transform>();
            SelectedTransform.position = new Vector3(MyData.DataArray[i].PosX, MyData.DataArray[i].PosY, MyData.DataArray[i].PosZ);
            SelectedTransform.localScale = new Vector3(MyData.DataArray[i].ScaleX, MyData.DataArray[i].ScaleY, MyData.DataArray[i].ScaleZ);
            SelectedTransform.rotation = Quaternion.Euler(MyData.DataArray[i].EulerX, MyData.DataArray[i].EulerY, MyData.DataArray[i].EulerZ);
        }
    }
    //----------------------------------------- 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) { SaveData(); return; }
        if (Input.GetKeyDown(KeyCode.L)) { LoadData(); return; }
    }
    //-----------------------------------------
}
