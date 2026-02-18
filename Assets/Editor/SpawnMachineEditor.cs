using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnMachine))]

public class SpawnMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_enemyPrefab"), 
            new GUIContent("Префаб врагов", "Перетащить сюда префаб, который будет появляться на карте"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_secondsBetweenSpawn"),
            new GUIContent("Время между появлениями", "В секундах"));
        EditorGUILayout.Space();

        SerializedProperty isPresetProp = serializedObject.FindProperty("_isPresetSpawnUsege");

        EditorGUILayout.PropertyField(isPresetProp,
            new GUIContent("Вкл. пресет точек спавна", "Если включено, точки будут расставлены по кругу автоматически"));


        if (isPresetProp.boolValue)
        {
            EditorGUILayout.Space(); 
            EditorGUILayout.LabelField("Настройки пресета спавна:", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(serializedObject.FindProperty("_spawnPoint"),
                new GUIContent("Префаб точки спавна", "Перетащить сюда GameObj, координаты которого будет использоваться для спавна врагов"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_spawnPointsCount"),
                new GUIContent("Количество точек спавна", "Укажите сколько будет точек спавна"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_radiusAroundThisGameObject"),
                new GUIContent("Радиус вокруг родителя", "Радиус окружности вокруг этого объекта, по которому будут создаваться точки спавна"));
        }
        else
        {            
            EditorGUILayout.LabelField("Добавьте точки спавна вручную:", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_manualSpawnPoints"),
                new GUIContent("Точки спавна", "Добавьте сюда объекты, по координатам котороых будут появляться враги"));
        }


        serializedObject.ApplyModifiedProperties();
    }
}