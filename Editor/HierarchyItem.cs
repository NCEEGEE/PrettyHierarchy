using UnityEditor;
using UnityEngine;

namespace PrettyHierarchy
{
    public struct HierarchyItem
    {
        public int InstanceID { get; }
        public bool IsSelected { get; }
        public bool IsHovered { get; }
        public GameObject GameObject { get; }
        public PrettyObject PrettyObject { get; }
        public Rect BackgroundRect { get; }
        public Rect TextRect { get; }
        public Rect CollapseToggleIconRect { get; }
        public Rect PrefabIconRect { get; }
        public Rect EditPrefabIconRect { get; }

        public HierarchyItem(int instanceID, Rect selectionRect, PrettyObject prettyObject)
        {
            InstanceID = instanceID;
            IsSelected = Selection.Contains(instanceID);
            GameObject = prettyObject.gameObject;
            PrettyObject = prettyObject;

            float xPos = selectionRect.position.x + 60f - 28f - selectionRect.xMin;
            float yPos = selectionRect.position.y;
            float xSize = selectionRect.size.x + selectionRect.xMin + 28f - 60 + 16f;
            float ySize = selectionRect.size.y;
            BackgroundRect = new Rect(xPos, yPos, xSize, ySize);

            xPos = selectionRect.position.x + 18f;
            yPos = selectionRect.position.y;
            xSize = selectionRect.size.x - 18f;
            ySize = selectionRect.size.y;
            TextRect = new Rect(xPos, yPos, xSize, ySize);

            xPos = selectionRect.position.x - 14f;
            yPos = selectionRect.position.y + 1f;
            xSize = 13f;
            ySize = 13f;
            CollapseToggleIconRect = new Rect(xPos, yPos, xSize, ySize);

            xPos = selectionRect.position.x;
            yPos = selectionRect.position.y;
            xSize = 16f;
            ySize = 16f;
            PrefabIconRect = new Rect(xPos, yPos, xSize, ySize);

            xPos = BackgroundRect.xMax - 16f;
            yPos = selectionRect.yMin;
            xSize = 16f;
            ySize = 16f;
            EditPrefabIconRect = new Rect(xPos, yPos, xSize, ySize);

            IsHovered = BackgroundRect.Contains(Event.current.mousePosition);
        }
    }
}