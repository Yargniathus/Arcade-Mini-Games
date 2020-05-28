using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Xamk.GymApi;

public class MachineTypesScript : MonoBehaviour
{
    public Dropdown MachineDropdown;

    // Start is called before the first frame update
    void Start()
    {
        var options = new List<Dropdown.OptionData>();

        foreach (string name in Enum.GetNames(typeof(HurObject.Machine)))
        {
            options.Add(new Dropdown.OptionData(name));
        }

        MachineDropdown.options = options;

        MachineDropdown.value = 1;
        MachineDropdown.onValueChanged.AddListener(MachineSelected);
    }

    static void MachineSelected(int index)
    {
        PlayerPrefs.SetInt("SelectedMachine", index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
