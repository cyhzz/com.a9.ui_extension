using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace Com.A9.UIExt
{
    [System.Serializable]
    public class DropDownItem
    {
        public string text;
        public Sprite sp;
    }

    public class InfiniteDropDown : MonoBehaviour
    {
        public int caption;
        public Button caption_button;
        public List<DropDownItem> items;
        public InfiniteScroll presenter;
        public UnityEvent OnValueChanged;
        public Image caption_img;
        public Text caption_text;
        public Button exit_button;

        void Start()
        {
            presenter.OnFill += OnFillItem;
            presenter.OnHeight += OnHeightItem;
            presenter.InitData(items.Count);
            // ChangeValueWithOutNotify(0);
            caption_button.onClick.AddListener(() =>
            {
                presenter.transform.localPosition = Vector3.zero;
            });

            exit_button.onClick.AddListener(() =>
            {
                presenter.transform.localPosition = new Vector3(10000, 10000);
            });
            presenter.transform.localPosition = new Vector3(10000, 10000);
        }

        void OnFillItem(int index, GameObject item)
        {
            item.GetComponentsInChildren<Image>()[1].sprite = items[index].sp;
            item.GetComponentInChildren<Text>().text = items[index].text;
            item.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            item.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                ChangeValue(index);
            });
        }

        void ChangeValue(int idx)
        {
            ChangeValueWithOutNotify(idx);
            presenter.transform.localPosition = new Vector3(10000, 10000);
            OnValueChanged?.Invoke();
        }

        public void ChangeValueWithOutNotify(int idx)
        {
            caption = idx;
            caption_text.text = items[idx].text;
            caption_img.sprite = items[idx].sp;
        }

        int OnHeightItem(int index)
        {
            return (int)presenter.prefab.GetComponent<RectTransform>().sizeDelta.y;
        }
    }
}