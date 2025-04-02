using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using TMPro;

public class RobotsPropertiesBlock : ConstantBlock
{
    protected override object Variable 
    { 
        get 
        {
            var robotProperty = robot.GetProperty(properties[propertyIndex]);
            return robotProperty.GetValue(Blueprint.Current.Robot);
        }
    }     

    [SerializeField] private TMP_Dropdown dropdown;
    
    private List<string> properties = new();
    private readonly System.Type robot = typeof(Robot);
    private int propertyIndex;

    void Awake()
    {
        foreach (var i in robot.GetProperties().Where(i => AllowedTypes.Contains(i.PropertyType))) 
        {            
            properties.Add(i.Name);
            Debug.Log(i.Name);
        }
        dropdown.AddOptions(properties);
    }

    public void ChangeProperty(int index) 
    {
        propertyIndex = index;
    }
}
