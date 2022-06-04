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
    public AudioSource NPCAudio;
    public GameObject panel;
    public Font _font;
    public Font _TMPfont;
    private GameObject DialogueGO;
    private GameObject myText;
    private GameObject myText2;
    private GameObject infoText;
    private GameObject infoTextCanvas;
    private Canvas _canvas;
    private Canvas myCanvas;
    private Text text;
    private Text _infoText;
    private RectTransform rectTransform;
    private RectTransform rectTransformTextDC;
    private RectTransform rectTransformButton;
    private RectTransform rectTransformInfoText;
    bool inDialogueSize = false;
    [SerializeField] GameObject DialogueVirtualCamera;
    [SerializeField] GameObject DialogueDollyCart;
    public static bool canEsc = true;
    public GameObject DialogueContinue;
    public GameObject TextDC;
    public int ContinueCount = 0;
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject Otis;
    //private string Line1 = "…- deðiþik homurtular ve derin sesler-… ";
    //private string Line2 = "Ýnsan… Buraya gelenler gerçekliðin ne kadar þaþýrtýcý olabileceðini göremiyorlar. Size verilen gözler sadece görmenize yarýyor, daha ötesine bakamýyorsunuz… Ýleride, tepede bir kapý var. Bu kapýyý açabilmek için en ilkel insan zekasýna ihtiyacýn olacak. Baþka bir kapýnýn ardýnda seni bekliyor.”";


    //RectTransform m_RectTransform;

    void Start()
    {
        DialogueDollyCart.SetActive(false);

        Rect rect = new Rect(1071.2f, 243.1f, 1071.2f, 243.1f);
        rect.height = 243.1f;
        rect.width = 1071.2f;

        DialogueGO = new GameObject();
        DialogueGO.name = "Canvas Dialogue";
        DialogueGO.AddComponent<Canvas>();

        infoTextCanvas = new GameObject();
        infoTextCanvas.name = "Ýnfo Canvas";
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
        text.transform.GetComponent<Text>().text = "…- deðiþik homurtular ve derin sesler-… " + "\n\nÝnsan… Buraya gelenler gerçekliðin ne kadar þaþýrtýcý olabileceðini göremiyorlar. Size verilen gözler sadece görmenize yarýyor, daha ötesine bakamýyorsunuz… Ýleride, tepede bir kapý var. Bu kapýyý açabilmek için en ilkel insan zekasýna ihtiyacýn olacak. Baþka bir kapýnýn ardýnda seni bekliyor.”";
        text.transform.GetComponent<Text>().font = _font;
        text.transform.GetComponent<Text>().fontSize = 29;
        rectTransform = myText.GetComponent<RectTransform>();


        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -229, 0);
        rectTransform.sizeDelta = new Vector2(1071, 243);

        // Info Text
        infoText = new GameObject();
        infoText.name = "Info Text";
        infoText.transform.parent = infoTextCanvas.transform;
        infoText.transform.SetSiblingIndex(666);
        _infoText = infoText.AddComponent<Text>();
        _infoText.transform.GetComponent<Text>().text = "Press F to Talk";
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
        TextDC.transform.GetComponent<Text>().text = "Continue";
        TextDC.transform.GetComponent<Text>().font = _font;
        TextDC.transform.GetComponent<Text>().fontSize = 45;
        TextDC.transform.GetComponent<Transform>().localPosition = new Vector3(88.9f, -33, 0);
        DialogueContinue.GetComponent<Button>().onClick.AddListener(() => DialogueContinueOnClickEvent());

        infoTextCanvas.SetActive(false);
        DialogueGO.SetActive(false);

    }

    void DialogueContinueOnClickEvent()
    {
        Debug.Log(ContinueCount);
        if (ContinueCount == 0)
        {
            myText.SetActive(true);
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 20;
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().LookAt = Otis.transform;

            text.transform.GetComponent<Text>().text = "“Buna göre, gördüðüm her þeyin yanlýþ ve hayali olduðunu varsayýyorum; Yanýltýcý belleðimin temsil ettiði nesnelerden hiçbirinin var olmadýðýna inanýyorum; Sanýrým hiçbir duyuya sahip deðilim; Bedenin, figürün, uzantýnýn, hareketin ve yerin sadece zihnimin kurgularý olduðuna inanýyorum. O halde, doðru kabul edilebilecek ne var? Belki de sadece bu, kesinlikle kesin bir þey olmadýðý.”";
            ContinueCount++;
        }
        else if (ContinueCount==1)
        {
            //myText.SetActive(false);
            //myText2.SetActive(true);
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().LookAt = NPC.transform;
            ContinueCount++;
            text.transform.GetComponent<Text>().text = "....";

        }
        else 
        {
            text.transform.GetComponent<Text>().text = "…- deðiþik homurtular ve derin sesler-… Ýnsan… Buraya gelenler gerçekliðin ne kadar þaþýrtýcý olabileceðini göremiyorlar. Size verilen gözler sadece görmenize yarýyor, daha ötesine bakamýyorsunuz… Ýleride, tepede bir kapý var. Bu kapýyý açabilmek için en ilkel insan zekasýna ihtiyacýn olacak. Baþka bir kapýnýn ardýnda seni bekliyor.”";
            Cursor.visible = false;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
            infoTextCanvas.SetActive(true);
            DialogueGO.SetActive(false);
            ContinueCount++;
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
            inDialogueSize = true;
            StartCoroutine(LightsScript());
            canEsc = true;
        }


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
            inDialogueSize = false;
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().LookAt = NPC.transform;
            infoTextCanvas.SetActive(false);
            DialogueGO.SetActive(true);
            DialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            DialogueDollyCart.SetActive(true);
            canEsc = false;
            Cursor.visible = true;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            NPCAudio.Play();
            ContinueCount = 0 ;
            PickUp.canTake = true;


        }
    }
    IEnumerator LightsScript()
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
}