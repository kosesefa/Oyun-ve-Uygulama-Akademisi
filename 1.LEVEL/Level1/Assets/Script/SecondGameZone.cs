using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Cinemachine;
using Cinemachine.Utility;

public class SecondGameZone : MonoBehaviour
{
    //Dialogues
    public AudioSource audioSecondGame;
    public GameObject panel;
    public Font _fontSecondGame;
    public Font _TMPfontSecondGame;
    private GameObject DialogueGOSecondGame;
    private GameObject myTextSecondGame;
    private GameObject infoTextSecondGame;
    private GameObject infoTextCanvasSecondGame;
    private Canvas _canvasSecondGame;
    private Canvas myCanvasSecondGame;
    private Text textSecondGame;
    private Text _infoTextSecondGame;
    private RectTransform rectTransformSecondGame;
    private RectTransform rectTransform2SecondGame;
    private RectTransform rectTransformTextDCSecondGame;
    private RectTransform rectTransformButtonSecondGame;
    private RectTransform rectTransformInfoTextSecondGame;
    bool inDialogueSizeSecondGame = false;
    [SerializeField] GameObject DialogueVirtualCameraSecondGame;
    [SerializeField] GameObject DialogueDollyCartSecondGame;
    public static bool canEscSecondGame = true;
    public GameObject DialogueContinueSecondGame;
    public GameObject TextDCSecondGame;
    public int ContinueCountSecondGame = 0;
    [SerializeField] GameObject NPCSecondGame;
    [SerializeField] GameObject OtisSecondGame;
    //public GameObject WriteLineSecondGame;
    public string password = "ABACCA";
    [SerializeField] public GameObject typePassword;
    public int continueCounter = 0;
    public TMP_InputField typePass;
    public GameObject MainCanvasSecondGame;
    public bool inSize = false;



    void Start()
    {
        typePassword.SetActive(false);
        DialogueDollyCartSecondGame.SetActive(false);

        DialogueGOSecondGame = new GameObject();
        DialogueGOSecondGame.name = "Canvas Dialogue";
        DialogueGOSecondGame.AddComponent<Canvas>();

        infoTextCanvasSecondGame = new GameObject();
        infoTextCanvasSecondGame.name = "Info Canvas";
        infoTextCanvasSecondGame.AddComponent<Canvas>();
        infoTextCanvasSecondGame.AddComponent<CanvasScaler>();
        infoTextCanvasSecondGame.AddComponent<GraphicRaycaster>();
        _canvasSecondGame = infoTextCanvasSecondGame.GetComponent<Canvas>();
        _canvasSecondGame.renderMode = RenderMode.ScreenSpaceOverlay;

        panel = new GameObject();

        myCanvasSecondGame = DialogueGOSecondGame.GetComponent<Canvas>();
        myCanvasSecondGame.renderMode = RenderMode.ScreenSpaceOverlay;
        DialogueGOSecondGame.AddComponent<CanvasScaler>();
        DialogueGOSecondGame.AddComponent<GraphicRaycaster>();


        //Panel Settings
        panel.transform.parent = DialogueGOSecondGame.transform;
        panel.AddComponent<Image>();
        panel.GetComponent<Image>().color = new Color32(55, 55, 55, 237);
        panel.GetComponent<Image>().raycastTarget = true;
        panel.GetComponent<Image>().maskable = true;
        panel.GetComponent<Transform>().localPosition = new Vector3(0, -194, 0f);
        panel.GetComponent<Transform>().localScale = new Vector3(11.68f, 2.56f, 1);
        DialogueGOSecondGame.SetActive(false);


        // Text
        myTextSecondGame = new GameObject();
        myTextSecondGame.transform.parent = DialogueGOSecondGame.transform;
        myTextSecondGame.name = "Dialogue";
        myTextSecondGame.transform.SetSiblingIndex(666);
        textSecondGame = myTextSecondGame.AddComponent<Text>();
        textSecondGame.transform.GetComponent<Text>().text = "Gecmiste attigin adimi hatirliyor musun? Hafizani yenilemek icin ayak izlerini takip et, gecmise bir bakis at. Bu kapiyi acmak icin üstünden gectigin taslarin üzerindeki harfleri yazmalisin.";
        textSecondGame.transform.GetComponent<Text>().font = _fontSecondGame;
        textSecondGame.transform.GetComponent<Text>().fontSize = 29;
        rectTransformSecondGame = myTextSecondGame.GetComponent<RectTransform>();


        // Text position
        rectTransformSecondGame = textSecondGame.GetComponent<RectTransform>();
        rectTransformSecondGame.localPosition = new Vector3(0, -229, 0);
        rectTransformSecondGame.sizeDelta = new Vector2(1071, 243);
        rectTransform2SecondGame = textSecondGame.GetComponent<RectTransform>();
        rectTransform2SecondGame.localPosition = new Vector3(0, -229, 0);
        rectTransform2SecondGame.sizeDelta = new Vector2(1071, 243);

        // Info Text
        infoTextSecondGame = new GameObject();
        infoTextSecondGame.name = "Info Text";
        infoTextSecondGame.transform.parent = infoTextCanvasSecondGame.transform;
        infoTextSecondGame.transform.SetSiblingIndex(666);
        _infoTextSecondGame = infoTextSecondGame.AddComponent<Text>();
        _infoTextSecondGame.transform.GetComponent<Text>().text = "Okumak icin F'ye basin.";
        _infoTextSecondGame.transform.GetComponent<Text>().font = _fontSecondGame;
        _infoTextSecondGame.transform.GetComponent<Text>().fontSize = 29;
        _infoTextSecondGame.transform.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        _infoTextSecondGame.transform.GetComponent<Text>().alignment = TextAnchor.LowerCenter;


        rectTransformInfoTextSecondGame = _infoTextSecondGame.GetComponent<RectTransform>();
        rectTransformInfoTextSecondGame.localPosition = new Vector3(0, -472f, 0);
        rectTransformInfoTextSecondGame.sizeDelta = new Vector2(858.4f, 137f);
        infoTextSecondGame.transform.GetComponent<Text>().fontSize = 53; ;
        rectTransformInfoTextSecondGame = infoTextSecondGame.GetComponent<RectTransform>();


        //Button
        DialogueContinueSecondGame = new GameObject();
        TextDCSecondGame = new GameObject();
        DialogueContinueSecondGame.transform.parent = DialogueGOSecondGame.transform;
        TextDCSecondGame.transform.parent = DialogueContinueSecondGame.transform;
        TextDCSecondGame.name = "Text";
        DialogueContinueSecondGame.name = "Continue Button";
        DialogueContinueSecondGame.AddComponent<CanvasRenderer>();
        TextDCSecondGame.AddComponent<Text>();
        DialogueContinueSecondGame.AddComponent<Image>();
        DialogueContinueSecondGame.GetComponent<Image>().color = new Color32(1, 1, 1, 0);
        DialogueContinueSecondGame.AddComponent<Button>();
        DialogueContinueSecondGame.transform.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        DialogueContinueSecondGame.transform.GetComponent<Transform>().localPosition = new Vector3(427, -274, 0);
        rectTransformButtonSecondGame = TextDCSecondGame.GetComponent<RectTransform>();
        rectTransformTextDCSecondGame = DialogueContinueSecondGame.GetComponent<RectTransform>();
        rectTransformTextDCSecondGame.sizeDelta = new Vector2(172, 82);
        rectTransformButtonSecondGame.sizeDelta = new Vector2(315, 100);
        TextDCSecondGame.transform.GetComponent<Text>().text = "Devam et";
        TextDCSecondGame.transform.GetComponent<Text>().font = _fontSecondGame;
        TextDCSecondGame.transform.GetComponent<Text>().fontSize = 45;
        TextDCSecondGame.transform.GetComponent<Transform>().localPosition = new Vector3(88.9f, -33, 0);
        DialogueContinueSecondGame.GetComponent<Button>().onClick.AddListener(() => DialogueContinueOnClickEvent());

        infoTextCanvasSecondGame.SetActive(false);
        DialogueGOSecondGame.SetActive(false);

        MainCanvasSecondGame.SetActive(false);
    }

