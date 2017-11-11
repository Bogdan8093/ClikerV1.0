using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class switchTabs : MonoBehaviour {
    // public GameObject[] SwitchFromContainer, SwitchToContainer;
    public GameObject PUI_TabContainer, PUI_ContentContainer;
    public int DefaultTab;
    public float UP_Speed, UP_Coeff, UP_Height;
    private List<GameObject> PUI_Tabs = new List<GameObject>();
    private List<GameObject> PUI_Content = new List<GameObject>();
    void Awake() {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => StartCoroutine(PUI_Switch_Tab(data)));
        for (int i = 0; i < PUI_TabContainer.transform.childCount; i++) {
            PUI_Content.Add(PUI_ContentContainer.transform.GetChild(i).gameObject);
            GameObject obj = PUI_TabContainer.transform.GetChild(i).gameObject;
            PUI_Tabs.Add(obj);
            obj.AddComponent<EventTrigger>().triggers.Add(entry);
            obj.AddComponent<Selectable>();
        }
        PUI_Content[DefaultTab - 1].SetActive(true);
        PUI_Tabs[DefaultTab - 1].transform.localPosition = new Vector2(PUI_Tabs[DefaultTab - 1].transform.localPosition.x, 0);
    }
    IEnumerator PUI_Switch_Tab(BaseEventData data) {
        yield return new WaitUntil(() => data.selectedObject != null);
        int index = PUI_Tabs.FindIndex((o) => o == data.selectedObject);
        if (!PUI_Content[index].activeSelf) {
            PUI_Content.ForEach((status) => {
                if (status.activeSelf) {
                    status.SetActive(false);
                    GameObject obj = PUI_Tabs[PUI_Content.FindIndex((o) => o == status)];
                    obj.transform.localPosition = new Vector2(obj.transform.localPosition.x, UP_Height);
                }
            });
            PUI_Content[index].SetActive(true);
            StartCoroutine(UP(index));
        }
    }
    IEnumerator UP(int index) {
        bool Active_Status = true;
        float[] pos = new float[2];
        pos[0] = PUI_Tabs[index].transform.localPosition.x;
        pos[1] = PUI_Tabs[index].transform.localPosition.y;
        while (PUI_Tabs[index].transform.localPosition.y != 0 && Active_Status) {
            pos[1] += UP_Coeff;
            if (pos[1] > 0)
                pos[1] = 0;
            if (!PUI_Content[index].activeSelf) {
                pos[1] = UP_Height;
                Active_Status = false;
            } else {
                yield return new WaitForSeconds(UP_Speed);
            }
            PUI_Tabs[index].transform.localPosition = new Vector2(pos[0], pos[1]);
        }

    }
}