using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatastructureDemo130Batch
{
    class MyMapNode<K, V>
    {
        public struct KeyValue<k, v>//structrue ist like a class but not support the interface
                                    //stuct class value type store data
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size; //readonly useded to get that variable inside that class only/declare inside that class 
        //int[] arr;
        private readonly LinkedList<KeyValue<K, V>>[] items;//linked list array

        public MyMapNode(int size)//constructor
        {
            this.size = size;//this keyword used to creat current instacnce of the class//our size=6 
            //arr=new int[size];
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPosition(K key)//here we  will calculate for the postion using hash fuction 
        {
            int hash = key.GetHashCode(); //637362//gethashcode method is the library fuction/method inside object class
            int position = hash % size; // 0 to 4//all these process is known as hash function
            //here we are taking modulus of that hash with size to get the size inside our hashtable
            return Math.Abs(position);//abs to get the absolute value that is only +ve vlaues
        }

        public V Get(K key)//here for the repaeted word we are getting the key
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }

            return default(V);
        }

        public void Add(K key, V value)//here we will add the key value inside that linked list
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };//here we will assign key and value to the linkedlist
            if (linkedList.Count != 0)//for therepeated words it will go inside this 
            {
                foreach (KeyValue<K, V> item1 in linkedList)
                {
                    if (item1.Key.Equals(key))//if that item is matching it will remove
                    {
                        Remove(key);
                        break;
                    }
                }
            }
            linkedList.AddLast(item); // to,2//adding the inside that linkedlist
            // Console.WriteLine(item.Key + " " + item.Value);
        }

        public bool Exists(K key)//to  check that word exist or not
        {
            var linkedList = GetArrayPositionAndLinkedList(key);//going to this method
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public LinkedList<KeyValue<K, V>> GetArrayPositionAndLinkedList(K key)//this method is to get the postion and also linked list to store
        {
            int position = GetArrayPosition(key); //here we are going inside the getarraypostion method
                                                  //to get the postion index number of array
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);//get for that position we will create linked list
            //because of that we are going inside the getlinkedlist method
            return linkedList;
        }


        public void Remove(K key)
        {
            var linkedList = GetArrayPositionAndLinkedList(key);//here we are getting the key postion
                                                                //and linkedlist of that word
            bool itemFound = false;//intializing bool
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)//if that item found then bool=true
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                    //linkedList.Remove(item);
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);//if that item found we will remove that item using remove library method
                //Console.WriteLine("Removed successfully with key " + foundItem.Key);
            }
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)//here creating linked list
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position]; //now we can get that item postion of "to" as 2
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;//create and return the linkedlist
            }
            return linkedList;
        }

        public void Display()
        {
            foreach (var linkedList in items)//travesr inside that linked list
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();//conver that element to string
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);//displaying key and value
                    }
            }
        }
    }
}
//o/p:Displaying after add operation
//not 1
//or 1
//to 2
//be 2
//After removed an item or
//not 1
//to 2
//be 2
//}