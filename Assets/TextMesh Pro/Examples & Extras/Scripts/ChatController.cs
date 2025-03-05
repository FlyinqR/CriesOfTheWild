using UnityEngine;
using UnityEngine.UI;
<<<<<<< Updated upstream
using System.Collections;
=======
>>>>>>> Stashed changes
using TMPro;

public class ChatController : MonoBehaviour {


<<<<<<< Updated upstream
    public TMP_InputField TMP_ChatInput;

    public TMP_Text TMP_ChatOutput;
=======
    public TMP_InputField ChatInputField;

    public TMP_Text ChatDisplayOutput;
>>>>>>> Stashed changes

    public Scrollbar ChatScrollbar;

    void OnEnable()
    {
<<<<<<< Updated upstream
        TMP_ChatInput.onSubmit.AddListener(AddToChatOutput);

=======
        ChatInputField.onSubmit.AddListener(AddToChatOutput);
>>>>>>> Stashed changes
    }

    void OnDisable()
    {
<<<<<<< Updated upstream
        TMP_ChatInput.onSubmit.RemoveListener(AddToChatOutput);

=======
        ChatInputField.onSubmit.RemoveListener(AddToChatOutput);
>>>>>>> Stashed changes
    }


    void AddToChatOutput(string newText)
    {
        // Clear Input Field
<<<<<<< Updated upstream
        TMP_ChatInput.text = string.Empty;

        var timeNow = System.DateTime.Now;

        TMP_ChatOutput.text += "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] " + newText + "\n";

        TMP_ChatInput.ActivateInputField();

        // Set the scrollbar to the bottom when next text is submitted.
        ChatScrollbar.value = 0;

=======
        ChatInputField.text = string.Empty;

        var timeNow = System.DateTime.Now;

        string formattedInput = "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] " + newText;

        if (ChatDisplayOutput != null)
        {
            // No special formatting for first entry
            // Add line feed before each subsequent entries
            if (ChatDisplayOutput.text == string.Empty)
                ChatDisplayOutput.text = formattedInput;
            else
                ChatDisplayOutput.text += "\n" + formattedInput;
        }

        // Keep Chat input field active
        ChatInputField.ActivateInputField();

        // Set the scrollbar to the bottom when next text is submitted.
        ChatScrollbar.value = 0;
>>>>>>> Stashed changes
    }

}
