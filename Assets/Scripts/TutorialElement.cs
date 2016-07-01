using UnityEngine;
using UnityEngine.UI;

    public class TutorialElement : MonoBehaviour
    {
        public Text textObject;
        public Image imageObject;

        private bool _showText;
        private float _fadeSpeed = .05f;

        private void Update()
        {
            textObject.color = new Color(
                textObject.color.r, 
                textObject.color.g, 
                textObject.color.b,
                Mathf.Clamp(textObject.color.a + (_showText ? _fadeSpeed : -_fadeSpeed), 0, 1));

        imageObject.color = new Color(
                imageObject.color.r,
                imageObject.color.g,
                imageObject.color.b,
                Mathf.Clamp(textObject.color.a + (_showText ? _fadeSpeed : -_fadeSpeed), 0, 0.9f));
    }

        private void OnTriggerEnter2D(Collider2D col)
        {
            _showText = true;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            _showText = false;
        }
    }