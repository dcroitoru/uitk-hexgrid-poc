using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : VisualElement {
    public new class UxmlFactory : UxmlFactory<Item, UxmlTraits> { }
    public Item() {
        AddToClassList("item");
        RegisterCallback<GeometryChangedEvent>(redraw);
    }

    public List<Cell> parentCells;

    void redraw(GeometryChangedEvent evt) {
        // Debug.Log("should redraw: " + name);

        var center = worldBound.center;
        var size = new Vector2(worldBound.width / 3, worldBound.height / 3);
        var bound = new Rect(center, size);
        var cells = parent.parent.Query<Cell>();
        var overlap = cells.Where(cell => cell.worldBound.Overlaps(bound)).ToList();
        overlap.ForEach(cell => cell.AddToClassList("hex-cell-full"));

        parentCells = overlap;
    }
}
