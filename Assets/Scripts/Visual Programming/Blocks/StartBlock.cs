using System.Collections;

public class StartBlock : Block
{
    public override IEnumerator Process(object[] data)
    {
        output[0].Output(null);
        yield break;
    }

    // Нельзя удалить начальный блок
    public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData _) {}
}