using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class saveCarMesh : MonoBehaviour
{
    MeshFilter[] meshFilter;
    public string path;
    public SerVector3 dateaa;
    public Vector3 vec;
    private void Awake()
    {
        path = Application.persistentDataPath + "RCC_DEFCARM.csmd";
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        //meshFilter = GetComponent<RCC_CarControllerV3>().deformableMeshFilters;

        bf.Serialize(stream, new CarMeshData(meshFilter));
        stream.Close();
    }

    public void DeleteSave()
    {
        if (File.Exists(path))
            File.Delete(path);
    }

    public void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CarMeshData carMeshData = bf.Deserialize(stream) as CarMeshData;
            stream.Close();
            //meshFilter = GetComponent<RCC_CarControllerV3>().deformableMeshFilters;
            for(int i = 0; i < carMeshData.l; i++)
            {
                meshFilter[i].mesh.vertices = SerVector3.UnConv(carMeshData.vertecies[i]);
            }
        }
    }

    [System.Serializable]
    public class CarMeshData
    {
        public int l;
        public List<SerVector3[]> lvertecies = new List<SerVector3[]>();
        public SerVector3[][] vertecies;
        public CarMeshData(MeshFilter[] mf)
        {
            l = mf.Length;
            for(int i = 0; i < l; i++)
            {
                if(mf[i] != null)
                {
                    lvertecies.Add(SerVector3.TabConv(mf[i].mesh.vertices));
                }
            }
            vertecies = lvertecies.ToArray();
        }
    }
}

[System.Serializable]
public class SerVector3
{
    public float x, y, z;
    public SerVector3(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }
    public static SerVector3[] TabConv(Vector3[] v)
    {
        List<SerVector3> sv = new List<SerVector3>();
        for(int i = 0; i < v.Length; i++)
        {
            sv.Add(new SerVector3(v[i]));
        }
        return sv.ToArray();
    }

    public static Vector3[] UnConv(SerVector3[] sv)
    {
        List<Vector3> v = new List<Vector3>();
        for (int i = 0; i < sv.Length; i++)
        {
            v.Add(new Vector3(sv[i].x,sv[i].y,sv[i].z));
        }
        return v.ToArray();
    }
}
