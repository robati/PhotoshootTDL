using System;
using UnityEngine;
using UnityEngine.UI;

public class TabMenu : MonoBehaviour
{
    public int Selected { get; private set; } = 0;
    [SerializeField] Transform m_Tabs = null;
    [SerializeField] Transform m_Contents = null;
    GameObject[] m_ContentsArray;

    public void SelectAt(int index)
    {
        _SetActiveContent(m_ContentsArray[index]);
        if (m_Tabs != null)
            _SetActiveTab(m_Tabs.GetChild(index).GetComponent<Button>());

        Selected = index;
    }

    void Start()
    {
        m_ContentsArray = new GameObject[m_Contents.childCount];
        for (int i = 0; i < m_ContentsArray.Length; i++)
            m_ContentsArray[i] = m_Contents.GetChild(i).gameObject;

        if (m_Tabs != null)
        {
            for (int i = 0; i < m_Tabs.childCount; i++)
            {
                var index = i;
                var content = m_ContentsArray[i];
                var button = m_Tabs.GetChild(i).GetComponent<Button>();
                button.onClick.AddListener(() =>
                {
                    _SetActiveContent(content);
                    _SetActiveTab(button);
                    Selected = index;
                });
            }
        }

        _SetActiveContent(m_ContentsArray[0]);
        if (m_Tabs != null)
            _SetActiveTab(m_Tabs.GetChild(0).GetComponent<Button>());
    }

    void _SetActiveContent(GameObject content)
    {
        foreach (var item in m_ContentsArray)
            item.SetActive(false);

        content.SetActive(true);
    }

    void _SetActiveTab(Button tab)
    {
        for (int i = 0; i < m_Tabs.childCount; i++)
            m_Tabs.GetChild(i).GetComponent<Button>().interactable = true;

        tab.interactable = false;
    }
}
