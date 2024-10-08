using Com.A9.Singleton;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Com.A9.UIExt
{
    public class PopBanner : Singleton<PopBanner>
    {
        public Transform grid;
        public GameObject prefab;

        public void Show(string text)
        {
            GameObject generatedPrefab = Instantiate(prefab, grid);
            Text textMeshPro = generatedPrefab.GetComponentInChildren<Text>();

            if (textMeshPro != null)
            {
                textMeshPro.text = text;
            }
            else
            {
                Debug.LogError("TextMeshPro component not found on prefab!");
            }
        }

        public void Text(GameObject prefab, string text, Vector2 pos)
        {
            GameObject generatedPrefab = Instantiate(prefab, pos, Quaternion.identity, grid);
            TMP_Text textMeshPro = generatedPrefab.GetComponentInChildren<TMP_Text>();

            if (textMeshPro != null)
            {
                textMeshPro.text = text;
            }
            else
            {
                Debug.LogError("TextMeshPro component not found on prefab!");
            }
        }
    }
}