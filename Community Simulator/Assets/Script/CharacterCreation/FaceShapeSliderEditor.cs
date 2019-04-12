using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FaceShapeSliderEditor : Editor
{
    public enum State { auto, manual }
    public State state;
    private FaceShapeSlider FaceShapeSlider;
    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.ExpandHeight(true));

        if (GUILayout.Button("Auto")) state = State.auto;
        if (GUILayout.Button("Manual")) state = State.manual;

        EditorGUILayout.EndHorizontal();

        FaceShapeSlider = (FaceShapeSlider)target;

        switch (state)
        {
            case State.auto: GUI_Auto(); break;
            case State.manual: GUI_Manual(); break;
            default: GUI_Auto(); break;
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
            EditorGUILayout.LabelField("Please have the CharacterCustomizer in your scene!");
            throw new System.Exception("Please have the CharacterCustomizer in your scene!");
        }

        if (characterCustomization.GetNumberOfEntries() <= 0)
            characterCustomization.Initialize();

        string[] FaceShapeNames = characterCustomization.GetBlendShapeNames();

        if (FaceShapeNames.Length <= 0)
            throw new System.Exception("Dictionary Amount is 0 !?");

        int FaceShapeID = 0;   //used to check what the manual is set to of order of dictionary

        for (int i = 0; i < FaceShapeNames.Length; i++)
            if (FaceShapeSlider.ShapeName == FaceShapeNames[i])
                FaceShapeID = i;

        FaceShapeID = EditorGUILayout.Popup("FaceShapeName", FaceShapeID, FaceShapeNames);
        FaceShapeSlider.ShapeName = FaceShapeNames[FaceShapeID];

    }

} 

