using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class EditorMenuItems
    {
        [MenuItem("Tools/Add 1000 brains")]
        public static void Add1000Brains()
        {
            Datas.Datas.Brain += 1000;
        }

        [MenuItem("Tools/Delete datas")]
        public static void DeleteAllDatas()
        {
            PlayerPrefs.DeleteAll();
        }

    }
}
