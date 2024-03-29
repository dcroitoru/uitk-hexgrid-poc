using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostCell : VisualElement {
    const int size = 100;
    public int xpos = 0;
    public int ypos = 0;

    public GhostCell() {
        AddToClassList("hex-selection-cell");
    }

    public void Init(int x, int y) {
        xpos = x;
        ypos = y;
        var pad = 13;
        var doublePad = pad * 2;
        var offsetx = y % 2 * size / 2;
        style.left = size * x + offsetx;
        style.top = (size - pad) * y;
        style.width = size + size / 2 + doublePad;
        style.height = size + size / 2 + doublePad;
    }
}
