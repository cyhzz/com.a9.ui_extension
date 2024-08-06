using System;
using System.Collections;
using System.Collections.Generic;
using Com.A9.Singleton;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pageable : MonoBehaviour
{
    public Button up;
    public Button down;

    public int current_page;
    public int max_page;
    public int CurrentPage
    {
        get
        {
            return current_page;
        }
        set
        {
            current_page = value;
            OnPageChanged?.Invoke();
        }
    }

    public UnityEvent OnPageChanged;

    void Awake()
    {
        up.onClick.AddListener(PageUp);
        down.onClick.AddListener(PageDown);
        RefreshButtonState();
    }

    public void PageUp()
    {
        CurrentPage--;
        RefreshButtonState();
    }

    public void PageDown()
    {
        CurrentPage++;
        RefreshButtonState();
    }

    void RefreshButtonState()
    {
        up.interactable = current_page > 0;
        down.interactable = max_page > current_page;
    }
}
