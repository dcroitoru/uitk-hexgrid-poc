using System;
using UnityEngine;
using UnityEngine.UIElements;

public class HexGridVE : VisualElement {
    public new class UxmlFactory : UxmlFactory<HexGridVE, UxmlTraits> { }

    // Add the two custom UXML attributes.
    public new class UxmlTraits : VisualElement.UxmlTraits {
        UxmlIntAttributeDescription rows =
            new UxmlIntAttributeDescription { name = "rows", defaultValue = 2 };
        UxmlIntAttributeDescription cols =
        new UxmlIntAttributeDescription { name = "cols", defaultValue = 5 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) {
            base.Init(ve, bag, cc);
            var grid = ve as HexGridVE;
            grid.rows = rows.GetValueFromBag(bag, cc);
            grid.cols = cols.GetValueFromBag(bag, cc);


        }
    }

    // Must expose your element class to a { get; set; } property that has the same name 
    // as the name you set in your UXML attribute description with the camel case format
    int _rows = 0;
    int _cols = 0;
    int max = 10;

    public int rows { get => _rows; set { _rows = Math.Clamp(value, 0, max); Draw(); } }
    public int cols { get => _cols; set { _cols = Math.Clamp(value, 0, max); Draw(); } }

    public HexGridVE() {
        AddToClassList("container");

    }

    private void Draw() {
        // Debug.Log($"should redraw {_rows} {_cols}");
        Clear();
        Cell[,] cells;// = new Cell[2, 5];
        cells = new Cell[rows, cols];
        for (var y = 0; y < rows; y++) {
            for (var x = 0; x < cols; x++) {
                var cell = new Cell();
                cell.Init(x, y);
                cells[y, x] = cell;
                Add(cell);
            }
        }


    }

    void OnClick(ClickEvent evt) {
        Debug.Log(evt.target);

        if (evt.target is Cell c) {
            GhostCell ghost = new();
            ghost.Init(c.xpos, c.ypos);
            Add(ghost);
            c.BringToFront();
        }

    }
}
