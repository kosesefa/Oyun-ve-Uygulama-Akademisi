using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Cinemachine;
using Cinemachine.Utility;

public class FinalDialogue1 : MonoBehaviour
{
    public GameObject characterController;
    //Dialogues
    public AudioSource ROCKAudio2;
    public GameObject RockPanel2;
    public Font Rock_Font2;
    public Font Rock_TMPFont2;
    private GameObject RockDialogueGO2;
    private GameObject RockMyText2;
    private GameObject RockInfoText2;
    private GameObject RockInfoTextCanvas2;
    private Canvas Rock_Canvas2;
    private Canvas RockMyCanvas2;
    private Text RockText2;
    private Text Rock_InfoText2;
    private RectTransform RockRectTransform2;
    private RectTransform RockRectTransform2_;
    private RectTransform RockRectTransformTextDC2;
    private RectTransform RockRectTransformButton2;
    private RectTransform RockRectTransformInfoText2;
    bool RockInDialogueSize2 = false;
    [SerializeField] GameObject RockDialogueVirtualCamera2;
    public static bool RockCanESC2 = true;
    public GameObject RockDialogueContinue2;
    public GameObject RockTextDC2;
    public int ContinueCount2 = 0;
    [SerializeField] GameObject NPC2;
    [SerializeField] GameObject isVisibleNPC;
    [SerializeField] GameObject Otis2;

    void Start()
    {
        isVisibleNPC.SetActive(false);
        characterController = new GameObject();
        RockDialogueGO2 = new GameObject();
        RockDialogueGO2.name = "Canvas Rock Dialogue";
        RockDialogueGO2.AddComponent<Canvas>();

        RockInfoTextCanvas2 = new GameObject();
        RockInfoTextCanvas2.name = "Info Canvas";
        RockInfoTextCanvas2.AddComponent<Canvas>();
        RockInfoTextCanvas2.AddComponent<CanvasScaler>();
        RockInfoTextCanvas2.AddComponent<GraphicRaycaster>();
        Rock_Canvas2 = RockInfoTextCanvas2.GetComponent<Canvas>();
        Rock_Canvas2.renderMode = RenderMode.ScreenSpaceOverlay;

        RockPanel2 = new GameObject();

        RockMyCanvas2 = RockDialogueGO2.GetComponent<Canvas>();
        RockMyCanvas2.renderMode = RenderMode.ScreenSpaceOverlay;
        RockDialogueGO2.AddComponent<CanvasScaler>();
        RockDialogueGO2.AddComponent<GraphicRaycaster>();




        //Panel Settings
        RockPanel2.transform.parent = RockDialogueGO2.transform;
        RockPanel2.AddComponent<Image>();
        RockPanel2.GetComponent<Image>().color = new Color32(55, 55, 55, 237);
        RockPanel2.GetComponent<Image>().raycastTarget = true;
        RockPanel2.GetComponent<Image>().maskable = true;
        RockPanel2.GetComponent<Transform>().localPosition = new Vector3(0, -133, 0f);
        RockPanel2.GetComponent<Transform>().localScale = new Vector3(7.1f, 5.5f, 1);
        RockDialogueGO2.SetActive(false);


        // Text
        RockMyText2 = new GameObject();
        RockMyText2.transform.parent = RockDialogueGO2.transform;
        RockMyText2.name = "Dialogue";
        RockMyText2.transform.SetSiblingIndex(666);
        RockText2 = RockMyText2.AddComponent<Text>();
        RockText2.transform.GetComponent<Text>().text = "Gerçeðe ulaþmaya bu kadar yakýnken etrafta olan biteni kaçýrdýn ve göremedin. Kendi gerçekliðinde her þey bir ikilem, bir denge. ";
        RockText2.transform.GetComponent<Text>().font = Rock_Font2;
        RockText2.transform.GetComponent<Text>().fontSize = 33;
        RockText2.transform.GetComponent<Text>().lineSpacing = 2;
        RockRectTransform2 = RockMyText2.GetComponent<RectTransform>();


        // Text position
        RockRectTransform2 = RockText2.GetComponent<RectTransform>();
        RockRectTransform2.localPosition = new Vector3(0, -152, 0);
        RockRectTransform2.sizeDelta = new Vector2(607, 500);
        RockRectTransform2_ = RockText2.GetComponent<RectTransform>();
        RockRectTransform2_.localPosition = new Vector3(0, -152, 0);
        RockRectTransform2_.sizeDelta = new Vector2(607, 500);

        // Info Text
        RockInfoText2 = new GameObject();
        RockInfoText2.name = "Info Text";
        RockInfoText2.transform.parent = RockInfoTextCanvas2.transform;
        RockInfoText2.transform.SetSiblingIndex(666);
        Rock_InfoText2 = RockInfoText2.AddComponent<Text>();
        Rock_InfoText2.transform.GetComponent<Text>().text = "";
        Rock_InfoText2.transform.GetComponent<Text>().font = Rock_Font2;
        Rock_InfoText2.transform.GetComponent<Text>().fontSize = 29;
        Rock_InfoText2.transform.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        Rock_InfoText2.transform.GetComponent<Text>().alignment = TextAnchor.LowerCenter;


        RockRectTransformInfoText2 = Rock_InfoText2.GetComponent<RectTransform>();
        RockRectTransformInfoText2.localPosition = new Vector3(0, -472f, 0);
        RockRectTransformInfoText2.sizeDelta = new Vector2(858.4f, 137f);
        RockInfoText2.transform.GetComponent<Text>().fontSize = 53; ;
        RockRectTransformInfoText2 = RockInfoText2.GetComponent<RectTransform>();


        //Button
        RockDialogueContinue2 = new GameObject();
        RockTextDC2 = new GameObject();
        RockDialogueContinue2.transform.parent = RockDialogueGO2.transform;
        RockTextDC2.transform.parent = RockDialogueContinue2.transform;
        RockTextDC2.name = "Text";
        RockDialogueContinue2.name = "Continue Button";
        RockDialogueContinue2.AddComponent<CanvasRenderer>();
        RockTextDC2.AddComponent<Text>();
        RockDialogueContinue2.AddComponent<Image>();
        RockDialogueContinue2.GetComponent<Image>().color = new Color32(1, 1, 1, 0);
        RockDialogueContinue2.AddComponent<Button>();
        RockDialogueContinue2.transform.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        RockDialogueContinue2.transform.GetComponent<Transform>().localPosition = new Vector3(222, -354, 0);
        RockRectTransformButton2 = RockTextDC2.GetComponent<RectTransform>();
        RockRectTransformTextDC2 = RockDialogueContinue2.GetComponent<RectTransform>();
        RockRectTransformTextDC2.sizeDelta = new Vector2(172, 82);
        RockRectTransformButton2.sizeDelta = new Vector2(315, 100);
        RockTextDC2.transform.GetComponent<Text>().text = "Devam et";
        RockTextDC2.transform.GetComponent<Text>().font = Rock_Font2;
        RockTextDC2.transform.GetComponent<Text>().fontSize = 45;
        RockTextDC2.transform.GetComponent<Transform>().localPosition = new Vector3(88.9f, -33, 0);
        RockDialogueContinue2.GetComponent<Button>().onClick.AddListener(() => DialogueContinueOnClickEvent());

        RockInfoTextCanvas2.SetActive(false);
        RockDialogueGO2.SetActive(false);
        
    }

