using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Cinemachine;
using Cinemachine.Utility;

public class NPCDialogue3 : MonoBehaviour
{
    //Dialogues
    public AudioSource NPCAudio;
    public GameObject panel;
    public Font _font;
    public Font _TMPfont;
    private GameObject DialogueGO;
    private GameObject myText;
    private GameObject infoText;
    private GameObject infoTextCanvas;
    private Canvas _canvas;
    private Canvas myCanvas;
    private Text text;
    private Text _infoText;
    private RectTransform rectTransform;
    private RectTransform rectTransform2;
    private RectTransform rectTransformTextDC;
    private RectTransform rectTransformButton;
    private RectTransform rectTransformInfoText;
    bool inDialogueSize = false;
    [SerializeField] GameObject DialogueVirtualCamera;
    [SerializeField] GameObject DialogueDollyCart;
    public static bool SecondNPCCanEsc = true;
    public GameObject DialogueContinue;
    public GameObject TextDC;
    public int ContinueCount = 0;
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject Otis;
    [SerializeField] public GameObject _NPC;

    //RectTransform m_RectTransform;

    void Start()
    {
        DialogueDollyCart.SetActive(false);

        DialogueGO = new GameObject();
        DialogueGO.name = "Canvas Dialogue";
        DialogueGO.AddComponent<Canvas>();

        infoTextCanvas = new GameObject();
        infoTextCanvas.name = "Info Canvas";
        infoTextCanvas.AddComponent<Canvas>();
        infoTextCanvas.AddComponent<CanvasScaler>();
        infoTextCanvas.AddComponent<GraphicRaycaster>();
        _canvas = infoTextCanvas.GetComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        panel = new GameObject();

        myCanvas = DialogueGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        DialogueGO.AddComponent<CanvasScaler>();
        DialogueGO.AddComponent<GraphicRaycaster>();


        //Panel Settings
        panel.transform.parent = DialogueGO.transform;
        panel.AddComponent<Image>();
        panel.GetComponent<Image>().color = new Color32(55, 55, 55, 237);
        panel.GetComponent<Image>().raycastTarget = true;
        panel.GetComponent<Image>().maskable = true;
        panel.GetComponent<Transform>().localPosition = new Vector3(0, -194, 0f);
        panel.GetComponent<Transform>().localScale = new Vector3(11.68f, 2.56f, 1);
        DialogueGO.SetActive(false);


        // Text
        myText = new GameObject();
        myText.transform.parent = DialogueGO.transform;
        myText.name = "Dialogue";
        myText.transform.SetSiblingIndex(666);
        text = myText.AddComponent<Text>();
        text.transform.GetComponent<Text>().text = "Etrafta gezinen bu yaratýklarýn sana zarar vermeyeceðini düþünme, onlar saldýrgan varlýklar. Eðer lavýn yanýna bile yaklaþýrsan erimiþ metalin içinde kaybolup gidersin.";
        text.transform.GetComponent<Text>().font = _font;
        text.transform.GetComponent<Text>().fontSize = 29;
        rectTransform = myText.GetComponent<RectTransform>();


        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -229, 0);
        rectTransform.sizeDelta = new Vector2(1071, 243);
        rectTransform2 = text.GetComponent<RectTransform>();
        rectTransform2.localPosition = new Vector3(0, -229, 0);
        rectTransform2.sizeDelta = new Vector2(1071, 243);

        // Info Text
        infoText = new GameObject();
        infoText.name = "Info Text";
        infoText.transform.parent = infoTextCanvas.transform;
        infoText.transform.SetSiblingIndex(666);
        _infoText = infoText.AddComponent<Text>();
        _infoText.transform.GetComponent<Text>().text = "Konusmak icin F'ye basin.";
        _infoText.transform.GetComponent<Text>().font = _font;
        _infoText.transform.GetComponent<Text>().fontSize = 29;
        _infoText.transform.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        _infoText.transform.GetComponent<Text>().alignment = TextAnchor.LowerCenter;


        rectTransformInfoText = _infoText.GetComponent<RectTransform>();
        rectTransformInfoText.localPosition = new Vector3(0, -472f, 0);
        rectTransformInfoText.sizeDelta = new Vector2(858.4f, 137f);
        infoText.transform.GetComponent<Text>().fontSize = 53; ;
        rectTransformInfoText = infoText.GetComponent<RectTransform>();


        //Button
        DialogueContinue = new GameObject();
        TextDC = new GameObject();
        DialogueContinue.transform.parent = DialogueGO.transform;
        TextDC.transform.parent = DialogueContinue.transform;
        TextDC.name = "Text";
        DialogueContinue.name = "Continue Button";
        DialogueContinue.AddComponent<CanvasRenderer>();
        TextDC.AddComponent<Text>();
        DialogueContinue.AddComponent<Image>();
        DialogueContinue.GetComponent<Image>().color = new Color32(1, 1, 1, 0);
        DialogueContinue.AddComponent<Button>();
        DialogueContinue.transform.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        DialogueContinue.transform.GetComponent<Transform>().localPosition = new Vector3(427, -274, 0);
        rectTransformButton = TextDC.GetComponent<RectTransform>();
        rectTransformTextDC = DialogueContinue.GetComponent<RectTransform>();
        rectTransformTextDC.sizeDelta = new Vector2(172, 82);
        rectTransformButton.sizeDelta = new Vector2(315, 100);
        TextDC.transform.GetComponent<Text>().text = "Devam et";
        TextDC.transform.GetComponent<Text>().font = _font;
        TextDC.transform.GetComponent<Text>().fontSize = 45;
        TextDC.transform.GetComponent<Transform>().localPosition = new Vector3(88.9f, -20, 0);
        DialogueContinue.GetComponent<Button>().onClick.AddListener(() => DialogueContinueOnClickEvent());

        infoTextCanvas.SetActive(false);
        DialogueGO.SetActive(false);

    }

    void DialogueContinueOnClickEvent()
    {
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        infoTextCanvas.SetActive(true);
        DialogueGO.SetActive(false);
        DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        infoTextCanvas.SetActive(true);
        SecondNPCCanEsc = true;
        //StartCoroutine(LightsScript());
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Key"))
        {
            inDialogueSize = true;
            infoTextCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inDialogueSize = false;
        infoTextCanvas.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && inDialogueSize == true)
        {
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().LookAt = _NPC.transform;
            infoTextCanvas.SetActive(false);
            DialogueGO.SetActive(true);
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            DialogueDollyCart.SetActive(true);
            SecondNPCCanEsc = false;
            Cursor.visible = true;
            NPCAudio.Play();
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            //_NPC.gameObject.tag = "Key";
        }
    }
    /*IEnumerator LightsScript()
    {
        yield return new WaitForSeconds(1.5f);
        PickUp.Light1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PickUp.Light2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PickUp.Light3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PickUp.Light4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PickUp.Light5.SetActive(true);


    }
    */

}