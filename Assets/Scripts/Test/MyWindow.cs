using UnityEditor;
using UnityEngine;

namespace Test
{
    public class MyWindow : EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public string _nameObject = "Cletka";
        public bool _groupEnabled;
        public bool _randomColor = true;
        public int _countObject = 1;
        public float _radius = 4;

        private void OnGUI()
        {
            GUILayout.Label("������� ���������", EditorStyles.boldLabel);
            ObjectInstantiate = EditorGUILayout.ObjectField("������ ������� �����", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("��� �������", _nameObject);
            _groupEnabled = EditorGUILayout.BeginToggleGroup("�������������� ���������", _groupEnabled);
            _randomColor = EditorGUILayout.Toggle("��������� ����", _randomColor);
            _countObject = EditorGUILayout.IntSlider("���������� ��������", _countObject, 1, 12);
            _radius = EditorGUILayout.Slider("������ ����������", _radius, 6, 10);
            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("������� �������");
            if (button)
            {
                if (ObjectInstantiate)
                {
                    GameObject root = new GameObject("Root");
                    for (int i = 0; i < _countObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();
                        if (tempRenderer && _randomColor)
                        {
                            tempRenderer.material.color = Random.ColorHSV();
                        }
                    }
                }
            }
        }
    }
}