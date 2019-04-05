using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]

    public class FaceShapeSlider : MonoBehaviour
    {
        public string ShapeName;
        private Slider slider;
        private void Start()
        {
            ShapeName = ShapeName.Trim();
            GetComponent<Slider>();

            slider.onValueChanged.AddListener(value => characterCustomization.Instance.ChangeBlendshapeValue(ShapeName, value));

        }
    }

