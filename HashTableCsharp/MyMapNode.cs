﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableCsharp
{
    class MyMapNode<K,V>
    {
        private readonly int size;
        public readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        private int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K,V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public bool Exists(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }


        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            if (Exists(key))
            {
                Remove(key);
            }
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K,V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }

        }
        private LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public struct KeyValue<k, v>
        { 
            public k Key { get; set; }
            public v Value { get; set; }
        }

        public void PrintDictionary()
        {
            foreach (var linkedlist in items)
            {
                if (linkedlist == null)
                {
                    continue;
                }
                foreach (var item in linkedlist)
                {
                    Console.WriteLine(item.Key + "  " + item.Value);
                }
            }

        }
    }
}
