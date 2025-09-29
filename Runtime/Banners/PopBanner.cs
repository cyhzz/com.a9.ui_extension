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
            Text txt = generatedPrefab.GetComponentInChildren<Text>();

            if (txt != null)
            {
                txt.text = text;
            }
            else
            {
                TMP_Text textMeshPro = generatedPrefab.GetComponentInChildren<TMP_Text>();
                if (textMeshPro != null)
                {
                    textMeshPro.text = text;
                }
                else
                {
                    Debug.LogError("Text or TextMeshPro component not found on prefab!");
                }
            }
        }

        public GameObject Text(GameObject prefab, string text)
        {
            return Text(prefab, text, grid.position);
        }

        public GameObject Text(GameObject prefab, string text, Vector2 pos)
        {
            GameObject generatedPrefab = Instantiate(prefab, pos, Quaternion.identity, grid);
            Text txt = generatedPrefab.GetComponentInChildren<Text>();

            if (txt != null)
            {
                txt.text = text;
            }
            else
            {
                TMP_Text textMeshPro = generatedPrefab.GetComponentInChildren<TMP_Text>();
                if (textMeshPro != null)
                {
                    textMeshPro.text = text;
                }
                else
                {
                    Debug.LogError("Text or TextMeshPro component not found on prefab!");
                }
            }
            return generatedPrefab;
        }
    }
}