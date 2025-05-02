using TMPro;
using UnityEngine;
using System.Linq;

public class CreateBlocks : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Transform blueprint;
    [SerializeField] private GameObject[] blocks;

    void Awake()
    {
        dropdown.AddOptions(blocks.Select(i => i.name).ToList());
    }

    public void CreateBlock(int index) 
    {
        Instantiate(blocks[index], blueprint);
    }
}
