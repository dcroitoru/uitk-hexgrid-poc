using UnityEngine;
using UnityEngine.UIElements;

public class MyGrid : MonoBehaviour {
    [SerializeField] UIDocument document;

    int rows = 2;
    int cols = 5;

    VisualElement grid;

    private void Awake() {
        var root = document.rootVisualElement;


        grid = root.Q("grid");
        if (grid == null) {
            Debug.LogWarning("Could not find grid");
            return;
        }

        var items = root.Query(className: "item");
        items.ForEach(item => item.RegisterCallback<ClickEvent>(OnItemClick));

    }

    void OnItemClick(ClickEvent evt) {
        Debug.Log($"clicked on {evt.target}");

        ClearSelection();

        var cells = (evt.target as Item).parentCells;

        cells.ForEach(cell => {
            var ghostCell = CreateGhostCell(cell);
            grid.Add(ghostCell);
            cell.BringToFront();
        });

        cells.ForEach(cell => cell.BringToFront());

    }

    GhostCell CreateGhostCell(Cell c) {
        GhostCell ghost = new();
        ghost.Init(c.xpos, c.ypos);
        return ghost;
    }

    void ClearSelection() {
        var oldCells = grid.Query<GhostCell>();
        oldCells.ForEach(grid.Remove);
    }
}
