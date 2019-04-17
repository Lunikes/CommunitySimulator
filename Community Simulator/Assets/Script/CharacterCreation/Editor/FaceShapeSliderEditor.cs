
using UnityEngine;
using UnityEditor;

public class FaceShapeSliderEditor : Editor
{
    public enum State { auto, manual }
    public State state;
    private FaceShapeSlider FaceShapeSlider;
    public void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.ExpandHeight(true));

        if (GUILayout.Button("Auto")) state = State.auto;
        if (GUILayout.Button("Manual")) state = State.manual;

        EditorGUILayout.EndHorizontal();

        FaceShapeSlider = (FaceShapeSlider)target;

        switch (state)
        {
            case State.auto: GUI_Auto();
                break;
            case State.manual: GUI_Manual();
                break;
            default: GUI_Auto();
                break;
        }


    }

    private void GUI_Manual()
    {
        base.OnInspectorGUI();
    }

    private void GUI_Auto()
    {
       
        characterCustomization characterCustomization = GameObject.FindObjectOfType<characterCustomization>();

        if (characterCustomization == null)
        {
            EditorGUILayout.LabelField("Character Customizer not scene");
            throw new System.Exception("Character Customizer not scene");
        }

        if (characterCustomization.GetNumberOfEntries() <= 0)
        {
            characterCustomization.Initialize();
        }
        /*string[] FaceShapeNames = characterCustomization.GetBlendFaceNames();

        if (FaceShapeNames.Length <= 0)
        {
            throw new System.Exception("Dictionary is empty");
        }
        int FaceShapeID = 0;
        for (int i = 0; i < FaceShapeNames.Length; i++)
        {
            if (FaceShapeSlider.ShapeName == FaceShapeNames[i])
            {
                FaceShapeID = i;
            }
        }
        FaceShapeID = EditorGUILayout.Popup("FaceShapeName", FaceShapeID, FaceShapeNames);
        FaceShapeSlider.ShapeName = FaceShapeNames[FaceShapeID];
        */
    }

} 

