 using UnityEngine.Events;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using UnityEngine;

 public class CustomInputField : InputField {
     public bool Focused = false;
     public bool Deactivated = false;
    //  BaseEventData data = new BaseEventData(UnityEngine.EventSystems.EventSystem);
    // void Start(){
        // base.onEndEdit.RemoveAllListeners();

    // }
    // public SubmitEvent onEndEdit { get; set; }
     new public void ActivateInputField () {
         Focused = true;
         base.ActivateInputField ();
     }

     public override void OnDeselect (BaseEventData eventData) {
         Deactivated = true;
         DeactivateInputField ();
         base.OnDeselect (eventData);
     }
     public override void OnSelect (BaseEventData eventData) {
        //  base.onEndEdit.RemoveAllListeners();
         Deactivated = false;
         ActivateInputField ();
         base.OnSelect (eventData);
     }

     public override void OnPointerClick (PointerEventData eventData) {
         if (Deactivated) {
             MoveTextEnd (true);
             Deactivated = false;
         }
         base.OnPointerClick (eventData);
     }
     public override void OnSubmit (BaseEventData eventData) {
        //  Debug.Log(eventData.selectedObject);
        EventTrigger dsa = base.GetComponent<EventTrigger>();
         base.OnSelect (eventData); 
         Debug.Log(dsa);
     }
    //  public override void onEndEdit()
    //  {
// public override void onEndEdit(){}
    //  }
    //  public override void onEndEdit (BaseEventData eventData) { }
     protected override void LateUpdate () {
         base.LateUpdate ();
        //  Debug.Log(data);
         //  Debug.Log(EventSystem.current.currentSelectedGameObject);
         if (Focused) {
             MoveTextEnd (true);
             Focused = false;
         }
     }
 }