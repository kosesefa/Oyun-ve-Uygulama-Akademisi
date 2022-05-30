using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Cinemachine;
using Cinemachine.Utility;

public class NPCDialogue : MonoBehaviour
{
    //Dialogues
    /*[SerializeField] string Dialogue1;
    [SerializeField] string Dialogue2;
    [SerializeField] string Dialogue3;
    [SerializeField] string Dialogue4;
    [SerializeField] string Dialogue5;
    [SerializeField] string Dialogue6;
    [SerializeField] string Dialogue7;
    */
    //Canvas TextPanel = new Canvas();
    public GameObject panel;
    public Font _font;
    private GameObject myGO;
    private GameObject myText;
    private Canvas myCanvas;
    private Text text;
    private RectTransform rectTransform;
    private RectTransform rectTransformTextDC;
    private RectTransform rectTransformButton;
    bool inDialogueSize = false;
    [SerializeField] GameObject DialogueVirtualCamera;
    [SerializeField] GameObject DialogueDollyCart;
    public static bool canEsc = true;
    public GameObject DialogueContinue;
    public GameObject TextDC;



    //RectTransform m_RectTransform;

    void Start()
    {
        DialogueDollyCart.SetActive(false);


        Rect rect = new Rect(1071.2f, 243.1f, 1071.2f, 243.1f);
        rect.height = 243.1f;
        rect.width = 1071.2f;

        myGO = new GameObject();
        myGO.name = "Canvas Dialogue";
        myGO.AddComponent<Canvas>();

        panel = new GameObject();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();




        //Panel Settings
        panel.transform.parent = myGO.transform;
        panel.AddComponent<Image>();
        panel.GetComponent<Image>().color = new Color32(55, 55, 55, 237);
        panel.GetComponent<Image>().raycastTarget = true;
        panel.GetComponent<Image>().maskable = true;
        panel.GetComponent<Transform>().localPosition = new Vector3(0, -316.72f, 0f);
        panel.GetComponent<Transform>().localScale = new Vector3(11.68f, 2.56f, 1);
        panel.tag = "DialogueScreen";


        // Text
        myText = new GameObject();
        myText.name = "Dialogue";
        myText.tag = "DialogueScreen";
        myText.transform.SetSiblingIndex(666);
        text = myText.AddComponent<Text>();
        text.transform.GetComponent<Text>().text = "“…- different grunts and deep voices-…Human… Those who come here fail to see how surprising reality can be.The eyes given to you are only for seeing, you cannot look beyond… There is a door on the hill ahead.You will need the most primitive human intelligence to open this door.It is waiting for you behind another door.";
        text.transform.GetComponent<Text>().font = _font;
        text.transform.GetComponent<Text>().fontSize = 29;
        rectTransform = myText.GetComponent<RectTransform>();


        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -360, 0);
        rectTransform.sizeDelta = new Vector2(1071, 243);


        //Button
        DialogueContinue = new GameObject();
        TextDC = new GameObject();
        DialogueContinue.transform.parent = myGO.transform;
        TextDC.transform.parent = DialogueContinue.transform;
        TextDC.name = "Text";
        DialogueContinue.name = "Continue Button";
        DialogueContinue.AddComponent<CanvasRenderer>();
        TextDC.AddComponent<Text>();
        DialogueContinue.AddComponent<Image>();
        DialogueContinue.GetComponent<Image>().color = new Color32(1, 1, 1, 0);
        DialogueContinue.AddComponent<Button>();
        DialogueContinue.transform.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        DialogueContinue.transform.GetComponent<Transform>().localPosition = new Vector3(427, -383, 0);
        rectTransformButton = TextDC.GetComponent<RectTransform>();
        rectTransformTextDC = DialogueContinue.GetComponent<RectTransform>();
        rectTransformTextDC.sizeDelta = new Vector2(172, 82);
        rectTransformButton.sizeDelta = new Vector2(315, 100);
        TextDC.transform.GetComponent<Text>().text = "Continue";
        TextDC.transform.GetComponent<Text>().font = _font;
        TextDC.transform.GetComponent<Text>().fontSize = 45;
        TextDC.transform.GetComponent<Transform>().localPosition = new Vector3(88.9f, -33, 0);
        DialogueContinue.GetComponent<Button>().onClick.AddListener(() => DialogueContinueOnClickEvent());


        myGO.SetActive(false);

    }

    void DialogueContinueOnClickEvent()
    {
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        myGO.SetActive(false);
        //inDialogueSize = false;

    }

    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("OnColliderEnter");
        inDialogueSize = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inDialogueSize = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && inDialogueSize == true)
        {
            myGO.SetActive(true);
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 11;
            DialogueDollyCart.SetActive(true);
            Debug.Log("Ýçinde");
            canEsc = false;
            Cursor.visible = true;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            ControllerDisable();

        }
    }
    public void ControllerDisable()
    {

    }
    public void ControllerEnable()
    {

    }
}
