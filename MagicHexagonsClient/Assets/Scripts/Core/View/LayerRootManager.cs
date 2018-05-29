using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core.View
{
    public class LayerRootManager: MonoBehaviour
    {
        [Serializable]
        public class LayerOffset
        {
            public LayerId Layer;
            public Vector2 Offset;
        }

        [SerializeField]
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private Vector2 _referenceResolution = new Vector2(1080.0f, 1920.0f);

        [SerializeField]
        // ReSharper disable once UnassignedField.Compiler
        private List<LayerOffset> _initialLayersOffsets;

        public Vector2 ReferenceResolution { get { return _referenceResolution; } }

        public Vector2 GetLayerOffset(LayerId layer)
        {
            var offset = _initialLayersOffsets.FirstOrDefault(l => l.Layer == layer);

            return offset != null ? offset.Offset : Vector2.zero;
        }
    }
}
