using Quest.SaveSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Data
{
    public sealed class ScreenData : MonoBehaviour
    {
        [SerializeField] private List<Data> _all = new();
        [SerializeField] private List<NodeCondition> _conditions = new();

        public IEnumerable<Data> All => _all;
        public IEnumerable<NodeCondition> Conditions => _conditions;


        [Serializable]
        public sealed class Data
        {
            public string Description;
            public string ChoiseDescription;
            public byte Card;
        }

        [Serializable]
        public sealed class NodeCondition
        {
            public Node Node;
        }
    }

    public enum Node
    {
        Success,
        Error
    }

    public sealed class ScreenStorage
    {
        private IStorage
        public IEnumerable<ScreenData.Data> LoadDatas()
        {

        }
    }
}