    void DialogueContinueOnClickEvent()
    {
        if (continueCounter == 0)
        {
            //DialogueGOSecondGame.SetActive(false);
            textSecondGame.enabled = false;
            panel.SetActive(false);
            continueCounter++;
            MainCanvasSecondGame.SetActive(true);
            typePass.Select();

        }

        else if (continueCounter == 1)
        {
            string typePassword = typePass.GetComponent<TMP_InputField>().text;
            if (typePassword == "ABACCA")
            {
                Debug.Log("DOÐRU");
                typePass.Select();
            }
            typePass.Select();
        }
        /*
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        infoTextCanvasSecondGame.SetActive(true);
        DialogueGOSecondGame.SetActive(false);
        DialogueVirtualCameraSecondGame.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        infoTextCanvasSecondGame.SetActive(true);
        */
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Key"))
        {
            inDialogueSizeSecondGame = true;
            infoTextCanvasSecondGame.SetActive(true);
            typePassword.SetActive(true);
            inSize = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inDialogueSizeSecondGame = false;
        infoTextCanvasSecondGame.SetActive(false);
        typePassword.SetActive(false);
        inSize = false;
    }

    void Update()
    {
        typePass.text = typePass.text.ToUpper();
        if (Input.GetKeyDown(KeyCode.F) && inDialogueSizeSecondGame == true)
        {
            DialogueVirtualCameraSecondGame.GetComponent<CinemachineVirtualCamera>().LookAt = NPCSecondGame.transform;
            infoTextCanvasSecondGame.SetActive(false);
            DialogueGOSecondGame.SetActive(true);
            DialogueVirtualCameraSecondGame.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            DialogueDollyCartSecondGame.SetActive(true);
            canEscSecondGame = false;
            Cursor.visible = true;
            //audio.Play();
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Death.thirdPersonController.enabled = false;
            //rigidbody.constraints = RigidbodyConstraints.None;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inSize==true)
        {
            DialogueGOSecondGame.SetActive(false);
            DialogueDollyCartSecondGame.SetActive(false);
            //inDialogueSizeSecondGame = false;
            infoTextCanvasSecondGame.SetActive(true);
            canEscSecondGame = true;
            DialogueVirtualCameraSecondGame.GetComponent<CinemachineVirtualCamera>().Priority = 5;
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
            Cursor.visible = false;
            Death.thirdPersonController.enabled = true;
            textSecondGame.enabled = true;
            panel.SetActive(true);
            continueCounter = 0;
        }
    }

}