    void DialogueContinueOnClickEvent()
    {
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        //RockInfoTextCanvas2.SetActive(true);
        RockDialogueGO2.SetActive(false);
        RockDialogueVirtualCamera2.GetComponent<CinemachineVirtualCamera>().Priority = 5;
        RockInfoTextCanvas2.SetActive(true);
        RockCanESC2 = true;
        Death.cc.enabled = true;
        StartCoroutine(Visible());

        //StartCoroutine(LightsScript());
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Key"))
        {

                isVisibleNPC.SetActive(true);
                Death.cc.enabled = false;
                RockDialogueVirtualCamera2.GetComponent<CinemachineVirtualCamera>().LookAt = NPC2.transform;
                RockInfoTextCanvas2.SetActive(false);
                RockDialogueGO2.SetActive(true);
                RockDialogueVirtualCamera2.GetComponent<CinemachineVirtualCamera>().Priority = 15;
                RockCanESC2 = false;
                Cursor.visible = true;
                //ROCKAudio.Play();
                StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
                StarterAssets.StarterAssetsInputs.instance.cursorLocked = false;
                Cursor.lockState = CursorLockMode.None;
                
        }
    }
    private void OnTriggerExit(Collider other)
    {
        RockInDialogueSize2 = false;
        RockInfoTextCanvas2.SetActive(false);
        Death.cc.enabled = true;
        StartCoroutine(Visible());

    }

    void Update()
    {

        
    }
    IEnumerator Visible()
    {
        yield return new WaitForSeconds(3f);
        isVisibleNPC.SetActive(false);
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