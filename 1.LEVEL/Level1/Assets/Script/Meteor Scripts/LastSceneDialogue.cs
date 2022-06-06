using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Cinemachine;
using Cinemachine.Utility;

public class LastSceneDialogue : MonoBehaviour
{
    //Dialogues
    public AudioSource ROCKAudio;
    public GameObject RockPanel;
    public Font Rock_Font;
    public Font Rock_TMPFont;
    private GameObject RockDialogueGO;
    private GameObject RockMyText;
    private GameObject RockInfoText;
    private GameObject RockInfoTextCanvas;
    private Canvas Rock_Canvas;
    private Canvas RockMyCanvas;
    private Text RockText;
    private Text Rock_InfoText;
    private RectTransform RockRectTransform;
    private RectTransform RockRectTransform2;
    private RectTransform RockRectTransformTextDC;
    private RectTransform RockRectTransformButton;
    private RectTransform RockRectTransformInfoText;
    bool RockInDialogueSize = false;
    [SerializeField] GameObject RockDialogueVirtualCamera;
    public static bool RockCanESC = true;
    public GameObject RockDialogueContinue;
    public GameObject RockTextDC;
    public int ContinueCount = 0;
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject Otis;
    public static bool firstF = false;

    void Start()
    {

        RockDialogueGO = new GameObject();
        RockDialogueGO.name = "Canvas Rock Dialogue";
        RockDialogueGO.AddComponent<Canvas>();

        RockInfoTextCanvas = new GameObject();
        RockInfoTextCanvas.name = "Info Canvas";
        RockInfoTextCanvas.AddComponent<Canvas>();
        RockInfoTextCanvas.AddComponent<CanvasScaler>();
        RockInfoTextCanvas.AddComponent<GraphicRaycaster>();
        Rock_Canvas = RockInfoTextCanvas.GetComponent<Canvas>();
        Rock_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        RockPanel = new GameObject();

        RockMyCanvas = RockDialogueGO.GetComponent<Canvas>();
        RockMyCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        RockDialogueGO.AddComponent<CanvasScaler>();
        RockDialogueGO.AddComponent<GraphicRaycaster>();




        //Panel Settings
        RockPanel.transform.parent = RockDialogueGO.transform;
        RockPanel.AddComponent<Image>();
        RockPanel.GetComponent<Image>().color = new Color32(55, 55, 55, 237);
        RockPanel.GetComponent<Image>().raycastTarget = true;
        RockPanel.GetComponent<Image>().maskable = true;
        RockPanel.GetComponent<Transform>().localPosition = new Vector3(0, -133, 0f);
        RockPanel.GetComponent<Transform>().localScale = new Vector3(7.1f, 5.5f, 1);
        RockDialogueGO.SetActive(false);


        // Text
        RockMyText = new GameObject();
        RockMyText.transform.parent = RockDialogueGO.transform;
        RockMyText.name = "Dialogue";
        RockMyText.transform.SetSiblingIndex(666);
        RockText = RockMyText.AddComponent<Text>();
        RockText.transform.GetComponent<Text>().text = "Havada süzülen taþlarýn hareketini iyi takip etmelisin, onlar doðru zamanda yolunu açacak ve gerçeði gösterecek. Bastýðýn yerlere dikkatli bak, çünkü bilinmeyen olan þey her zaman gökyüzünde olmayabilir.";
        RockText.transform.GetComponent<Text>().font = Rock_Font;
        RockText.transform.GetComponent<Text>().fontSize = 33;
        RockText.transform.GetComponent<Text>().lineSpacing = 2;
        RockRectTransform = RockMyText.GetComponent<RectTransform>();


        // Text position
        RockRectTransform = RockText.GetComponent<RectTransform>();
        RockRectTransform.localPosition = new Vector3(0, -152, 0);
        RockRectTransform.sizeDelta = new Vector2(607, 500);
        RockRectTransform2 = RockText.GetComponent<RectTransform>();
        RockRectTransform2.localPosition = new Vector3(0, -152, 0);
        RockRectTransform2.sizeDelta = new Vector2(607, 500);

        // Info Text
        RockInfoText = new GameObject();
        RockInfoText.name = "Info Text";
        RockInfoText.transform.parent = RockInfoTextCanvas.transform;
        RockInfoText.transform.SetSiblingIndex(666);
        Rock_InfoText = RockInfoText.AddComponent<Text>();
        Rock_InfoText.transform.GetComponent<Text>().text = "Ruh küresini kýrmak için F basýn.";
        Rock_InfoText.transform.GetComponent<Text>().font = Rock_Font;
        Rock_InfoText.transform.GetComponent<Text>().fontSize = 29;
        Rock_InfoText.transform.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        Rock_InfoText.transform.GetComponent<Text>().alignment = TextAnchor.LowerCenter;


        RockRectTransformInfoText = Rock_InfoText.GetComponent<RectTransform>();
        RockRectTransformInfoText.localPosition = new Vector3(0, -472f, 0);
        RockRectTransformInfoText.sizeDelta = new Vector2(858.4f, 137f);
        RockInfoText.transform.GetComponent<Text>().fontSize = 53; ;
        RockRectTransformInfoText = RockInfoText.GetComponent<RectTransform>();


        //Button
        RockDialogueContinue = new GameObject();
        RockTextDC = new GameObject();
        RockDialogueContinue.transform.parent = RockDialogueGO.transform;
        RockTextDC.transform.parent = RockDialogueContinue.transform;
        RockTextDC.name = "Text";
        RockDialogueContinue.name = "Continue Button";
        RockDialogueContinue.AddComponent<CanvasRenderer>();
        RockTextDC.AddComponent<Text>();
        RockDialogueContinue.AddComponent<Image>();
        RockDialogueContinue.GetComponent<Image>().color = new Color32(1, 1, 1, 0);
        RockDialogueContinue.AddComponent<Button>();
        RockDialogueContinue.transform.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        RockDialogueContinue.transform.GetComponent<Transform>().localPosition = new Vector3(222, -354, 0);
        RockRectTransformButton = RockTextDC.GetComponent<RectTransform>();
        RockRectTransformTextDC = RockDialogueContinue.GetComponent<RectTransform>();
        RockRectTransformTextDC.sizeDelta = new Vector2(172, 82);
        RockRectTransformButton.sizeDelta = new Vector2(315, 100);
        RockTextDC.transform.GetComponent<Text>().text = "Devam et";
        RockTextDC.transform.GetComponent<Text>().font = Rock_Font;
        RockTextDC.transform.GetComponent<Text>().fontSize = 45;
        RockTextDC.transform.GetComponent<Transform>().localPosition = new Vector3(88.9f, -33, 0);
        RockDialogueContinue.GetComponent<Button>().onClick.AddListener(() => DialogueContinueOnClickEvent());

        RockInfoTextCanvas.SetActive(false);
        RockDialogueGO.SetActive(false);

    }

    void DialogueContinueOnClickEvent()
    {
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        RockInfoTextCanvas.SetActive(true);
        RockDialogueGO.SetActive(false);
        RockDialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        RockInfoTextCanvas.SetActive(true);
        RockCanESC = true;
        StartCoroutine(LightsScript());
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Key"))
        {
            RockInDialogueSize = true;
            RockInfoTextCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        RockInDialogueSize = false;
        RockInfoTextCanvas.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && RockInDialogueSize == true)
        {
            RockDialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().LookAt = NPC.transform;
            RockDialogueVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            RockCanESC = false;
            Rock_InfoText.enabled = false;
            Cursor.visible = true;
            //ROCKAudio.Play();
            StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
            StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            firstF = true;
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