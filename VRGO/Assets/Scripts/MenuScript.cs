using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public Renderer surfaceRenderer;
    public Image menuBackground;
    public TextMeshProUGUI scrollText;
    public TextMeshProUGUI fontSizeText;

    private float menuAlpha = 0.7f;

    public Canvas menuUI;

    private bool isMenuPressedDownLeft = false;
    private bool isMenuPressedDownRight = false;

    public void ChangeSurfaceColor_OnClick()
    {
        surfaceRenderer.material.color = Random.ColorHSV();
    }

    public void MenuColorDropdown_OnValueCHanged(int index)
    {
        Color indexColor = Color.black;

        switch (index)
        {
            case 1: indexColor = Color.red; break;
            case 2: indexColor = Color.green; break;
            case 3: indexColor = Color.blue; break;
        }

        menuBackground.color = new Color(indexColor.r, indexColor.g, indexColor.b, menuBackground.color.a);
    }

    public void TransparentBackground_OnValueChanged(bool isOn)
    {
        menuAlpha = isOn ? 0.7f : 1.0f;

        menuBackground.color = new Color(
            menuBackground.color.r,
            menuBackground.color.g,
            menuBackground.color.b,
            menuAlpha
        );
    }

    public void FontSize_OnValueChanged(float value)
    {
        scrollText.fontSize = value;
        fontSizeText.text = $"Font Size: {(int)value}";
    }

    private void Update()
    {
        HandleMenuButton(XRNode.LeftHand, ref isMenuPressedDownLeft);
        HandleMenuButton(XRNode.RightHand, ref isMenuPressedDownRight);
    }

    private void HandleMenuButton(XRNode handNode, ref bool wasPressedLastFrame)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(handNode);

        bool isPressed = false;
        device.TryGetFeatureValue(CommonUsages.menuButton, out isPressed);

        if (isPressed)
        {
            // Toggle only on the transition (button-down event)
            if (!wasPressedLastFrame)
            {
                menuUI.enabled = !menuUI.enabled;
            }
            wasPressedLastFrame = true;
        }
        else
        {
            wasPressedLastFrame = false;
        }
    }
}
